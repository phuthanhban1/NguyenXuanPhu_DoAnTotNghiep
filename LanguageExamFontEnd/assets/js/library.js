// format date input
var dateFormat = function() {
    $('.type-date').datepicker({
        format: "dd/mm/yyyy",
        language: "vi",
        orientation: "bottom auto",
        endDate: '+0d',
        autoclose: true,
    });
}

// convert 2000-01-10 -> 10-01-2000
function formatDate(input) {
    const parts = input.split('-'); // ['0001', '01', '01']
    const year = parts[0];
    const month = parts[1];
    const day = parts[2];

    return `${day}-${month}-${year}`; // '01-01-0001'
}

function showSuccessAndRedirect(text) {
    Swal.fire({
        title: 'Thành công!',
        text: text,
        icon: 'success',
        confirmButtonText: 'OK',
        timer: 2000
    }).then((result) => {
        if (result.isConfirmed) {
            // Hành động sau khi nhấn OK
            // Ví dụ: chuyển hướng trang
            window.location.href = 'https://example.com';
            
            // Hoặc gọi hàm khác
            // doSomethingElse();
        }
    });
}
function confirmDelete() {
    Swal.fire({
      title: 'Bạn có chắc chắn muốn xóa?',
      text: "Hành động này không thể hoàn tác!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      cancelButtonColor: '#3085d6',
      confirmButtonText: 'Vâng, xóa đi!',
      cancelButtonText: 'Hủy'
    }).then((result) => {
      if (result.isConfirmed) {
        // Gọi hàm xóa hoặc xử lý tại đây
        Swal.fire(
          'Đã xóa!',
          'Mục đã được xóa thành công.',
          'success'
        );
      }
    });
  }
export async function checkAuthorize() {
    // console.log(1)
    var check = true;
    await $.ajax({
        url: `https://localhost:7001/api/user/authorize`,
        type: 'GET',
        xhrFields: {
            withCredentials: false
        },
        success: function(response) {
            check = true
        },
        error: function(error) {
            check = false
        }
    });
    
    return check
}

export async function getApi(url, data = '') {
    var result = null;
    await $.ajax({
        url: `https://localhost:7001/api/${url}/${data}`,
        type: 'GET',
        xhrFields: {
            withCredentials: true
        },
        success: function(response) {
            result = response
        },
        error: function(error) {
            result = null
            console.log('error get: ', error.responseText)
        }
    });
    
    return result
}

