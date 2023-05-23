var table = 0;

document.addEventListener('DOMContentLoaded', function () {    
    //TabloGetir(1, 0, 10);
});

$(document).ready(function () {

    TabloGetir1(1);

    $('.datepicker').datepicker({
        minDate: new Date(),
        dateFormat: "dd-mm-yy",
        monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        dayNamesMin: ["Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct"],
        firstDay: 1
    });

    $('.datepickerGuncelle').datepicker({
        minDate: new Date(),
        dateFormat: "dd-mm-yy",
        monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        dayNamesMin: ["Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct"],
        firstDay: 1
    });

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

    $("#FrmLisans").validate({
        rules: {
            LisansBaslangicTarihi: {
                required: true
            },
            ToplamYil: {
                required: true,
                digits: true
            },
            LisansKisiSayisi: {
                required: true,
                digits: true
            },
            KurumAdi: {
                required: true
            },
            KurumIpAdresi: {
                required: true
            },
            YazilimAdi: {
                required: true
            },
            YazilimProtokolNo: {
                required: true
            }
        },
        messages: {
            LisansBaslangicTarihi: {
                required: "Lisans başlangıç tarihi boş bırakılamaz."
            },
            ToplamYil: {
                required: "Toplam yıl boş bırakılamaz.",
                digits: "Toplam yıl sadece rakamlardan oluşabilir."
            },
            LisansKisiSayisi: {
                required: "Lisans kişi sayısı boş bırakılamaz.",
                digits: "Lisans kişi sayısı sadece rakamlardan oluşabilir."
            },
            KurumAdi: {
                required: "Kurum adı boş bırakılamaz."
            },
            KurumIpAdresi: {
                required: "Kurum IP adresi boş bırakılamaz."
            },
            YazilimAdi: {
                required: "Yazılım adı boş bırakılamaz."
            },
            YazilimProtokolNo: {
                required: "Yazılım protokol numarası boş bırakılamaz."
            }
        },
        errorClass: "error-message",
        errorElement: "span",
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(errorClass).removeClass(validClass);
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(errorClass).addClass(validClass);
        }
    });

    $("#FrmGuncelle").validate({
        rules: {
            LisansBaslangicTarihi: {
                required: true
            },
            ToplamYil: {
                required: true,
                digits: true
            },
            LisansKisiSayisi: {
                required: true,
                digits: true
            },
            KurumAdi: {
                required: true
            },
            KurumIpAdresi: {
                required: true
            },
            YazilimAdi: {
                required: true
            },
            YazilimProtokolNo: {
                required: true
            }
        },
        messages: {
            LisansBaslangicTarihi: {
                required: "Lisans başlangıç tarihi boş bırakılamaz."
            },
            ToplamYil: {
                required: "Toplam yıl boş bırakılamaz.",
                digits: "Toplam yıl sadece rakamlardan oluşabilir."
            },
            LisansKisiSayisi: {
                required: "Lisans kişi sayısı boş bırakılamaz.",
                digits: "Lisans kişi sayısı sadece rakamlardan oluşabilir."
            },
            KurumAdi: {
                required: "Kurum adı boş bırakılamaz."
            },
            KurumIpAdresi: {
                required: "Kurum IP adresi boş bırakılamaz."
            },
            YazilimAdi: {
                required: "Yazılım adı boş bırakılamaz."
            },
            YazilimProtokolNo: {
                required: "Yazılım protokol numarası boş bırakılamaz."
            }
        },
        errorClass: "error-message",
        errorElement: "span",
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(errorClass).removeClass(validClass);
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(errorClass).addClass(validClass);
        }
    });

    $('#dropdown').change(function () {

        var pageInfo = $('#lisansTablosu').DataTable().page.info();
        var table = $('#lisansTablosu').DataTable();
        var length = table.page.len();
        var sayfasayisi = (pageInfo.page) * length;
        selectedOption = $('#dropdown').val();
        TabloGetir1(selectedOption);
        if (selectedOption == 1) {
            $('.row #title').empty().append("Aktif Lisanslar");
        }
        if (selectedOption == 2) {
            $('.row #title').empty().append("Arşivlenmiş Lisanslar");
        }
        if (selectedOption == 3) {
            $('.row #title').empty().append("Silinmiş Lisanslar");
        }
    });

    $("#lisansEkleModal").click(function (event) {
        if (event.target !== modal) {
            event.stopPropagation();
        }
    });

    $("#lisansDetayModal").click(function (event) {
        if (event.target !== modal) {
            event.stopPropagation();
        }
    });

});



$("#Btnkaydet").click(function () {
    var formData = $("#FrmLisans").serialize();
    if ($("#FrmLisans").valid()) {
        $.ajax({
            type: "POST",
            url: "/Lisans/LisansSayfasi/",
            data: formData,
            success: function (formdata) {
                swal({
                    title: "Kayıt Başarılı",
                    icon: "success"
                }).then(function () {
                    $('#lisansEkleModal').modal('hide');                   
                    TabloGetir1(1);
                    $('#dropdown').val(1);
                    $('.row #title').empty().append("Aktif Lisanslar");
                });
            },
            error: function () {
                alert("Bir Hata Oluştu");
            }
        });
    }
});


