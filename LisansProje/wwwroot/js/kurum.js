$(document).on('touchstart click', '#KurumGetir', function () {
    $.ajax({
        type: "post",
        url: "/Kurum/KurumGetir/",
        success: function () {
            window.location = "/Kurum/KurumGetir"
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

$(document).on('touchstart click', '#BtnKurumSil', function () {

    var kurumId = $(this).data('id');
    Swal.fire({
        title: 'Kurumu Silmek İstiyor Musunuz?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet',
        cancelButtonText: "İptal"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Kurum/KurumSil/',
                type: 'get',
                data: {
                    id: kurumId,
                },
                success: function () {
                    $('#KurumDetayModal').modal('hide');
                    TabloGetirKurum();
                },
                error: function () {
                    alert("Bir Hata Oluştu");
                }
            });
        }
    });
});

$(document).on('touchstart click', '#KurumEkle', function () {
    $.ajax({
        url: '/Kurum/KurumEkle',
        type: 'GET',
        success: function (data) {
            $('#KurumEkleModal .modal-body').empty().append(data);
            $('#KurumEkleModal').modal('show');
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

$(document).on('touchstart click', '#BtnKurumKaydet', function () {
    var formData = $("#FrmKurum").serialize();
    $.ajax({
        type: "POST",
        url: "/Kurum/KurumEkle/",
        data: formData,
        dataType: "json",
        success: function (data) {
            if (data.success) {
                Swal.fire({
                    title: 'Kayıt Başarılı',
                    icon: 'success',
                    confirmButtonText: 'Tamam',
                }).then(function () {
                    $('#KurumEkleModal').modal('hide');
                    TabloGetirKurum();
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
                title: 'Bir Hata Oluştu',
                icon: 'error',
                confirmButtonText: 'Tamam',
            })
        }
    });
});

$(document).on('touchstart click', '#BtnKurumEkle', function () {
    var formData = $("#FrmKurum").serialize();
    $.ajax({
        type: "POST",
        url: "/Kurum/KurumEkle/",
        data: formData,
        dataType: "json",
        success: function (data) {
            if (data.success) {
                Swal.fire({
                    title: 'Kayıt Başarılı',
                    icon: 'success',
                    confirmButtonText: 'Tamam',
                })
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
            Swal.fire(
                'Ekleme İşleminde Hata',
                '',
                'error'
            )
        }
    });
});

$(document).on('touchstart click', '#BtnKurumDetay', function () {
    var kurumID = $(this).data('id');
    $.ajax({
        url: '/Kurum/KurumDetay',
        type: 'GET',
        data: {
            id: kurumID,
        },
        success: function (data) {
            $('#KurumDetayModal .modal-body').empty().append(data);
            $('#KurumDetayModal').modal('show');
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

$(document).on('touchstart click', '#BtnKurumGuncelle', function () {

    var formData = $("#FrmKurumGuncelle").serialize();
    $.ajax({
        type: "post",
        url: "/Kurum/KurumGuncelle/",
        data: formData,
        success: function (data) {
            if (data.sonuc) {
                Swal.fire({
                    title: 'Güncelleme İşlemi Yapıldı',
                    icon: 'success',
                    confirmButtonText: 'Tamam',
                }).then(function () {
                    $('#KurumDetayModal').modal('hide');
                    TabloGetirKurum();
                });
            } else {
                var errorMessage = "";
                for (var i = 0; i < data.errors.length; i++) {
                    errorMessage += data.errors[i] + "\n";
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

$(document).on('touchstart click', '#BtnKurumFiltrele', function () {
    var kurumadi = $("#KurumAdif").val();

    table = $('#kurumTablosu').DataTable({
        "ajax": {
            "url": "/Kurum/KurumFiltrele",
            "type": "POST",
            "data": {
                "kurumAdi": kurumadi,
                "durum": 1,
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
            {
                "data": null, "width": "50px",
                "render": function (data, type, row) {
                    return '<div id="BtnKurumDetay" class="btn btn-success" style="border-radius: 50%; width:25px; display:flex; justify-content:center; align-items:center;"; data-id="' + row.id + '"><i class="bi bi-pencil-square" style="margin-left:5px"></i></div>';
                }
            },
            { "data": "kurumAdi" },
        ]
    });
    

});

$(document).on('touchstart click', '#BtnKurumTemizle', function () {
    document.getElementById("KurumAdif").value = "";
    TabloGetirKurum();
});

function TabloGetirKurum() {

    table = $('#kurumTablosu').DataTable({
        "ajax": {
            "url": "/Kurum/KurumGetir",
            "type": "POST",
            "data": {
                "durum": 1,
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
            {
                "data": null, "width": "50px",
                "render": function (data, type, row) {
                    return '<div id="BtnKurumDetay" class="btn btn-success" style="border-radius: 50%; width:25px; display:flex; justify-content:center; align-items:center;"; data-id="' + row.id + '"><i class="bi bi-pencil-square" style="margin-left:5px"></i></div>';
                }
            },
            { "data": "kurumAdi" },
        ]
    });
}

$(document).ready(function () {
    TabloGetirKurum();
    $('#KurumIDf').select2();
});