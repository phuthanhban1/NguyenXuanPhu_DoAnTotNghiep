var dateFormat = function() {
    $('.type-date').datepicker({
        format: "dd/mm/yyyy",
        language: "vi",
        orientation: "bottom auto",
        endDate: '+0d',
        autoclose: true,
    });
}

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
            withCredentials: true
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

