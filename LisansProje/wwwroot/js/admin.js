
$(document).on('touchstart click', '#BtnGirisYap', function () {
    var formData = $("#FrmGirisYap").serialize();
    $.ajax({
        type: "POST",
        url: "/Login/GirisYap/",
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
            if (data.admin) {
                document.getElementById("loading").style.display = "flex";
                setTimeout(function () {
                    window.location.href = "/Lisans/LisansGetir";
                }, 500);
            }
            else if (data.admin==false) {
                Swal.fire({
                    title: "Kullanıcı Adı Ve/Veya Şifre Yanlış",
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "Tamam",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
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