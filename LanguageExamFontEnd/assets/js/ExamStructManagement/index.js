
        var examId = null
        // Handle menu navigation
        const links = document.querySelectorAll('.sidebar a');
        const sections = document.querySelectorAll('main section');

        links.forEach(link => {
            link.addEventListener('click', (e) => {
                e.preventDefault();
                const targetId = link.getAttribute('href').substring(1);

                sections.forEach(section => section.classList.add('hidden'));
                document.getElementById(targetId).classList.remove('hidden');

                links.forEach(l => l.classList.remove('active'));
                link.classList.add('active');
            });
        });

        function formatDate(input) {
            const parts = input.split('-');
            const year = parts[0];
            const month = parts[1];
            const day = parts[2];
            return `${day}-${month}-${year}`;
        }

        async function HasQuestion(id) {
            var check = null;
           await $.ajax({
                url: `https://localhost:7001/api/exam/is-create/${id}`,
                type: 'GET',
                xhrFields: { withCredentials: true },
                success: function(response) {
                    check = response
                },
                error: function(error) {
                    console.error('Error loading check:', error.responseText);
                }
            });
            return check
        }
        $(document).ready( async function() {
            var userId = '';
            var bankId = '';

            
            // Reset modal state when it is shown
            $('#addStructModal').on('show.bs.modal', function(event) {
                const button = $(event.relatedTarget); // Button that triggered the modal
                const isEdit = button.hasClass('edit-struct'); // Check if triggered by edit button

                if (isEdit) {
                    // Edit mode
                    const structId = button.data('struct-id');
                    const structName = button.data('struct-name');
                    $('#addStructModalLabel').text('Sửa cấu trúc');
                    $('#structName').val(structName);
                    $('#saveStruct').text('Cập nhật').data('struct-id', structId);
                } else {
                    // Add new mode
                    $('#addStructModalLabel').text('Thêm cấu trúc mới');
                    $('#structName').val('');
                    $('#saveStruct').text('Lưu').removeData('struct-id');
                }
            });

            // Load user ID
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

            // Load exam info
            $.ajax({
                url: `https://localhost:7001/api/exam/create-exam`,
                type: 'GET',
                xhrFields: { withCredentials: true },
                success: function(response) {
                    examId = response.id
                    $('#examName').text(response.name);
                    $('#dueDate').text(formatDateTime(response.createQuestionDue));
                },
                error: function(error) {
                    console.error('Error loading exam:', error.responseText);
                }
            });

            // Load question banks
            $.ajax({
                url: `https://localhost:7001/api/QuestionBank`,
                type: 'GET',
                xhrFields: { withCredentials: true },
                success: function(response) {
                    response.forEach(q => {
                        var status = null
                        if(q.status == 0) { status = 'Đang tạo'}
                        else if(q.status == 1) { status = 'Đang hoạt động'}
                        else { status = 'Đã khóa'}
                        $('#listBank').append(
                            `<option value='${q.id}_${q.status}'>${q.name} (${q.language}) (${status})</option>`
                        );
                    });
                },
                error: function(error) {
                    console.error('Error loading question banks:', error.responseText);
                }
            });

            // Fetch exam structures based on selected question bank
            async function FetchExamStruct(bankId) {
                var hasQuestion = true
                if(examId != null) {
                    hasQuestion = await HasQuestion(examId)
                }
                
                console.log(bankId);
                $('#structList').empty();
                if (bankId) {
                    $.ajax({
                        url: `https://localhost:7001/api/ExamStruct/${bankId}`,
                        type: 'GET',
                        xhrFields: { withCredentials: true },
                        success: function(response) {
                            if (response.length === 0) {
                                $('#structList').append(`
                                    <tr>
                                        <td colspan="2" class="text-center text-gray-600">Không có cấu trúc nào</td>
                                    </tr>
                                `);
                                return;
                            }
                            response.forEach(s => {
                                $('#structList').append(`
                                    <tr>
                                        <td>${s.name}</td>
                                        <td>
                                            <button class="btn btn-sm btn-info"><a class="text-white text-decoration-none"
                                                href="exam-struct-detail.html?structId=${s.id}&bankId=${bankId}"
                                                >Chi tiết</a></button>
                                            <button class="btn btn-sm btn-warning edit-struct" 
                                                ${s.userCreateId !== userId ? ' style="display: none"' : ''} 
                                                data-struct-id='${s.id}' 
                                                data-struct-name='${s.name}' 
                                                data-bs-toggle='modal' 
                                                data-bs-target='#addStructModal'>Sửa</button>
                                            <button class="btn btn-sm btn-danger delete-struct" 
                                                ${s.userCreateId !== userId ? ' style="display: none"' : ''} 
                                                data-struct-id='${s.id}' 
                                                data-struct-name='${s.name}'>Xóa</button>
                                            <button class="btn btn-sm btn-success btn-create"  
                                                id="btn-create"
                                                data-struct-id='${s.id}' 
                                                ${examId === null &&  hasQuestion ? ' style="display: none"' : ''}
                                                data-struct-name='${s.name}'>Tạo đề</button>
                                        </td>
                                    </tr>
                                `);
                            });
                        },
                        error: function(error) {
                            console.error('Error loading structures:', error.responseText);
                            Swal.fire({
                                icon: 'error',
                                title: 'Lỗi',
                                text: 'Không thể tải danh sách cấu trúc',
                            });
                        }
                    });
                }
            }

            $(document).on('click', '.btn-create', async function() {
                console.log(359)
                await $.ajax({
                    url: 'https://localhost:7001/api/examQuestionDetail',
                    type: 'POST',
                    contentType: 'application/json',
                    xhrFields: { withCredentials: true},
                    data: JSON.stringify({
                        ExamId: examId,
                        ExamStructId: $(this).data('struct-id')
                    }),
                    success: function(response) {
                            Swal.fire({
                                title: 'Thành công!',
                                text: 'Tạo đề thành công.',
                                icon: 'success',
                                confirmButtonText: 'OK'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    // Hành động sau khi nhấn OK
                                    // Ví dụ: chuyển hướng trang
                                   // window.location.href = 'https://example.com';
                                    
                                    // Hoặc gọi hàm khác
                                    // doSomethingElse();
                                }
    });
                    }, 
                    error: function(error) {
                        console.log(error.responseText)
                    }

                })
            })
            // Handle question bank selection
            $('#listBank').on('change', function() {
                let [bankId, status] = $(this).val().split("_");
                console.log(status)
                if(status == 1) {
                    FetchExamStruct(bankId);
                }
                
            });

            // Handle delete structure
            $(document).on('click', '.delete-struct', function() {
                const structId = $(this).data('struct-id');
                const structName = $(this).data('struct-name');

                Swal.fire({
                    title: 'Xác nhận xóa',
                    text: `Bạn có chắc chắn muốn xóa cấu trúc "${structName}" không?`,
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#2563eb',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Xóa',
                    cancelButtonText: 'Hủy'
                }).then((result) => {
                    if (result.isConfirmed) {
                        $.ajax({
                            url: `https://localhost:7001/api/ExamStruct/${structId}`,
                            type: 'DELETE',
                            xhrFields: { withCredentials: true },
                            success: function() {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Thành công',
                                    text: 'Xóa cấu trúc thành công',
                                });
                                $('#listBank').trigger('change'); // Refresh list
                            },
                            error: function(error) {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Lỗi',
                                    text: error.responseText || 'Không thể xóa cấu trúc',
                                });
                            }
                        });
                    }
                });
            });

            // Handle save structure (add or edit)
            $('#saveStruct').on('click', function() {
                const structName = $('#structName').val().trim();
                const bankId = $('#listBank').val();
                const structId = $(this).data('struct-id'); // Get structId if editing

                if (!structName) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Cảnh báo',
                        text: 'Vui lòng nhập tên cấu trúc',
                    });
                    return;
                }

                if (!bankId) {
                    Swal.fire({
                        icon: 'warning',
                        title: 'Cảnh báo',
                        text: 'Vui lòng chọn ngân hàng đề',
                    });
                    return;
                }

                const isEdit = !!structId; // Check if in edit mode
                const url = `https://localhost:7001/api/ExamStruct`;
                const method = isEdit ? 'PUT' : 'POST';

                const data = isEdit ? {
                    Name: structName,
                    Id: structId,
                } : {
                    Name: structName,
                    QuestionBankId: bankId,
                };

                $.ajax({
                    url: url,
                    type: method,
                    xhrFields: { withCredentials: true },
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    success: function() {
                        Swal.fire({
                            icon: 'success',
                            title: 'Thành công',
                            text: isEdit ? 'Cập nhật cấu trúc thành công' : 'Thêm cấu trúc thành công',
                        });
                        $('#addStructModal').modal('hide');
                        $('#structName').val('');
                        $('#saveStruct').text('Lưu').removeData('struct-id'); // Reset button
                        $('#addStructModalLabel').text('Thêm cấu trúc mới'); // Reset title
                        $('#listBank').trigger('change'); // Refresh list
                    },
                    error: function(error) {
                        Swal.fire({
                            icon: 'error',
                            title: 'Lỗi',
                            text: error.responseText || (isEdit ? 'Không thể cập nhật cấu trúc' : 'Không thể thêm cấu trúc'),
                        });
                    }
                });
            });
        });
    
function formatDateTime(dateString) {
    const date = new Date(dateString);
    const formatted = new Intl.DateTimeFormat('vi-VN', {
    year: 'numeric', month: '2-digit', day: '2-digit',
    hour: '2-digit', minute: '2-digit', second: '2-digit',
    hour12: false
    }).format(date);
    return formatted;
}

window.addEventListener("pageshow", function (event) {
        if (event.persisted || (window.performance && performance.getEntriesByType("navigation")[0].type === "back_forward")) {
            // Nếu quay lại bằng nút Back hoặc Forward → Reload lại
            window.location.reload();
        }
    });