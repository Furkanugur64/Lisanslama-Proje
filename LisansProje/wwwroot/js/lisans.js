$(document).on('touchstart click', '#LisansEkle', function () {
    $.ajax({
        url: '/Lisans/LisansSayfasi',
        type: 'GET',
        success: function (data) {
            $('#LisansEkleModal .modal-body').empty().append(data);
            $('#LisansEkleModal').modal('show');           
                      
        },
        error: function () {
            alert("Bir Hata Oluştu");
        }
    });
});

$(document).on('touchstart click', '#BtnDetay', function () {

    var lisansID = $(this).data('id');
    var durum = $(this).data('sayfa');
    $.ajax({
        url: '/Lisans/LisansDetay',
        type: 'GET',
        data: {
            id: lisansID,
        },
        success: function (data) {
            $('#LisansDetayModal .modal-body').empty().append(data); 
            $('#LisansDetayModal').modal('show');            
        },
        error: function () {
            alert("Bir Hata Oluştu");
        }
    });

});

$(document).on('touchstart click', '#HesapBilgilerim', function () {
    var adminID = $(this).data('id');   
    $.ajax({
        url: '/Lisans/AdminDetay',
        type: 'GET',
        data: {
            id: adminID,
        },
        success: function (data) {
            $('#KullaniciDetayModal .modal-body').empty().append(data); 
            $('#KullaniciDetayModal').modal('show');          
        },
        error: function () {
            alert("Bir Hata Oluştu");
        }
    });
});

$(document).on('touchstart click', '#BtnCopy', function () {
    var metin = document.getElementById("LisansKodu");
    metin.select();
    document.execCommand("copy");
});


$(document).on('touchstart click', '#BtnAktifYap', function () {
    var lisansID = $(this).data('lisansid');    
    Swal.fire({
        title: 'Aktif Etmek İstiyor Musunuz ?',       
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet',
        cancelButtonText:"İptal"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Lisans/LisansDurumDegistir/',
                type: 'get',
                data: {
                    id: lisansID,
                    durum: 1,
                },
                success: function () {
                    $('#LisansDetayModal').modal('hide');
                    TabloGetir1(1);
                    $('#dropdown').val(1);
                    $('.toolbar #title').empty().append("Aktif Lisanslar");
                },
                error: function () {
                    alert("Bir Hata Oluştu");
                }
            });
        }
    });
});

$(document).on('touchstart click', '#BtnArsivle', function () {
    var lisansID = $(this).data('lisansid');
    Swal.fire({
        title: 'Arşivlemek İstiyor Musunuz?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet',
        cancelButtonText: "İptal"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Lisans/LisansDurumDegistir/',
                type: 'get',
                data: {
                    id: lisansID,
                    durum: 2,
                },
                success: function () {
                    $('#LisansDetayModal').modal('hide');
                    TabloGetir1(2);
                    $('#dropdown').val(2);
                    $('.toolbar #title').empty().append("Arşivlenmiş Lisanslar");
                },
                error: function () {
                    alert("Bir Hata Oluştu");
                }
            });
        }
    });
});

$(document).on('touchstart click', '#BtnSil', function () {
    var lisansID = $(this).data('lisansid');
    Swal.fire({
        title: 'Silmek İstiyor Musunuz?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet',
        cancelButtonText: "İptal"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Lisans/LisansDurumDegistir/',
                type: 'get',
                data: {
                    id: lisansID,
                    durum: 3,
                },
                success: function () {
                    $('#LisansDetayModal').modal('hide');
                    TabloGetir1(3);
                    $('#dropdown').val(3);
                    $('.toolbar #title').empty().append("Silinmiş Lisanslar");
                },
                error: function () {
                    alert("Bir Hata Oluştu");
                }
            });
        }
    });
});

$(document).on('touchstart click', '#BtnLisansKaydet', function () {
    var formData = $("#FrmLisans").serialize();     
        $.ajax({
            type: "POST",
            url: "/Lisans/LisansSayfasi/",
            data: formData,
            success: function (data) {
                if (data.sonuc) {
                    Swal.fire({
                        title: 'Kayıt Başarılı',
                        icon: 'success',
                        confirmButtonText: 'Tamam',
                    }).then(function () {
                        $('#LisansEkleModal').modal('hide');
                        TabloGetir1(1);
                        $('#dropdown').val(1);
                        $('.toolbar #title').empty().append("Aktif Lisanslar");
                    });
                }
                else {                  
                    var errorMessage = "";
                    for (var i = 0; i < data.errors.length; i++) {
                        errorMessage += data.errors[i] + "<br>";
                    }
                    Swal.fire({                      
                        title: 'Ekleme İşlemi Gerçekleşmedi',
                        html: errorMessage,
                        icon: 'error',
                        confirmButtonText: 'Tamam',
                    })
                }
                
            },
            error: function () {
                Swal.fire({
                    title: 'Ekleme İşleminde Hata',
                    icon: 'error',
                    confirmButtonText: 'Tamam',
                })
            }
        });       
});

