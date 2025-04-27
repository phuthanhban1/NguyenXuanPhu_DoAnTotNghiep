$(document).ready(function() {
    // Lấy danh sách tỉnh/thành phố khi load trang
    $.ajax({
        url: 'https://localhost:7001/api/province', // Thay bằng endpoint thực tế của bạn
        method: 'GET',
        success: function(data) {
            var html = '<option selected disabled value="">Chọn</option>';
            data.forEach(function(city) {
                html += '<option value="' + city.id + '">' + city.name + '</option>';
            });
            $('#CityWork').html(html);
        },
        error: function() {
            $('#CityWork').html('<option value="">Không tải được</option>');
        }
    });

    // Khi chọn Tỉnh/Thành phố
    $('#CityWork').on('change', function() {
        var cityId = $(this).val();
        $('#DistrictWork').html('<option value="">Đang tải...</option>');
        $('#WardWork').html('<option value="">Chọn</option>');
        $.ajax({
            url: 'https://localhost:7001/api/district/province/' + cityId, // Thay bằng URL API thực tế
            method: 'GET',
            success: function(data) {
                var html = '<option value="">Chọn</option>';
                data.forEach(function(district) {
                    html += '<option value="' + district.id + '">' + district.name + '</option>';
                });
                $('#DistrictWork').html(html);
            },
            error: function() {
                $('#DistrictWork').html('<option value=\"\">Không tải được</option>');
            }
        });
    });

    // Khi chọn Quận/Huyện
    $('#DistrictWork').on('change', function() {
        var districtId = $(this).val();
        $('#WardWork').html('<option value="">Đang tải...</option>');
        $.ajax({
            url: 'https://localhost:7001/api/ward/district/' + districtId, // Thay bằng URL API thực tế
            method: 'GET',
            success: function(data) {
                var html = '<option value="">Chọn</option>';
                data.forEach(function(ward) {
                    html += '<option value="' + ward.id + '">' + ward.name + '</option>';
                });
                $('#WardWork').html(html);
            },
            error: function() {
                $('#WardWork').html('<option value=\"\">Không tải được</option>');
            }
        });
    });
    // crop image
    const maxSize = 512000; // 500KB
    const minSize = 10000;  // 10KB
    let $uploadCrop = null;
                // Initialize croppie
    $uploadCrop = $('#upload-demo').croppie({
        viewport: {
            width: 354,
            height: 472
        },
        boundary: {
            width: 400,
            height: 500
        },
        enableExif: true
    });
                // Handle image upload
    $('#Image3x4').on('change', function() {
        if (this.files && this.files[0]) {
            const file = this.files[0];
            var validator = $("#UserInfoForm").validate();
            // Check file size
            if (file.size > maxSize) {
                alert('Kích thước ảnh không được vượt quá 500KB');
                this.value = '';
                return;
            }
            if (file.size < minSize) {
                alert('Kích thước ảnh phải lớn hơn 10KB');
                this.value = '';
                return;
            }

            // Check file type
            if (!file.type.match('image/jpeg') && !file.type.match('image/jpg') && !file.type.match('image/png')) {
                alert('Vui lòng chọn file ảnh định dạng JPG, PNG hoặc JPEG');
                this.value = '';
                return;
            }

            // Destroy previous croppie instance if exists
            if ($uploadCrop) {
                $uploadCrop.croppie('destroy');
            }

            // If file is valid, show croppie
            var reader = new FileReader();
            reader.onload = function(e) {
                $uploadCrop = $('#upload-demo').croppie({
                    viewport: {
                        width: 354,
                        height: 472
                    },
                    boundary: {
                        width: 400,
                        height: 500
                    },
                    enableExif: true
                });
                $uploadCrop.croppie('bind', {
                    url: e.target.result
                });
                $('#cropImagePop').modal('show');

                validator.showErrors({ "ImageFace": null });
            }
            
            reader.readAsDataURL(file);

            
        }
    });
           // Handle close button click
    $('#closeModal').on('click', function() {
        $('#cropImagePop').modal('hide');
    });

                // Initialize datepicker
    $('.type-date').datepicker({
        format: "dd/mm/yyyy",
        language: "vi",
        orientation: "bottom auto",
        endDate: '+0d',
        autoclose: true,
    });
                // Form validation
    $("#UserInfoForm").validate({
        rules: {
            VietnameseName: {
                required: true,
                pattern: /^[a-zA-Z_ÀÁÂÃÈÉÊẾÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêếìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹý\ ]+$/
            },
            BirthDay: {
                required: true,
                pattern: /^\s*(3[01]|[12][0-9]|0?[1-9])\/(1[012]|0?[1-9])\/((?:19|20)\d{2})\s*$/
            },
            Gender: {
                required: true
            },
            Phone: {
                required: true,
                minlength: 10,
                maxlength: 10,
                number: true
            },
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true,
                minlength: 8
            },
            ConfirmPassword: {
                required: true,
                equalTo: "#Password"
            }
        },
        messages: {
            VietnameseName: {
                required: "Vui lòng nhập họ và tên thí sinh",
                pattern: "Tên không đúng định dạng"
            },
            BirthDay: {
                required: "Vui lòng nhập ngày sinh",
                pattern: "Vui lòng nhập đúng định dạng dd/mm/yyyy"
            },
            Gender: {
                required: "Vui lòng chọn giới tính"
            },
            Phone: {
                required: "Vui lòng nhập số điện thoại",
                minlength: "Số điện thoại phải đủ 10 số",
                number: "Vui lòng nhập đúng định dạng số diện thoại"
            },
            Email: {
                required: "Vui lòng nhập email",
                email: "Vui lòng nhập email đúng định dạng"
            }
        },
        errorPlacement: function(error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });          // Image upload preview
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function(e) {
                $(input).siblings('img').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }

                // Handle image uploads
    $('#IDCardFront, #IDCardBack, #Image3x4').change(function() {
        readURL(this);
    });

    // Handle form submission khi click button submit
    $('#SubmitProfile').click(function(e) {
        e.preventDefault();
        var validateUserInfo = $('#UserInfoForm').valid();
        var validateFile = ValidateFile();

        if (validateUserInfo && validateFile) {
            
                console.log('ok');
        
                e.preventDefault();
                console.log('ok2');
                var formData = new FormData($('#UserInfoForm')[0]);
                console.log(formData);
                $.ajax({
                    url: 'https://localhost:7001/api/user',
                    type: 'POST',
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function(response) {
                        console.log('OK ' + response);
                    },
                    error: function(error) {
                        console.log('Error: ' + error);
                        if (error.responseText) {
                            console.log('ResponseText:', error.responseText); // Nội dung trả về từ server
                        }
                        if (error.status) {
                            console.log('Status:', error.status); // Mã lỗi HTTP (404, 500, 405, ...)
                        }
                    }
                })
            
        } else {
            var error = $('.error:visible').first();
            if (error) {
                if (error.attr('name') == 'ImageFace' || error.attr('name') == 'ImageIdCardBefore' || error.attr('name') == 'ImageIdCardAfter') {
                    $('html, body').animate({
                        scrollTop: $('#' + error.attr('name') + 'Preview').offset().top
                    }, 1000);
                } else {
                    $(error).focus();
                }
                let text = "Vui lòng điền đầy đủ thông tin";
                ShowToastMessage({
                    text: text,
                    bgColor: bgError
                });
            }
        }
    });

    $('#cropImageBtn').on('click', function(e) {
        console.log('clicked')
        e.preventDefault();
        if ($uploadCrop) {
            $uploadCrop.croppie('result', {
                type: 'canvas',
                size: 'viewport'
            }).then(function(resp) {
                $('#Image3x4Preview').attr('src', resp);
                $('#cropImagePop').modal('hide');
            });
        }
    });

    const minSizeID = 1048576;
    const maxSizeID = 3145728;
    const maxSizeFilePdf = 5242880;
    var quality = 0.5;
    $('#IDCardFront, #IDCardBack, #BirthCertificate,#SchoolCertificate').change(async function (e) {
        
        const nameAttr = this.getAttribute("name");
        console.log(nameAttr);
        console.log(1234);
        var validator = $("#UserInfoForm").validate();
        $('#' + nameAttr + 'Preview').attr("src", '');
        
        if (typeof (this.files[0]) != 'undefined') {
            
            $('label[for="' + nameAttr + '"]').remove()
            readURL(this);
            const acceptAttr = this.getAttribute("accept");
            if (acceptAttr == "application/pdf") {
                if (this.files[0].type != "application/pdf" || this.files[0].size > 5242880) {
                    const error = "File Pdf vượt quá dung lượng cho phép "
                    var validator = $("#UserInfoForm").validate();
                    validator.showErrors({
                        "SchoolCertificate": error
                    });

                    ShowToastMessage({
                        text: error,
                        bgColor: bgError
                    });
                }
            }
            else {
                if (this.files[0].size > minSizeID && this.files[0].size < maxSizeID) {
                    const dataTransfer = await DownSizeImange(e.target.files, quality)
                    // gán lại file to input
                    e.target.files = dataTransfer.files;

                    
                }

                if (((this.files[0].type != "image/jpeg") && (this.files[0].type != "image/jpg")) || this.files[0].size > 512000 || this.files[0].size < 10000) {
                    const error = "Vui lòng chọn file đúng định dạng .jpeg hoặc .jpg  và có dung lượng dưới 500KB"
                    

                    // nếu có error thì add error
                    switch (nameAttr) {
                        case "ImageIdCardBefore":
                            validator.showErrors({
                                "ImageIdCardBefore": error
                            });
                            break;
                        case "ImageIdCardAfter":
                            validator.showErrors({
                                "ImageIdCardAfter": error
                            });
                            break;
                        case "BirthCertificate":
                            validator.showErrors({
                                "BirthCertificate": error
                            });
                            break;

                    }
                    ShowToastMessage({
                        text: error,
                        bgColor: bgError
                    });
                }
            }
        }

        if (nameAttr === "ImageIdCardBefore") {
            validator.showErrors({ "ImageIdCardBefore": null });
        }
        if (nameAttr === "ImageIdCardAfter") {
            validator.showErrors({ "ImageIdCardAfter": null });
        }
    })

    $(function() {
        var isDragging = false, startY, startTop;
        var $modalDialog = $('#cropImagePop .modal-dialog');
    
        $('#headerModal').css('cursor', 'move');
    
        $('#headerModal').on('mousedown', function(e) {
            isDragging = true;
            startY = e.clientY;
            startTop = parseInt($modalDialog.css('top')) || 0;
            $(document).on('mousemove.cropperModal', function(e) {
                if (isDragging) {
                    var newTop = startTop + (e.clientY - startY);
                    $modalDialog.css('top', newTop + 'px');
                }
            });
            $(document).on('mouseup.cropperModal', function() {
                isDragging = false;
                $(document).off('.cropperModal');
            });
        });
        // Reset modal position when open
        $('#cropImagePop').on('show.bs.modal', function () {
                    $modalDialog.css('top', '');
                });
    });
});


