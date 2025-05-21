export var sidebar = `
<ul class="nav flex-column">
                    <li class="nav-item mb-2">
                        <a class="nav-link active" id="menu-dashboard" href="trang-chu.html">
                            <i class="fas fa-home"></i>Trang chủ
                        </a>
                    </li>
                    <li class="nav-item mb-2">
                        <a class="nav-link" id="menu-question-type" href="dang-cau-hoi.html" >
                            <i class="fas fa-list-ul"></i>Quản lý dạng câu hỏi
                        </a>
                    </li>
                    <li class="nav-item mb-2">
                        <a class="nav-link" id="menu-question" href="#" onclick="toggleSubMenu(event)">
                            <i class="fas fa-tasks"></i>Quản lý câu hỏi
                            <i class="fas fa-chevron-down float-end"></i>
                        </a>
                        <ul class="nav flex-column ms-3 mt-2 d-none" id="submenu-question">
                            <li class="nav-item mb-1">
                                <a class="nav-link" id="menu-add-question" href="them-cau-hoi.html">
                                    <i class="fas fa-plus-circle"></i>Thêm câu hỏi
                                </a>
                            </li>
                            
                            <li class="nav-item mb-1">
                                <a class="nav-link" id="menu-pending-questions" href="cho-duyet.html" >
                                    <i class="fas fa-clock"></i>Câu hỏi chờ duyệt
                                </a>
                            </li>
                            <li class="nav-item mb-1">
                                <a class="nav-link" id="menu-rejected-questions" href="bi-tu-choi.html">
                                    <i class="fas fa-times-circle"></i>Câu hỏi bị từ chối
                                </a>
                            </li>
                             <li class="nav-item mb-1">
                                <a class="nav-link" id="menu-approved-questions" href="da-duyet.html" >
                                    <i class="fas fa-check-circle"></i>Câu hỏi đã duyệt
                                </a>
                            </li>
                            <li class="nav-item mb-1">
                                <a class="nav-link" id="menu-used-questions" href="da-dung.html">
                                    <i class="fas fa-play-circle"></i>Câu hỏi đã dùng
                                </a>
                            </li>
                        </ul>
                    </li>
                    
                </ul>
`