$(document).on('touchstart click', '#BtnLisansEkle', function () {
    var formData = $("#FrmLisans").serialize();
    $.ajax({
        type: "POST",
        url: "/Lisans/LisansSayfasi/",
        data: formData,
        success: function (data) {
            if (data.sonuc) {
                Swal.fire({                    
                    title: 'Kayıt Başarılı',
                    icon: 'success',
                    confirmButtonText: 'Tamam',
                });

            } else {
                var errorMessage = "";
                for (var i = 0; i < data.errors.length; i++) {
                    errorMessage += data.errors[i] + "<br>";
                }
                Swal.fire({
                    title: 'Ekleme İşlemi Gerçekleşmedi',
                    html: errorMessage,
                    icon: 'error',
                    confirmButtonText: 'Tamam',
                })
            }

        },
        error: function () {           
            Swal.fire({
                title: 'Ekleme İşleminde Hata',
                icon: 'error',
                confirmButtonText: 'Tamam',
            })
        }
    });
});

$(document).on('touchstart click', '#BtnGuncelle', function () {
    
    var formData = $("#FrmGuncelle").serialize();
    var selectedOption = $('#dropdown').val();   
        $.ajax({
            type: "post",
            url: "/Lisans/LisansGuncelle/",
            data: formData,
            success: function (data) {
                if (data.sonuc) {
                    Swal.fire({
                        title: 'Güncelleme Başarılı',                       
                        icon: 'success',
                        confirmButtonText: 'Tamam',
                    }).then(function () {
                        $('#LisansDetayModal').modal('hide');
                        TabloGetir1(selectedOption);
                    });
                } else {
                    var errorMessage = "";
                    for (var i = 0; i < data.errors.length; i++) {
                        errorMessage += data.errors[i] + "<br>";
                    }
                    Swal.fire({
                        title: 'Güncelleme İşlemi Gerçekleşmedi',
                        html: errorMessage,
                        icon: 'error',
                        confirmButtonText: 'Tamam',
                    })                   
                }
            },
            error: function () {
                Swal.fire({
                    title: 'Güncelleme İşleminde Hata',
                    icon: 'error',
                    confirmButtonText: 'Tamam',
                })
            }
        });    
});

$(document).on('touchstart click', '#BtnAdminGuncelle', function () {

    var formData = $("#FrmAdminGuncelle").serialize();  
    $.ajax({
        type: "post",
        url: "/Lisans/AdminGuncelle/",
        data: formData,
        success: function (data) {
            if (data.sonuc) {               
                Swal.fire({
                    title: 'Bilgiler Başarıyla Güncellendi',                    
                    icon: 'success',
                    confirmButtonText: 'Tamam',
                }).then(function () {
                    $('#KullaniciDetayModal').modal('hide');
                    $('#kadi').empty().append(data.ad);
                    $('#kadi1').empty().append(data.ad);
                    $('#mail').empty().append(data.mail);
                });
            } else {
                var errorMessage = "";
                for (var i = 0; i < data.errors.length; i++) {
                    errorMessage += data.errors[i] + "<br>";
                }
                Swal.fire({
                    title: 'Güncelleme İşlemi Gerçekleşmedi',
                    html: errorMessage,
                    icon: 'error',
                    confirmButtonText: 'Tamam',
                })
            }
        },
        error: function () {
            Swal.fire({
                title: 'Güncelleme İşleminde Hata',                
                icon: 'error',
                confirmButtonText: 'Tamam',
            })
        }
    });
});


$(document).on('touchstart click', '#layoutLisansEkle', function () { 
    $.ajax({
        type: "get",
        url: "/Lisans/LisansEkle/",
        success: function () {     
            window.location.href = "/Lisans/LisansEkle"
           
        },
        error: function () {
            Swal.fire({
                title: 'Bir Hata Oluştu',
                icon: 'error',
                confirmButtonText: 'Tamam',
            })
        }
    });
});

$(document).on('touchstart click', '#layoutKurumEkle', function () {
    $.ajax({
        type: "get",
        url: "/Kurum/KurumKaydet/",
        success: function () {
            window.location.href = "/Kurum/KurumKaydet"
        },
        error: function () {
            Swal.fire({
                title: 'Bir Hata Oluştu',
                icon: 'error',
                confirmButtonText: 'Tamam',
            })
        }
    });
});

$(document).on('touchstart click', '#layoutLisansGetir', function () {
    $.ajax({
        type: "post",
        url: "/Lisans/LisansGetir/",
        success: function () {
            window.location = "/Lisans/LisansGetir"
        },
        error: function () {
            Swal.fire({
                title: 'Bir Hata Oluştu',
                icon: 'error',
                confirmButtonText: 'Tamam',
            })
        }
    });
});

