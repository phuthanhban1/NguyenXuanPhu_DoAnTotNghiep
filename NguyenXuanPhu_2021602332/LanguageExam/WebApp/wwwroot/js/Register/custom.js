function b64toBlob(b64Data, contentType = '', sliceSize = 512) {
    const byteCharacters = atob(b64Data);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        const slice = byteCharacters.slice(offset, offset + sliceSize);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }

    const blob = new Blob(byteArrays, { type: contentType });
    return blob;
}

function AddOptionSubmissionTime(tagetTag, headerQuarterId) {

    if (headerQuarterId == null || headerQuarterId == '') {
        $(tagetTag + ' option:gt(0)').remove();
        return
    }
    $('#SubmitsionTime').hide();
    $('.spinner-versionExam').show()
    var isUpdate = $(tagetTag).data("isFullData");
    var idSubmitsionTime = $(tagetTag).data("ticketSubmitsiontimeId");


    var now = ChangeTypeDate(new Date(), "dd/mm/yyyy");
    const params = JSON.stringify({
        "SourceTaget": "coretct",
        "Url": 'ManageApplicationTime?headerQuarterId=' + headerQuarterId + '&isCong=true&from=' + now + (isUpdate ? '&isFullData=true&isUpdateCandidate=true' : '')
    });

    fetch("/Resources", {
        method: "POST",
        headers: {
            "Content-Type": "application/json;charset=UTF-8",
        },
        body: params,
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Network response was not ok');
            }
        })
        .then(res => {
            $(tagetTag + ' option:gt(0)').remove();
            if (res.statusCode == 401) {
                $('#Unauthorized').modal('show');
            } else if (res.statusCode == 200) {
                res.data.forEach((item) => {
                    if ((item.maxRegistry - item.registed) > 0 || item.id == idSubmitsionTime) {
                        $(tagetTag).append($('<option>', {
                            value: item.id,
                            text: getFormattedDate(new Date(item.receivedDate)) + ' ' + item.timeStart + ' - ' + item.timeEnd + '',
                        }));
                    }
                });
            }
            $(tagetTag).val("").change();
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);

        })
        .finally(() => {
            $('.spinner-versionExam').hide();
            $('#SubmitsionTime').show();
        });

}
function getFormattedDate(date) {
    var year = date.getFullYear();

    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    return day + '/' + month + '/' + year;
}

function AddOption(tagetTag, url, type) {
    // remove opttion old
    $(tagetTag + ' option:gt(0)').remove();
    if (url == null || type == null) {
        $(tagetTag).val("").change();
        return
    }
    const params = JSON.stringify({
        "SourceTaget": "catalog",
        "Url": url
    });


    let listData = [];
    var xmlhttp = new XMLHttpRequest();   // new HttpRequest instance 
    xmlhttp.open("GET", "/Resources?p=" + params, false);
    xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");


    if (url === "Province") {
        const localStoreData = GetLocalStorageByKey(url)
        if (localStoreData === undefined) {
            xmlhttp.send();
            if (xmlhttp.status === 200) {
                var res = JSON.parse(xmlhttp.responseText)
                if (res.statusCode == 401) {
                    $('#Unauthorized').modal('show');
                }
                else if (res.statusCode == 200) {
                    AddLocalStorage(url, res.data, 24 * 60)
                    AppendOptions(res.data, tagetTag)
                }
            }
        } else {
            listData = localStoreData
            AppendOptions(listData, tagetTag)
        }
    } else {
        xmlhttp.send();
        if (xmlhttp.status === 200) {
            var res = JSON.parse(xmlhttp.responseText)
            if (res.statusCode == 401) {
                $('#Unauthorized').modal('show');
            }
            else if (res.statusCode == 200) {
                AppendOptions(res.data, tagetTag)
            }
        }
    }
}

// add option
function AppendOptions(data, tagetTag) {
    if (data == null || tagetTag == null) {
        return
    }
    data.forEach((item) => {
        $(tagetTag).append($('<option>', {
            value: item.id,
            text: item.name
        }));
    });
}