export function formatDateTime(dateString) {
    const date = new Date(dateString);
    const formatted = new Intl.DateTimeFormat('vi-VN', {
    year: 'numeric', month: '2-digit', day: '2-digit',
    hour: '2-digit', minute: '2-digit', second: '2-digit',
    hour12: false
    }).format(date);
    return formatted;
}
export function genFooter($parent) {
  $parent.append(`
    <style>
      .site-footer {
      background-color: #1a2a44;
      color: #fff;
      box-shadow: 0 -2px 4px rgba(0, 0, 0, 0.1);
    }

    .footer-main {
      background-image: url('https://iigvietnam.com/wp-content/themes/main/assets/images/common/footer-bg.png');
      background-size: cover;
      background-position: center;
      padding: 30px 0;
    }

    .footer-main .container {
      max-width: 1200px;
      margin: 0 auto;
      padding: 0 30px;
    }

    .footer-main .content_common.row {
      display: flex;
      flex-wrap: wrap;
      gap: 20px;
      justify-content: space-between;
    }

    .footer-main .col-4 {
      flex: 1.5;
      min-width: 220px;
      padding: 15px;
      display: flex;
      flex-direction: column;
    }

    .footer-main ._label {
      display: flex;
      align-items: center;
      font-family: 'Lora', serif;
      font-size: 15px;
      font-weight: 700;
      color: #fff;
      margin-bottom: 15px;
      text-transform: uppercase;
    }

    .footer-main ._label svg {
      margin-right: 10px;
      flex-shrink: 0;
    }

    .footer-main ._title {
      font-size: 14px;
      font-weight: 500;
      color: #f4a261;
      margin-bottom: 8px;
      text-transform: uppercase;
    }

    .footer-main ._content p,
    .footer-main ._content a {
      font-size: 14px;
      line-height: 1.6;
      color: #a3bffa;
      margin-bottom: 10px;
      text-decoration: none;
    }

    .footer-main ._content a:hover {
      color: #f4a261;
      text-decoration: underline;
    }

    .footer-main ._bottom {
      text-align: center;
      padding: 15px 0;
      font-size: 14px;
      color: #a3bffa;
      border-top: 1px solid rgba(255, 255, 255, 0.1);
      margin-top: 20px;
    }

    .footer-main ._bottom a {
      color: #a3bffa;
      text-decoration: none;
    }

    .footer-main ._bottom a:hover {
      color: #f4a261;
      text-decoration: underline;
    }
    </style>
    <footer id="site-footer" class="site-footer">
    <div class="footer-main">
      <div class="_top">
        <div class="container">
          <div class="content_common row">
            <div class="col-4">
              <div class="_label">
                <svg width="17" height="17" viewBox="0 0 17 17" fill="none">
                  <path d="M8.49212 0C5.10041 0 2.34106 2.7619 2.34106 6.15672C2.34106 10.3698 7.84566 16.5548 8.08002 16.8161C8.30015 17.0615 8.68449 17.0611 8.90422 16.8161C9.13859 16.5548 14.6432 10.3698 14.6432 6.15672C14.6431 2.7619 11.8838 0 8.49212 0ZM8.49212 9.25434C6.78567 9.25434 5.3974 7.86476 5.3974 6.15672C5.3974 4.44869 6.7857 3.05914 8.49212 3.05914C10.1985 3.05914 11.5868 4.44872 11.5868 6.15676C11.5868 7.86479 10.1985 9.25434 8.49212 9.25434Z" fill="#43A2FF"/>
                </svg>
                Địa chỉ văn phòng
              </div>
              <div class="_content">
                <div style="margin-bottom: 20px;">
                  <p class="_title">TRỤ SỞ CHÍNH</p>
                  <p><a href="https://goo.gl/maps/1KZ3Df1Ef9cdK4AC6" target="_blank">75 Giang Văn Minh, Q. Ba Đình, Hà Nội</a></p>
                </div>
                <div>
                  <p class="_title">ĐỊA ĐIỂM ĐĂNG KÝ THI TẠI HÀ NỘI</p>
                  <p><a href="https://maps.app.goo.gl/8hZ27jFzzK8D8geMA" target="_blank">Đại học Công nghiệp Hà Nội</a></p>
                </div>
              </div>
            </div>
            <div class="col-4">
              <div class="_label">
                <svg width="17" height="13" viewBox="0 0 17 13" fill="none">
                  <path d="M15.5703 0H0.576416L8.07336 6.48401L15.6551 0.0181659C15.6273 0.00965066 15.599 0.0035835 15.5703 0Z" fill="#43A2FF"/>
                  <path d="M8.4375 7.73573C8.22502 7.91841 7.91932 7.91841 7.70685 7.73573L0 1.06885V11.5045C0 11.839 0.258191 12.1101 0.576698 12.1101H15.5706C15.8891 12.1101 16.1473 11.839 16.1473 11.5045V1.15847L8.4375 7.73573Z" fill="#43A2FF"/>
                </svg>
                Địa chỉ Email
              </div>
              <div class="_content">
                <a href="mailto:info@iigvietnam.edu.vn">info@iigvietnam.edu.vn</a>
              </div>
              <div class="_label" style="margin-top: 20px;">
                <svg width="14" height="13" viewBox="0 0 14 13" fill="none">
                  <path d="M13.6861 10.2824L11.5241 8.26995C11.0934 7.87077 10.3803 7.8829 9.93461 8.2978L8.84534 9.31133C8.77653 9.27603 8.70529 9.23916 8.6304 9.20004C7.94254 8.84533 7.00109 8.35915 6.0104 7.43648C5.01678 6.51185 4.49391 5.63431 4.11161 4.99373C4.07127 4.92586 4.03262 4.86043 3.99445 4.79829L4.7255 4.11893L5.08492 3.78401C5.53125 3.36851 5.54356 2.70498 5.11392 2.30464L2.95184 0.291991C2.52219 -0.107791 1.80871 -0.0956627 1.36238 0.319841L0.753032 0.890203L0.769684 0.905588C0.565361 1.14823 0.394623 1.42807 0.267564 1.72986C0.150441 2.01712 0.0775199 2.29123 0.0441767 2.56592C-0.241312 4.76861 0.840232 6.7817 3.7754 9.51343C7.8327 13.2892 11.1023 13.004 11.2434 12.99C11.5506 12.9559 11.845 12.8875 12.1442 12.7794C12.4657 12.6625 12.7662 12.5039 13.0267 12.3141L13.04 12.3251L13.6573 11.7625C14.1028 11.3471 14.1156 10.6834 13.6861 10.2824Z" fill="#43A2FF"/>
                </svg>
                Liên hệ với chúng tôi qua
              </div>
              <div class="_content d-flex">
                <p class="_title me-3">Hotline:</p>
                <p><a href="javascript:void(0)" class="_phone">1900 636 929</a></p>
              </div>
            </div>
            <div class="col-4">
              <div class="_label">
                Thời gian làm việc
              </div>
              <div class="_content d-flex">
                <p class="me-3">
                  <strong class="_title">Sáng: 08:00 - 12:00</strong><br>
                  (Thứ Hai - thứ Bảy)
                </p>
                <p>
                  <strong class="_title">Chiều: 13:30 - 17:30</strong><br>
                  (Thứ Hai - Thứ Sáu)
                </p>
              </div>
              <img src="assets/logo_update.svg" style="width: 140px;">
            </div>
          </div>
        </div>
      </div>
    </div>
    
  </footer>
    
  `)
}
export async function genHeader($parent) {
  const $child = $(`
  <div class="w-100">
      <style>
        .header-library {
      background-color: #1a2a44;
      color: #fff;
      padding: 10px 30px;
      display: flex;
      justify-content: space-between;
      align-items: center;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }

    .header-library .contact {
      font-size: 14px;
      color: #a3bffa;
    }

    .header-library .search-bar button:hover {
      background-color: #e07a5f;
    }

    .header-library .buttons button {
      padding: 8px 20px;
      margin-left: 10px;
      border: none;
      border-radius: 4px;
      cursor: pointer;
      font-family: 'Lora', serif;
      font-size: 14px;
      font-weight: 700;
      transition: background-color 0.3s;
    }

    .header-library .buttons .register {
      background-color: #f4a261;
      color: #fff;
    }

    .header-library .buttons .register:hover {
      background-color: #e07a5f;
    }

    .header-library .buttons .login {
      background-color: #2a9d8f;
      color: #fff;
    }

    .header-library .buttons .login:hover {
      background-color: #218c81;
    }
      .header-library .user-section {
    display: flex;
    align-items: center;
    gap: 12px;
  }

  .header-library .dropdown-toggle {
    display: flex;
    align-items: center;
    gap: 8px;
    cursor: pointer;
    background: none;
    border: none;
    padding: 0;
  }

  .header-library .user-avatar {
    width: 36px;
    height: 36px;
    border-radius: 50%;
    object-fit: cover;
    border: 1px solid #a3bffa;
    transition: border-color 0.3s;
  }

  .header-library .user-avatar:hover {
    border-color: #f4a261;
  }

  .header-library .user-name {
    font-family: 'Roboto', sans-serif;
    font-size: 14px;
    font-weight: 500;
    color: #fff;
    transition: color 0.3s;
  }

  .header-library .user-name:hover {
    color: #f4a261;
  }

  .header-library .dropdown-menu {
    background-color: #fff;
    border: none;
    border-radius: 4px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
    margin-top: 5px;
    min-width: 160px;
    display: none;
  }

  .header-library .dropdown-menu.show {
    display: block;
  }

  .header-library .dropdown-item {
    font-family: 'Lora', serif;
    font-size: 14px;
    font-weight: 400;
    color: #1a2a44;
    padding: 10px 15px;
    transition: background-color 0.3s, color 0.3s;
  }

  .header-library .dropdown-item:hover {
    background-color: #f4a261;
    color: #fff;
  }
      </style>
  <header class="header-library">
      <div class="contact">☎ 1900 636 929</div>
      <div class=""> 
          <div class="buttons">
              <a href="/login.html"><button class="register">Đăng nhập</button></a>
              <a href="Register/register.html"><button class="login">Đăng ký</button></a>
          </div>
          <div class="user-section"></div>
      </div>
  </header>
  </div>
  `);
  var user = await getApi('user/user')

  if(user != null) {
    $child.find('.buttons').hide()
    $child.find('.user-section').append(`
      <div class="dropdown">
        <div class="dropdown-toggle d-flex justify-content-center" id="userDropdown" data-bs-toggle="dropdown" aria-expanded="false">
          <img src="data:image/*;base64,${user.imageFaceBase64}" alt="Image" class="user-avatar mr-3"
          ${user.imageFaceBase64 ? '' : 'style="display: none;"'}>
          <span class="user-name">${user.email}</span>
        </div>
        <div>
          <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="userDropdown">
            <li id="profile"><a class="dropdown-item">Thông tin cá nhân</a></li>
            <li><button class="dropdown-item logout">Đăng xuất</button></li>
          </ul>
        </div>
        
      </div>
    `)

    $child.find('.logout').on('click', function() {
      $.ajax({
          url: 'https://localhost:7001/api/user/logout',
          type: 'POST',
          xhrFields: { withCredentials: true },
          success: function(response) {
            window.location.href = '../index.html'
          }
      })
    })

    $child.find('#profile').on('click', function() {
      $.ajax({
          url: 'https://localhost:7001/api/user/user',
          type: 'GET',
          xhrFields: { withCredentials: true },
          success: function(response) {
            if(response.idCard == null) {
              window.location.href = '../user-infor-add.html'
            } else {
              window.location.href = '../user-infor.html'
            }
          }
      })
    })
  }
  $parent.append($child)
}