$(document).on('touchstart click', '#BtnFiltrele', function () {

    const dropdown = document.getElementById("KurumIDf");
    var lisanskodu = $("#LisansKoduf").val();   
    var kurumadi = dropdown.options[dropdown.selectedIndex].value;     
    var lisansbastarihi = $("#LisansBaslangicTarihif").val();
    var lisansbittarihi = $("#LisansBitisTarihif").val();
    var durum = $('#dropdown').val();
    table = $('#lisansTablosu').DataTable({
        "ajax": {
            "url": "/Lisans/LisansFiltrele",
            "type": "POST",
            "data": {
                "lisanskodu": lisanskodu,
                "kurumadi": kurumadi,
                "lisansbaslangictarihi": lisansbastarihi,
                "lisansbitistarihi": lisansbittarihi,
                "durum": durum,
            },
            "datatype": "json",
        },
        "paging": true,
        "filter": true,
        "pageLength": 10,
        "order": [[1, 'desc']],
        "responsive": true,
        "processing": true,
        "serverSide": true,
        "bDestroy": true,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json"
        },
        "lengthMenu": [[10, 25, 50], [10, 25, 50]],
        "columns": [
            {
                "data": null, "width": "10%",
                "render": function (data, type, row) {
                    return '<div id="BtnDetay" class="btn btn-success btn-sm" style="border-radius: 50%; width:25px; display:flex; justify-content:center; align-items:center;" data-sayfa="' + row.durum + '" data-id="' + row.lisansID + '"> <i class="bi bi-pencil-square" style="margin-left:5px"></i></div > ';
                }
            },
            { "data": "lisansKodu", "width": "20%" },
            { "data": "kurums.kurumAdi" },
            {
                "data": "lisansBaslangicTarihi",
                "render": function (data) {
                    var date = new Date(data);
                    var day = date.getDate().toString().padStart(2, '0');
                    var month = (date.getMonth() + 1).toString().padStart(2, '0');
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            },
            {
                "data": "lisansBitisTarihi",
                "render": function (data) {
                    var date = new Date(data);
                    var day = date.getDate().toString().padStart(2, '0');
                    var month = (date.getMonth() + 1).toString().padStart(2, '0');
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            },          
        ]
    });

});

$(document).on('touchstart click', '#BtnTemizle', function () {
    var durum = $('#dropdown').val();
    document.getElementById("LisansKoduf").value = "";    
    $('#KurumIDf').val('0').trigger('change'); 
    document.getElementById("LisansBaslangicTarihif").value = "";
    document.getElementById("LisansBitisTarihif").value = "";
    TabloGetir1(durum);
    
});

function TabloGetir1(status) {
    
    table = $('#lisansTablosu').DataTable({
        "ajax": {
            "url": "/Lisans/LisansGetir",
            "type": "POST",
            "data": {
                "status": status,
            },
            "datatype": "json",
        },
        "paging": true,
        "filter": true,
        "order": [[1, 'desc']],
        "responsive": true,
        "processing": true,
        "serverSide": true,
        "bDestroy": true,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json"
        },
        "lengthMenu": [[10, 25, 50], [10, 25, 50]],
        "columns": [         
            {
                "data": null,"width":"5%",
                "render": function (data, type, row) {
                    return '<div id="BtnDetay" class="btn btn-success btn-sm" style="border-radius: 50%; width:25px; display:flex; justify-content:center; align-items:center;" data-sayfa="' + row.durum + '" data-id="' + row.lisansID + '"> <i class="bi bi-pencil-square" style="margin-left:5px"></i></div > ';
                }
            },
            { "data": "lisansKodu", "width": "25%" },
            { "data": "kurums.kurumAdi" },          
            {
                "data": "lisansBaslangicTarihi",
                "render": function (data) {
                    var date = new Date(data);
                    var day = date.getDate().toString().padStart(2, '0');
                    var month = (date.getMonth() + 1).toString().padStart(2, '0');
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            },
            {
                "data": "lisansBitisTarihi",
                "render": function (data) {
                    var date = new Date(data);
                    var day = date.getDate().toString().padStart(2, '0');
                    var month = (date.getMonth() + 1).toString().padStart(2, '0');
                    var year = date.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            }
            
        ]
    });
}

function TabloGetir(durum, sayfaSayisi, toplamVeri) {
    var table = $('#lisansTablosu').DataTable();
    table.on('draw', function (e, settings) {
        if (table.page() + 1 !== sayfaSayisi || settings._iDisplayLength !== toplamVeri) {
            sayfa = Math.floor(settings._iDisplayStart / toplamVeri) + 1;
            toplamVeri = settings._iDisplayLength;
            $.ajax({
                url: "/Lisans/LisansGetir",
                type: "POST",
                data: {
                    "status": durum,

                },
                dataType: "json",
                success: function (data) {
                    table.clear();
                    table.rows.add(data).draw();
                },
                error: function (xhr, status, error) {

                }
            });
        }
    });
}
var genelTarihValidasyon = function () {
    
    if ($('.genelTARIH').length > 0) {

        $('.genelTARIH').each(function () {

            var pAutoUpdateInput = false;
            if ($(this).val() != "" && $(this).val() != undefined) {
                pAutoUpdateInput = true;
            }
            $(this).daterangepicker({
                drops: 'auto',
                autoUpdateInput: pAutoUpdateInput,
                singleDatePicker: true,
                showDropdowns: true,
                autoApply: true,/*Seçilir seçilmez uygulaması için*/
                locale: {
                    format: "DD.MM.YYYY",
                    separator: " - ",
                    applyLabel: "Seç",
                    cancelLabel: "Vazgeç",
                    fromLabel: "From",
                    toLabel: "To",
                    customRangeLabel: "Custom",
                    weekLabel: "W",
                    daysOfWeek: [
                        "Pz",
                        "Pzt",
                        "Sa",
                        "Çrş",
                        "Prş",
                        "Cu",
                        "Cts"
                    ],
                    monthNames: [
                        "Ocak",
                        "Şubat",
                        "Mart",
                        "Nisan",
                        "Mayıs",
                        "Haziran",
                        "Temmuz",
                        "Ağustos",
                        "Eylül",
                        "Ekim",
                        "Kasım",
                        "Aralık"
                    ],
                    firstDay: 1
                },

            });
        });

        $('.genelTARIH').on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('DD.MM.YYYY'));
        });
        $('.genelTARIH').on('hide.daterangepicker', function (ev, picker) {
            if ($(this).val() != "") {
                $(this).val(picker.startDate.format('DD.MM.YYYY'));
            }
        });

        $('.genelTARIH').on('click', function (ev, picker) {
            $('.daterangepicker.show-calendar').css('z-index', ($(this).closest('.modal-dialog').css('z-index')) + 5);
        });

        Inputmask({
            "mask": "99.99.9999"
        }).mask(".genelTARIH");
    }
};

