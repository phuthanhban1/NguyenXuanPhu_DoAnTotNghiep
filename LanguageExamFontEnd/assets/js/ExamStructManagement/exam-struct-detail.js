let listSkill = [];
let skillName = '';
const urlParams = new URLSearchParams(window.location.search);
const bankId = urlParams.get('bankId');
const structId = urlParams.get('structId');
let listQuestionType = [];
let tempStructList = []; // Danh sách cấu trúc tạm thời
let initialStructList = []; // Lưu danh sách ban đầu

// Hàm cập nhật dropdown loại câu hỏi
function updateQuestionTypeDropdown() {
    $('#listQuestionType').empty();
    let hasAvailableQuestionTypes = false;
    listQuestionType.forEach(qt => {
        if (Object.values(qt.questionTypeCounts).some(count => count > 0)) {
            $('#listQuestionType').append(
                `<option value="${qt.id}">${qt.name} (${qt.description})</option>`
            );
            hasAvailableQuestionTypes = true;
        }
    });
    if (!hasAvailableQuestionTypes) {
        $('#listQuestionType').append(
            '<option value="" disabled selected>Không có loại câu hỏi nào khả dụng</option>'
        );
    }
    updateScoreDropdown();
}

// Hàm tải dữ liệu loại câu hỏi từ API
function setOptionModel(skillId) {
    $.ajax({
        url: `https://localhost:7001/api/questionType/count-question-type/${skillId}/${structId}`,
        type: 'GET',
        xhrFields: { withCredentials: true },
        success: function(response) {
            listQuestionType = response.filter(qt => {
                return !Object.values(qt).some(
                    val => typeof val === 'object' && val !== null && Object.keys(val).length === 0
                );
            });
            // Cập nhật questionTypeCounts dựa trên tempStructList
            listQuestionType.forEach(qt => {
                tempStructList.forEach(s => {
                    if (s.questionTypeId === qt.id && qt.questionTypeCounts[s.score] !== undefined) {
                        qt.questionTypeCounts[s.score] -= s.amount;
                    }
                });
            });
            updateQuestionTypeDropdown();
        },
        error: function(error) {
            console.error('Error loading question types:', error.responseText);
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: 'Không thể tải danh sách loại câu hỏi',
            });
        }
    });
}

// Hàm cập nhật dropdown điểm
function updateScoreDropdown() {
    $('#score').empty();
    const selectedQuestionTypeId = $('#listQuestionType').val();
    const questionType = listQuestionType.find(q => q.id === selectedQuestionTypeId);
    if (questionType && questionType.questionTypeCounts) {
        let hasAvailableScores = false;
        for (let score in questionType.questionTypeCounts) {
            if (questionType.questionTypeCounts[score] > 0) {
                $('#score').append(
                    `<option value="${score}">${score} (còn lại: ${questionType.questionTypeCounts[score]})</option>`
                );
                hasAvailableScores = true;
            }
        }
        if (!hasAvailableScores) {
            $('#score').append(
                '<option value="" disabled selected>Không có điểm nào khả dụng</option>'
            );
        }
    } else {
        $('#score').append(
            '<option value="" disabled selected>Không có điểm nào khả dụng</option>'
        );
    }
}

// Render danh sách cấu trúc
function renderStructList() {
    $('#structList').empty();
    if (tempStructList.length === 0) {
        $('#structList').append(`
            <tr>
                <td colspan="5" class="text-center text-gray-600">Không có cấu trúc nào</td>
            </tr>
        `);
        return;
    }
    console.log(tempStructList)
    tempStructList.forEach((s, index) => {
        const questionType = listQuestionType.find(qt => qt.id === s.questionTypeId);
        const questionTypeName = questionType ? questionType.name : s.questionTypeName || 'Unknown';
        $('#structList').append(`
            <tr>
                <td>${index + 1}</td>
                <td>${questionTypeName}</td>
                <td>${s.score}</td>
                <td>${s.amount}</td>
                <td>
                    <button class="btn btn-sm btn-danger delete-struct" 
                            data-struct-id="${s.id}" 
                            data-question-type-id="${s.questionTypeId}" 
                            data-score="${s.score}" 
                            data-amount="${s.amount}" 
                            data-question-type-name="${questionTypeName}">Xóa</button>
                </td>
            </tr>
        `);
    });
    // Tính tổng số điểm
    const totalScore = tempStructList.reduce((sum, s) => sum + (s.score * s.amount), 0);
    // Thêm dòng tổng
    $('#structList').append(`
        <tr class="total-row">
            <td colspan="2" class="text-right font-bold">Tổng số điểm:</td>
            <td class="font-bold">${totalScore}</td>
            <td></td>
            <td></td>
        </tr>
    `);

    // Initialize sortable
    const $tbody = $("#structList");
    const $rowsToSort = $tbody.children("tr:not(.total-row)");
    $tbody.sortable({
        items: $rowsToSort,
        placeholder: "placeholder",
        helper: fixWidthHelper,
        update: function(event, ui) {
            const newOrder = $tbody.children("tr:not(.total-row)").map(function() {
                return tempStructList.find(s => s.id === $(this).find('.delete-struct').data('struct-id'));
            }).get();
            tempStructList = newOrder;
            renderStructList(); // Re-render to update indices
        }
    });
}

