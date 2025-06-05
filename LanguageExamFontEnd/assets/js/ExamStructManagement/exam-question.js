 
        var examId = null;
        var listQuestion = []

        // Handle menu navigation
        const links = document.querySelectorAll('.sidebar a');
        const sections = document.querySelectorAll('main section');

        // Function to render questions
        async function renderQuestions(skill) {
            const examQuestionDiv = $('#examQuestion');
            examQuestionDiv.empty();
            var list = listQuestion[skill]
            console.log('128', skill)
            if(list != null) {
            const keys = Object.keys(list);
            // B2: Chuyển sang số và sắp xếp tăng dần
            keys.sort((a, b) => Number(a) - Number(b));
            

            // B3: Duyệt theo thứ tự đã sắp xếp
            var index = 1;
            for (const key of keys) {
                var listContent = list[key]
                var questionTypeName = await GetQuestionTypeName(listContent[0].id)
                console.log('138', listContent)
                examQuestionDiv.append(`
                    <div class="text-lg font-semibold text-gray-800 mb-4">Dạng câu hỏi: ${questionTypeName}</div>
                `);
                
                listContent.forEach((contentBlock) => {
                    let questionHtml = `
                        <div class="col-12 mt-4">
                            <div class="card">
                                <div class="card-body">
                                    <!-- Media Section -->
                                    <div class="card-header bg-white" ${contentBlock.isSingle == false ? 'style="display: none;"' : ''}>
                                        <div class="d-flex justify-content-between align-items-center">
                                            <h5 class="mb-0">Câu hỏi ${contentBlock.isSingle == false ? '' : index++}</h5>
                                        </div>
                                    </div>   
                                    <div class="row mb-4">
                                        <div class="col-md-4">
                                            ${contentBlock.imageBase64 ? `<img src="data:image/jpeg;base64,${contentBlock.imageBase64}" alt="Question Image" class="media-preview mb-3">` : ''}
                                        </div>
                                        <div class="col-md-8">
                                            ${contentBlock.audioBase64 ? `<audio controls class="audio-preview mb-3"><source src="data:audio/mpeg;base64,${contentBlock.audioBase64}" type="audio/mpeg">Your browser does not support the audio element.</audio>` : ''}
                                        </div>
                                    </div>

                                    <!-- Question Content -->
                                    <div class="mb-4 d-flex">
                                        <h6 class="fw-bold mr-2">Nội dung câu hỏi:</h6>
                                        <p>${contentBlock.content || 'Nội dung không có'}</p>
                                    </div>

                                    <div class="mb-3">
                                        
                                        <div class="list-group">
                                            ${contentBlock.questions && Array.isArray(contentBlock.questions) ? contentBlock.questions.map((question, quesIndex) => `
                                            <div class="card-header bg-white" ${contentBlock.isSingle == true ? 'style="display: none;"' : ''}>
                                                <div class="d-flex justify-content-between align-items-center">
                                                    <h5 class="mb-0">Câu hỏi ${contentBlock.isSingle == true ? '' : index++}</h5>
                                                </div>
                                            </div>   
                                            <h6 class="fw-bold mb-3" ${question.content ? '': 'style="display: none;"'}>Câu hỏi: ${question.content}</h6>
                                               <div class="mb-3">
                                                <div class="list-group">
                                                    ${question.answers && Array.isArray(question.answers) ? question.answers.map((answer, ansIndex) => `
                                                        <div class="list-group-item answer-option ${answer.isCorrect === true ? 'correct-answer' : ''}">
                                                            <div class="d-flex align-items-center">
                                                                <div class="me-3">${String.fromCharCode(65 + ansIndex)}</div>
                                                                <div>${answer.content || 'Đáp án trống'}</div>
                                                                ${answer.isCorrect === true  ? '<div class="ms-auto"><span class="badge bg-success">Đáp án đúng</span></div>' : ''}
                                                            </div>
                                                        </div>
                                                    `).join('') : '<p>Không có đáp án</p>'}
                                        </div>
                                    </div>
                                            `).join('') : '<p>Không có câu hỏi</p>'}
                                        </div>
                                    </div>

                                    <!-- Answer Options -->
                                    
                                </div>
                            </div>
                        </div>
                    `;
                    examQuestionDiv.append(questionHtml);
                });
            
            }  
        }  
        }

        async function GetExamQuestion(examId) {
            await $.ajax({
                url: `https://localhost:7001/api/examQuestionDetail/${examId}`,
                type: 'GET',
                xhrFields: { withCredentials: true },
                success: function(response) {
                    listQuestion = response
                },
                error: function(error) {
                    console.error('Error loading check:', error.responseText);
                    $('#examQuestion').html('<p>Lỗi khi tải dữ liệu</p>');
                }
            });
        }

        async function GetQuestionTypeName(contentId) {
            var name = ''
            await $.ajax({
                url: `https://localhost:7001/api/contentBlock/question-type/${contentId}`,
                type: 'GET',
                xhrFields: { withCredentials: true },
                success: function(response) {
                    name = response
                },
                error: function(error) {
                    console.error('Error loading check:', error.responseText);
                    $('#examQuestion').html('<p>Lỗi khi tải dữ liệu</p>');
                }
            });
            return name
        }
        async function GetExam() {
            var examId = null;
            await $.ajax({
                url: `https://localhost:7001/api/exam/create-exam`,
                type: 'GET',
                xhrFields: { withCredentials: true },
                success: function(response) {
                    examId = response.id;
                },
                error: function(error) {
                    console.error('Error loading check:', error.responseText);
                }
            });
            return examId;
        }

        async function Confirm(examId) {
            
            await $.ajax({
                url: `https://localhost:7001/api/exam/confirm/${examId}`,
                type: 'GET',
                xhrFields: { withCredentials: true },
                success: function(response) {
                    Swal.fire({
                    title: 'Thành công!',
                    text: 'Tạo đề thi thành công',
                    icon: 'success',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Hành động sau khi nhấn OK
                        // Ví dụ: chuyển hướng trang
                        window.location.href = 'index.html';
                        
                        // Hoặc gọi hàm khác
                        // doSomethingElse();
                    }
                });
                },
                error: function(error) {
                    console.error('Error loading check:', error.responseText);
                }
            });
            
        }
        $(document).ready(async function() {
            var examId = await GetExam();
            if (examId) {
                await GetExamQuestion(examId);
                renderQuestions('đọc')
            }
            $('#selectSkill').on('change', function() {
                $('#examQuestion').empty()
                renderQuestions($(this).val())
            })

            $('#btnConfirm').on('click', async function() {
                await Confirm(examId)
            })
        });
   