//$("#BtnGirisYap").click(function () {
//    var formData = $("#kt_sign_in_form").serialize();
//    $.ajax({
//        type: "post",
//        url: "/Login/GirisYap/",
//        data: formData,
//        success: function (data) {
//            if (data.sonuc) {
//                window.location.href = "/Lisans/LisansGetir";
//            } else {
//                swal({
//                    title: "Kullanıcı Adı Ve/Veya Şifre Yanlış ",
//                    icon: "error"
//                })
//            }
//        },
//        error: function () {
//            swal({
//                title: "Giriş işlemi başarısız",
//                icon: "error"
//            })
//        }
//    });
//});


$("#BtnGuncelle").click(function () {
    var formData = $("#FrmGuncelle").serialize();
    var selectedOption = $('#dropdown').val();  
    if ($("#FrmGuncelle").valid()) {
        $.ajax({
            type: "post",
            url: "/Lisans/LisansGuncelle/",
            data: formData,
            success: function (data) {
                if (data.sonuc) {
                    swal({
                        title: "Güncelleme başarılı",
                        icon: "success"
                    }).then(function () {
                        $('#lisansDetayModal').modal('hide');                      
                        TabloGetir1(selectedOption);
                    });
                } else {
                    swal({
                        title: "Güncelleme başarısız",
                        icon: "error"
                    }).then();
                }
            },
            error: function () {
                alert("Bir Hata Oluştu");
            }
        });
    }
});


$("#BtnArsivle").click(function () {
    var lisansID = $(this).data('lisansid');
    swal({
        title: "Arşivlemek İstiyor Musunuz?",
        icon: "warning",
        buttons: {
            cancel: "İptal",
            confirm: "Tamam",
        },
        dangerMode: true,
    }).then((result) => {
        if (result) {
            $.ajax({
                url: '/Lisans/LisansDurumDegistir/',
                type: 'get',
                data: {
                    id: lisansID,
                    durum: 2,
                },
                success: function () {

                    $('#lisansDetayModal').modal('hide');
                    var pageInfo = $('#lisansTablosu').DataTable().page.info();
                    var table = $('#lisansTablosu').DataTable();
                    var length = table.page.len();
                    var sayfasayisi = pageInfo.page + 1;
                    TabloGetir1(2);
                    $('#dropdown').val(2);   
                    $('.row #title').empty().append("Arşivlenmiş Lisanslar");
                },
                error: function () {
                    alert("Bir Hata Oluştu");
                }
            });
        }

    });
});

$("#BtnSil").click(function () {
    var lisansID = $(this).data('lisansid');
    swal({
        title: "Silmek İstiyor Musunuz?",
        icon: "warning",
        buttons: {
            cancel: "İptal",
            confirm: "Tamam",
        },
        dangerMode: true,
    }).then((result) => {
        if (result) {
            $.ajax({
                url: '/Lisans/LisansDurumDegistir/',
                type: 'get',
                data: {
                    id: lisansID,
                    durum: 3,
                },
                success: function () {
                    $('#lisansDetayModal').modal('hide');                   
                    TabloGetir1(3);
                    $('#dropdown').val(3);     
                    $('.row #title').empty().append("Silinmiş Lisanslar");
                },
                error: function () {
                    alert("Bir Hata Oluştu");
                }
            });
        }

    });
});

$("#BtnAktifYap").click(function () {
    var lisansID = $(this).data('lisansid');
    var Ldurum = $(this).data('sayfa');
    swal({
        title: "Aktif Etmek İstiyor Musunuz?",
        icon: "warning",
        buttons: {
            cancel: "İptal",
            confirm: "Tamam",
        },
        dangerMode: true,
    }).then((result) => {
        if (result) {
            $.ajax({
                url: '/Lisans/LisansDurumDegistir/',
                type: 'get',
                data: {
                    id: lisansID,
                    durum: 1,
                },
                success: function () {
                    $('#lisansDetayModal').modal('hide');
                    TabloGetir1(1);
                    $('#dropdown').val(1);
                    $('.row #title').empty().append("Aktif Lisanslar");
                },
                error: function () {
                    alert("Bir Hata Oluştu");
                }
            });
        }

    });
});

//$("#BtnLisansEkle").click(function () {
//    $.ajax({
//        url: '/Lisans/LisansSayfasi',
//        type: 'GET',
//        success: function (data) {
//            $('#lisansEkleModal .modal-body').empty().append(data);
//            $('#lisansEkleModal').modal('show');
//            $('#lisansEkleModal .datepicker').datepicker('setDate', new Date());
//        },
//        error: function () {
//            alert("Bir Hata Oluştu");
//        }
//    });
//});

$('#lisansTablosu').on('click', '#BtnDetay', function () {

    var lisansID = $(this).data('id');
    var durum = $(this).data('sayfa');
    $.ajax({
        url: '/Lisans/LisansDetay',
        type: 'GET',
        data: {
            id: lisansID,
        },
        success: function (data) {

            $('#lisansDetayModal .modal-body').empty().append(data);  // LisansDetayModal id'li modalın içerisindeki model-body classına sahip divin içini önce boşaltıp sonra dönen veriyi ekledik.
            $('#lisansDetayModal').modal('show');
        },
        error: function () {
            alert("Bir Hata Oluştu");
        }
    });

});

$("#BtnCopy").click(function () {
    var metin = document.getElementById("LisansKodu");
    metin.select();
    document.execCommand("copy");
});