var listItem = []


// var $uploadCrop;
            // File validation function
function ValidateFile() {
    var result = true;
    var maxSizeImage = 512000;
    $('#IDCardFront, #IDCardBack, #Image3x4').each(function() {
        const nameAttr = this.getAttribute("name");
        if (typeof(this.files[0]) != 'undefined') {
            if (nameAttr == "Image3x4" && (this.files[0].size > maxSizeImage || this.files[0].size < 10000)) {
                const error = "Vui lòng chọn file ảnh và có dung lượng dưới 200KB";
                var validator = $("#UserInfoForm").validate();
                validator.showErrors({
                    "Image3x4": error
                });
                result = false;
            } else if (nameAttr != "Image3x4" && (this.files[0].type != "image/jpeg" && this.files[0].type != "image/jpg" && this.files[0].type != "image/png" || this.files[0].size > 512000 || this.files[0].size < 10000)) {
                const error = "Vui lòng chọn file đúng định dạng .jpeg, .png hoặc .jpg và có dung lượng dưới 200KB";
                var validator = $("#UserInfoForm").validate();
                switch (nameAttr) {
                    case "ImageIdCardBefore":
                        validator.showErrors({
                            "ImageIdCardBefore": error
                        });
                        break;
                    case "ImageIdCardAfter":
                        validator.showErrors({
                            "ImageIdCardAfter": error
                        });
                        break;
                }
                result = false;
            }
        }
    });
    return result;
}

        
    
        
           
        