function fixWidthHelper(e, ui) {
    ui.children().each(function () {
        $(this).width($(this).width());
    });
    return ui;
}

// Lấy danh sách cấu trúc chi tiết từ API
function getListStructDetail(skillId, skillName) {
    $.ajax({
        url: `https://localhost:7001/api/examStructDetail/${structId}/${skillName}`,
        type: 'GET',
        xhrFields: { withCredentials: true },
        success: function(response) {
            tempStructList = response.map(item => ({
                id: item.id,
                questionTypeId: item.questionTypeId,
                questionTypeName: item.questionTypeName,
                score: item.score,
                amount: item.amount,
                examStructId: item.examStructId,
                skill: item.skill
            }));
            initialStructList = [...tempStructList];
            renderStructList();
        },
        error: function(error) {
            console.error('Error loading struct details:', error.responseText);
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: 'Không thể tải danh sách cấu trúc chi tiết',
            });
        }
    });
}

$(document).ready(function() {
    let userId = '';

    // Cập nhật dropdown điểm khi thay đổi loại câu hỏi
    $('#listQuestionType').on('change', function() {
        updateScoreDropdown();
    });

    // Reset modal khi mở
    $('#addStructModal').on('show.bs.modal', function(event) {
        $('#addStructModalLabel').text('Thêm cấu trúc mới');
        $('#listQuestionType').val('');
        $('#score').val('');
        $('#amount').val('');
        $('#saveStruct').removeData('struct-id');
        updateQuestionTypeDropdown();
    });

    // Tải danh sách kỹ năng
    $.ajax({
        url: `https://localhost:7001/api/skill/bank-id/${bankId}`,
        type: 'GET',
        xhrFields: { withCredentials: true },
        success: function(response) {
            listSkill = response;
            skillName = response[0].name;
            response.forEach(s => {
                $('#listSkill').append(
                    `<option value="${s.id}">${s.name}</option>`
                );
            });
            const skillId = $('#listSkill').val();
            setOptionModel(skillId);
            getListStructDetail(skillId, skillName);
        },
        error: function(error) {
            console.error('Error loading skills:', error.responseText);
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: 'Không thể tải danh sách kỹ năng',
            });
        }
    });

    // Xử lý thay đổi kỹ năng
    $('#listSkill').on('change', function() {
        const skillId = $(this).val();
        const selectedSkill = listSkill.find(s => s.id === skillId);
        skillName = selectedSkill ? selectedSkill.name : '';
        tempStructList = [];
        initialStructList = [];
        getListStructDetail(skillId, skillName);
        setOptionModel(skillId);
    });

    // Tải user ID
    $.ajax({
        url: `https://localhost:7001/api/user/user-id`,
        type: 'GET',
        xhrFields: { withCredentials: true },
        success: function(response) {
            userId = response;
        },
        error: function(error) {
            console.error('Error loading user ID:', error.responseText);
        }
    });

    // Xử lý lưu cấu trúc
    $('#saveStruct').on('click', function() {
        const questionTypeId = $('#listQuestionType').val();
        const score = $('#score').val();
        const amount = $('#amount').val().trim();

        // Kiểm tra hợp lệ
        if (!questionTypeId) {
            Swal.fire({
                icon: 'warning',
                title: 'Cảnh báo',
                text: 'Vui lòng chọn loại câu hỏi',
            });
            return;
        }
        if (!score) {
            Swal.fire({
                icon: 'warning',
                title: 'Cảnh báo',
                text: 'Vui lòng chọn số điểm',
            });
            return;
        }
        if (!amount || parseInt(amount) <= 0) {
            Swal.fire({
                icon: 'warning',
                title: 'Cảnh báo',
                text: 'Vui lòng nhập số lượng hợp lệ',
            });
            return;
        }

        // Kiểm tra số lượng còn lại
        const selectedQuestionType = listQuestionType.find(qt => qt.id === questionTypeId);
        const usedAmount = tempStructList
            .filter(s => s.questionTypeId === questionTypeId && s.score == score)
            .reduce((sum, s) => sum + s.amount, 0);
        const availableCount = selectedQuestionType.questionTypeCounts[score] || 0;

        if (parseInt(amount) > availableCount) {
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: `Số lượng câu hỏi với điểm ${score} là ${availableCount} câu`,
            });
            return;
        }

        // Thêm mới
        selectedQuestionType.questionTypeCounts[score] -= parseInt(amount);
        tempStructList.push({
            id: `temp_${Date.now()}_${Math.random()}`,
            questionTypeId: questionTypeId,
            questionTypeName: selectedQuestionType ? selectedQuestionType.name : '',
            score: parseFloat(score),
            amount: parseInt(amount),
            examStructId: structId,
            skill: skillName
        });

        Swal.fire({
            icon: 'success',
            title: 'Thành công',
            text: 'Thêm cấu trúc tạm thời thành công',
        });
        $('#addStructModal').modal('hide');
        $('#listQuestionType').val('');
        $('#score').val('');
        $('#amount').val('');
        renderStructList();
        updateQuestionTypeDropdown();
    });

    // Xử lý xóa cấu trúc
    $(document).on('click', '.delete-struct', function() {
        const structDetailId = $(this).data('struct-id');
        const questionTypeId = $(this).data('question-type-id');
        const score = $(this).data('score');
        const amount = $(this).data('amount');
        const questionTypeName = $(this).data('question-type-name');

        Swal.fire({
            title: 'Xác nhận xóa',
            text: `Bạn có chắc chắn muốn xóa cấu trúc "${questionTypeName}" không?`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#2563eb',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Xóa',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                const selectedQuestionType = listQuestionType.find(qt => qt.id === questionTypeId);
                if (selectedQuestionType && selectedQuestionType.questionTypeCounts[score] !== undefined) {
                    selectedQuestionType.questionTypeCounts[score] += parseInt(amount);
                }
                tempStructList = tempStructList.filter(s => s.id !== structDetailId);
                Swal.fire({
                    icon: 'success',
                    title: 'Thành công',
                    text: 'Xóa cấu trúc tạm thời thành công',
                });
                renderStructList();
                updateQuestionTypeDropdown();
            }
        });
    });

    // Xử lý lưu tất cả vào API
    $('#saveAllStruct').on('click', function() {
        if (tempStructList.length === 0) {
            Swal.fire({
                icon: 'warning',
                title: 'Cảnh báo',
                text: 'Không có cấu trúc nào để lưu',
            });
            return;
        }

        let isValid = true;
        listQuestionType.forEach(qt => {
            for (let score in qt.questionTypeCounts) {
                const usedAmount = tempStructList
                    .filter(s => s.questionTypeId === qt.id && s.score == score)
                    .reduce((sum, s) => sum + s.amount, 0);
                const originalCount = qt.questionTypeCounts[score] + usedAmount;
                if (usedAmount > originalCount) {
                    isValid = false;
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: `Số lượng câu hỏi cho "${qt.name}" với điểm ${score} (${usedAmount}) vượt quá số lượng khả dụng (${originalCount})`,
                    });
                }
            }
        });

        if (!isValid) return;

        const data = tempStructList.map((s, index) => ({
            Order: index + 1,
            ExamStructId: structId,
            QuestionTypeId: s.questionTypeId,
            Score: s.score,
            Amount: s.amount,
            Skill: s.skill
        }));

        $.ajax({
            url: `https://localhost:7001/api/examStructDetail`,
            type: 'POST',
            xhrFields: { withCredentials: true },
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function() {
                Swal.fire({
                    icon: 'success',
                    title: 'Thành công',
                    text: 'Lưu tất cả cấu trúc thành công',
                    timer: 1500,
                    showConfirmButton: false
                }).then(() => {
                    window.location.reload();
                });
            },
            error: function(error) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: error.responseText || 'Không thể lưu cấu trúc',
                });
            }
        });
    });
});