// xem ảnh trước khi tải lên
function readURL(input) {
    const idTag = $(input)[0].id;
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#' + idTag + 'Preview').attr('src', e.target.result);
            $('#' + idTag + 'Preview').hide();
            $('#' + idTag + 'Preview').fadeIn(650);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
// nén file ảnh: file - đầu vào ; quality - chất lượng file ( * 100%) ; type - loại file đầu ra
const compressImage = async (file, { quality = 1, type = file.type }) => {

    const imageBitmap = await createImageBitmap(file);
    const newWidth = imageBitmap.width * quality;
    const newHeight = imageBitmap.height * quality;

    const option = { resizeHeight: newHeight, resizeWidth: newWidth }
    const newImageBitmap = await createImageBitmap(file, option);

    // Draw to canvas
    const canvas = document.createElement('canvas');
    canvas.width = newImageBitmap.width;
    canvas.height = newImageBitmap.height;
    const ctx = canvas.getContext('2d');
    ctx.drawImage(imageBitmap, 0, 0, canvas.width, canvas.height);

    // Turn into Blob
    const blob = await new Promise((resolve) =>
        canvas.toBlob(resolve, type, quality)
    );
    // Turn Blob into File
    return new File([blob], file.name, {
        type: blob.type,
    });
};
// datetime: dạng Date


const DownSizeImange = async (files, ratioChange = 0.5) => {

    // No files selected
    if (!files.length) return;

    // We'll store the files in this data transfer object
    const dataTransfer = new DataTransfer();

    // For every file in the files list
    for (const file of files) {
        // We don't have to compress files that aren't images
        if (!file.type.startsWith('image')) {
            // Ignore this file, but do add it to our result
            dataTransfer.items.add(file);
            continue;
        }

        // We compress the file by 50%
        const compressedFile = await compressImage(file, {
            quality: ratioChange,
            type: 'image/jpeg',
        });
        if (compressedFile.size < file.size) {
            // Save back the compressed file instead of the original file
            dataTransfer.items.add(compressedFile);
        } else {
            dataTransfer.items.add(file);
        }
    }
    return dataTransfer
}
function ChangeTypeDate(datetime, type) {
    var date = new Date(datetime)
    var dd = date.getDate();
    var mm = date.getMonth() + 1;
    var yyyy = date.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    return type.replace('dd', dd).replace('mm', mm).replace('yyyy', yyyy)
};


function ChangeTypeDateString(datetime, oldType, newType) {
    if (datetime && datetime != '') {
        var dateArray = datetime.split("/")

        var dd = dateArray[oldType.split("/").findIndex(x => x == 'dd')];
        var mm = dateArray[oldType.split("/").findIndex(x => x == 'mm')];
        if (dd.length == 1 && dd < 10) {
            dd = '0' + dd;
        }
        if (mm.length == 1 && mm < 10) {
            mm = '0' + mm;
        }
        var yyyy = dateArray[oldType.split("/").findIndex(x => x == 'yyyy')];
        return newType.replace('dd', dd).replace('mm', mm).replace('yyyy', yyyy)
    }
    else {
        return datetime
    }

};
// truyền dữ liệu vào trong form
// param: data - dữ liệu truyền vào
// param: formId - id của form đích
// param: isDisable - trạng thái có hiển thị các trường trong form 

function FillDataToForm(userInfor, formId, isDisable) {
    var form = $('#' + formId + ' input ,select ');
    $(form).each(function (index, obj) {
        var hasValue = userInfor.find(element => element['metadataCode'] == obj.name);
        if (hasValue) {
            var field = $('[name="' + obj.name + '"]')[0]
            switch (field?.type) {
                case 'radio':
                case 'checkbox':
                    $('[name="' + obj.name + '"][value="' + hasValue?.value + '"]').attr('checked', true).change();
                    break;

                case 'select-one':
                    $(field).val(hasValue?.value).change();

                    break;
                case 'date':
                    let date = hasValue?.value.replaceAll('/', '-');
                    $(field).val(date).change();
                    break;
                case 'file':
                    let ext = hasValue?.value?.substr(0, 3)
                    var fileBase64
                    var file
                    if (ext == 'JVB') {
                        fileBase64 = "data:application/pdf;base64," + hasValue?.value;
                        file = dataURLtoFile(fileBase64, (new Date).valueOf().toString() + '.pdf');
                    }
                    else {
                        fileBase64 = "data:image/jpg;base64," + hasValue?.value;
                        file = dataURLtoFile(fileBase64, (new Date).valueOf().toString() + '.jpg');
                    }

                    $('#' + obj.name + 'Preview').attr("src", fileBase64);
                    if (file) {
                        const dataTransfer = new DataTransfer();
                        dataTransfer.items.add(file);
                        $('#' + obj.name)[0].files = dataTransfer.files;
                    }
                    break;
                default:
                    let isTypeDate = $('#' + obj.name).hasClass('type-date')
                    if (isTypeDate) {
                        $('[name="' + obj.name + '"]').val(ChangeTypeDateString(hasValue?.value, 'yyyy/mm/dd', 'dd/mm/yyyy'));
                    } else {
                        $('[name="' + obj.name + '"]').val(hasValue?.value);
                    }
                    break;

            }
            if (typeof (isDisable) != "undefined" && isDisable == true) {
                $('[name="' + obj.name + '"]').attr('disabled', true).change();
            }

        }
    });
}

function dataURLtoFile(dataurl, filename) {
    try {
        var arr = dataurl.split(','),
            mime = arr[0].match(/:(.*?);/)[1],
            bstr = atob(arr[1]),
            n = bstr.length,
            u8arr = new Uint8Array(n);

        while (n--) {
            u8arr[n] = bstr.charCodeAt(n);
        }
        return new File([u8arr], filename, { type: mime });
    }
    catch (exception) {

    }
}

function GetExamById(examCode) {
    const params = JSON.stringify({
        "SourceTaget": "catalog",
        "Url": 'Exam/GetByCode/' + examCode
    });
    var settings = {
        "url": "/Resources?p=" + params,
        "method": "GET",
    };
    $.ajax(settings).done(function (res) {
        if (res.statusCode == 401) {
            $('#Unauthorized').modal('show');
        } else if (res.statusCode == 200) {
            const examId = res.data['id']
            const name = res.data['name']
            const price = res.data['price']
            $('#examId').val(examId)
            $('.titleRegistration').html(name)
            ShowOrder(name, price)

            areaApply = res.data['areaApply']
            // load danh sách lịch thi của loại bài thi
            GetExamScheduleTopik(examId);
        }
    });
}
function removeVietnameseTones(str) {
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    str = str.replace(/ì|í|ị|ỉ|ĩ|Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹỲ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    str = str.replace(/đ|Đ/g, "D");
    // Some system encode vietnamese combining accent as individual utf-8 characters
    // Một vài bộ encode coi các dấu mũ, dấu chữ như một kí tự riêng biệt nên thêm hai dòng này
    str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ""); // ̀ ́ ̃ ̉ ̣  huyền, sắc, ngã, hỏi, nặng
    str = str.replace(/\u02C6|\u0306|\u031B/g, ""); // ˆ ̆ ̛  Â, Ê, Ă, Ơ, Ư
    // Remove extra spaces
    // Bỏ các khoảng trắng liền nhau
    str = str.replace(/ + /g, " ");
    // Remove punctuations
    // Bỏ dấu câu, kí tự đặc biệt
    str = str.replace(/!|@@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|_|`|-|{|}|\||\\/g, "");
    return str.toUpperCase();
}

// Lấy danh sách khu vực thi
function BindDataArea(data, tagetTag, areaApply = undefined, lang = 'vi') {
    if (!data || data == null) {
        return
    }
    data.forEach((item) => {
        if (item.isShow) {
            let name = lang == 'en' ? item.englishName : lang == 'ko' ? item.koreaName : item.name
            if (areaApply && item.isTopik) {
                let checkShow = areaApply.find(element => element.area == item.id && element.isOn == true)
                if (checkShow != null) {

                    $(tagetTag).append($('<option>', {
                        value: item.id,
                        text: name,
                    }).attr("data-code", item.code));
                }
            }
            else if (item.canRegistration) {
                $(tagetTag).append($('<option>', {
                    value: item.id,
                    text: name
                }).attr("data-code", item.code));
            }
        }
    });
}
function GetArea(areaApply) {
    const tagetTag = '#AreaTest';
    const currentLanguage = $('html').attr('lang')
    const catalogCookie = GetLocalStorageByKey("CatalogArea" + (areaApply ? "Topik" : ''));
    if (catalogCookie != undefined) {
        let res = catalogCookie;
        BindDataArea(res, tagetTag, areaApply, currentLanguage);
    } else {
        const url = '/Catalog/Area' + (areaApply ? "?isTopik=true" : '')
        // remove opttion old
        $(tagetTag + ' option:gt(0)').remove();
        // add first option
        $(tagetTag).val("").change();

        var xmlhttp = new XMLHttpRequest();   // new HttpRequest instance 
        xmlhttp.open("GET", url, false);
        xmlhttp.send();

        if (xmlhttp.status === 200) {
            var res = JSON.parse(xmlhttp.responseText)
            if (res.statusCode == 401) {
                $('#Unauthorized').modal('show');
            }
            else if (res.statusCode == 200) {
                BindDataArea(res.data, tagetTag, areaApply, currentLanguage)
                AddLocalStorage("CatalogArea" + (areaApply ? "Topik" : ''), res.data, 1)
                $(tagetTag).val("").change();
            }
        };
    }
}

function RefreshFormId(formId) {
    var selector = '#' + formId;
    $(selector).trigger("reset");
}

function CheckFieldReadOnly(listField) {
    listField.forEach(item => {
        let metadataField = listMetadata.find(element => element['id'] == item && element['type'] == "SysB2CUserProfileMetadata");
        if (metadataField != null) {
            var obj = $('[name="' + metadataField.code + '"]')[0]
            switch (obj.type) {
                case 'text':
                    $(obj).attr('readonly', true);
                    $(obj).parent("div").addClass('unclick');
                    break;
                case 'radio':
                    $('[name="' + metadataField.code + '"]:radio:not(:checked)').attr('disabled', true);
                    break;
                case 'select-one':
                    $(obj).attr("disabled", true);
                    break;
            }
        }


    })
}

function titleCase(str) {
    // Bỏ dấu câu, kí tự đặc biệt
    str = str.replace(/!|@@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|_|`|-|{|}|\||\\/g, "");
    str = str.toLowerCase().split(' ');
    for (var i = 0; i < str.length; i++) {
        str[i] = str[i].charAt(0).toUpperCase() + str[i].slice(1);
    }
    return str.join(' ');
}

// ẩn form thông tin user
function HidenForm(idForm) {
    var selector = '#' + idForm + ' input,#' + idForm + ' select'
    $(selector).each(function (item) {
        var obj = $('[name="' + $(this).attr("name") + '"]')[0]
        if (typeof (obj) != "undefined") {
            switch (obj.type) {
                case 'text':
                case 'email':
                    $(this).attr('readonly', true);
                    $(this).parent("div").addClass('unclick');
                    break;
                case 'radio':
                    $('[name="' + $(this).attr("name") + '"]:radio:not(:checked)').attr('disabled', true);
                    break;
                case 'select-one':
                    $(this).attr("disabled", true);
                    break;
                case 'checkbox':
                    $(this).attr("disabled", true);
                    break;
            }
        }
    })
    $('#' + idForm).addClass("unclick");
}