$(document).ready(function () {
    $('#KurumIDf').prepend('<option value="0" selected="selected">Kurum Seçiniz</option>');
    $('#KurumIDf').select2(); 

    $('#KurumID').prepend('<option value="0" selected="selected">Kurum Seçiniz</option>');
    $('#KurumID').select2(); 

    Inputmask({
        "mask": "AAAA-9999-AAAA-9999-AAAA"
    }).mask("#LisansKoduf");

    TabloGetir1(1);
    genelTarihValidasyon();
    $('#ToplamYil').keyup(function () {

        if ($(this).val() > 99) {
            $(this).val(99);
        }
        if ($(this).val() < 0) {
            $(this).val(1);
        }
    });

    $('#LisansKisiSayisi').keyup(function () {
        if ($(this).val() > 99) {
            $(this).val(99);
        }
        if ($(this).val() < 0) {
            $(this).val(1);
        }
    });

    $('#dropdown').change(function () {
        document.getElementById("LisansKoduf").value = "";
        $('#KurumIDf').val('0').trigger('change');
        document.getElementById("LisansBaslangicTarihif").value = "";
        document.getElementById("LisansBitisTarihif").value = "";
        selectedOption = $('#dropdown').val();
        TabloGetir1(selectedOption);
        if (selectedOption == 1) {
            $('.toolbar #title').empty().append("Aktif Lisanslar");
        }
        if (selectedOption == 2) {
            $('.toolbar #title').empty().append("Arşivlenmiş Lisanslar");
        }
        if (selectedOption == 3) {
            $('.toolbar #title').empty().append("Silinmiş Lisanslar");
        }
    });
    $('#KurumIDf').val('0').trigger('change');


    $("#LisansEkleModal").click(function (event) {
        if (event.target !== modal) {
            event.stopPropagation();
        }
    });

    $("#LisansDetayModal").click(function (event) {
        if (event.target !== modal) {
            event.stopPropagation();
        }
    });

});

$("#LisansEkleModal").on("shown.bs.modal", function () {
    $('#KurumID').prepend('<option value="0" selected="selected">Kurum Seçiniz</option>');
    $('#KurumID').select2({
        dropdownParent: $("#LisansEkleModal"),
        dropdownCssClass: "select2-dropdown-custom",
        language: "tr",
    });
    genelTarihValidasyon();
});

$("#LisansDetayModal").on("shown.bs.modal", function () {  
    $('#KurumAdi').select2({
        dropdownParent: $("#LisansDetayModal"),
        dropdownCssClass: "select2-dropdown-custom",
        language: "tr",
    });
    genelTarihValidasyon();
});