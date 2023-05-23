
$(document).on('touchstart click', '#BtnFirmaGirisYap', function () {
    var formData = $("#FrmFirmaGiris").serialize();
    $.ajax({
        type: "POST",
        url: "/Firma/FirmaGirisSayfasi/",
        data: formData,
        success: function (data) {
            if (data.sonuc == false) {
                var errorMessage = "";
                for (var i = 0; i < data.errors.length; i++) {
                    errorMessage += data.errors[i] + "<br>";
                }
                Swal.fire({
                    title: 'Giriş İşlemi Gerçekleşmedi',
                    html: errorMessage,
                    icon: 'error',
                    confirmButtonText: 'Tamam',
                })
            }
            else {
                if (data.firma) {
                    document.getElementById("loadingfirma").style.display = "flex";
                    setTimeout(function () {
                        window.location.href = "/Firma/UrunEkle";
                    }, 500);
                }
                else if (data.firma == false) {
                    Swal.fire({
                        title: "Mail Ve/Veya Şifre Yanlış",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Tamam",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    });
                }
            }
        },
        error: function () {
            Swal.fire({
                text: "Giriş İşlemi Başarısız",
                icon: "error",
                buttonsStyling: false,
                confirmButtonText: "Tamam",
                customClass: {
                    confirmButton: "btn btn-primary"
                }
            });
        }
    });

});

$(document).on('touchstart click', '#BtnFirmaKayitOl', function () {
    var formData = $("#FrmFirmaKayitOl").serialize();
    $.ajax({
        type: "POST",
        url: "/Firma/KayitOl",
        data: formData,
        success: function (data) {
            if (data.sonuc) {
                Swal.fire({
                    title: 'Kayıt Başarılı',
                    icon: 'success',
                    confirmButtonText: 'Tamam',
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = "/Firma/FirmaGirisSayfasi"
                    }
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

$(document).on('touchstart click', '#BtnKayitOl', function () {
    $.ajax({
        type: "get",
        url: "/Firma/KayitOl/",
        success: function () {
            window.location.href = "/Firma/KayitOl"
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

$(document).on('touchstart click', '#BtnGirisYap', function () {
    $.ajax({
        type: "get",
        url: "/Firma/FirmaGirisSayfasi/",
        success: function () {
            window.location.href = "/Firma/FirmaGirisSayfasi"
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

$(document).on('touchstart click', '#FirmaBilgi', function () {
    debugger;
    var firmaID = $(this).data('id');
    $.ajax({
        url: '/Firma/FirmaDetay',
        type: 'GET',
        data: {
            id: firmaID,
        },
        success: function (data) {
            $('#FirmaDetayModal .modal-body').empty().append(data);
            $('#FirmaDetayModal').modal('show');
        },
        error: function () {
            alert("Bir Hata Oluştu");
        }
    });
});

$(document).on('touchstart click', '#BtnFirmaGuncelle', function () {

    var formData = $("#FrmFirmaGuncelle").serialize();
    $.ajax({
        type: "post",
        url: "/Firma/FirmaGuncelle/",
        data: formData,
        success: function (data) {
            if (data.sonuc) {
                Swal.fire({
                    title: 'Bilgiler Başarıyla Güncellendi',
                    icon: 'success',
                    confirmButtonText: 'Tamam',
                }).then(function () {
                    $('#FirmaDetayModal').modal('hide');
                    $('#fadi').empty().append(data.ad);
                    $('#fadi1').empty().append(data.ad);
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

$(document).on('touchstart click', '#BtnUrunEkle', function () {

    var formData = $("#FrmUrunEkle").serialize();
    $.ajax({
        type: "POST",
        url: "/Firma/UrunEkle",
        data: formData,
        success: function (data) {
            if (data.sonuc) {
                Swal.fire({
                    title: 'Kayıt Başarılı',
                    html: `  <div class="row">
                                <div class="mb-3 col-md-11">
                                    <label class="form-label font-weight-bold" for="protokol">Protokol Numarası</label>
                                    <input class="form-control" id="protokol" type="text" value="${data.protokol}" readonly>
                                 </div>
                                 <div class="form-group col-md-1">
                                     <img id="Btnprotokolkopyala" src="/assets/copy1.png" style="margin-top:22px">
                                </div>
                             </div>

                            <br>
                            <div class="row">
                               <div class="mb-3 col-md-11">
                                  <label class="form-label font-weight-bold" for="servis">Servis URL</label>
                                  <input type="text" class="form-control" id="servis" value="${data.servis}" readonly>
                               </div>
                               <div class="form-group col-md-1">
                                    <img id="Btnserviskopyala" src="/assets/copy1.png" style="margin-top:22px">
                                </div>
                            </div>
                          `,
                    icon: 'success',
                    width: 515,
                    confirmButtonText: 'Tamam',
                })
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

$(document).on('touchstart click', '#Btnprotokolkopyala', function () {
    var metin = document.getElementById("protokol");
    metin.select();
    document.execCommand("copy");
});

$(document).on('touchstart click', '#Btnserviskopyala', function () {
    var metin = document.getElementById("servis");
    metin.select();
    document.execCommand("copy");
});

$(document).on('touchstart click', '#layoutUrunlerim', function () {
    window.location = "/Firma/UrunGetir"
});

$(document).on('touchstart click', '#layoutUrunEkle', function () {
    window.location = "/Firma/UrunEkle"
});


function TabloGetirUrun() {

    table = $('#UrunTablosu').DataTable({
        "ajax": {
            "url": "/Firma/UrunGetir",
            "type": "POST",
            "data": {
                "id": 1,
            },
            "datatype": "json",
        },
        "paging": true,
        "filter": true,
        "order": [[0, 'asc']],
        "responsive": true,
        "processing": true,
        "serverSide": true,
        "bDestroy": true,
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json"
        },
        "lengthMenu": [[10, 25], [10, 25]],
        "columns": [          
            { "data": "urunAdi" },
            { "data": "webSitesi" },
            { "data": "protokolNo" },
            { "data": "servisUrl" },
        ]
    });
}

$(document).ready(function () {
    TabloGetirUrun();    
});