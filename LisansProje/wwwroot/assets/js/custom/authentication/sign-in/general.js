"use strict";

// Class definition
var KTSigninGeneral = function() {
    // Elements
    var form;
    var submitButton;
    var validator;

    // Handle form
    var handleForm = function(e) {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validator = FormValidation.formValidation(
			form,
			{
				fields: {					
					'KullaniciAdi': {
                        validators: {
							notEmpty: {
								message: 'Kullanýcý Adý Gerekli'
							}
                            
						}
					},
                    'Sifre': {
                        validators: {
                            notEmpty: {
                                message: 'Þifre Gerekli'
                            }
                        }
                    } 
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: '.fv-row'
                    })
				}
			}
		);		

        // Handle form submit
        submitButton.addEventListener('click', function (e) {
            
            e.preventDefault();
            validator.validate().then(function (status) {
                if (status == 'Valid') {
                    // Show loading indication
                    submitButton.setAttribute('data-kt-indicator', 'on');
                    // Disable button to avoid multiple click 
                    submitButton.disabled = true;                    
                    // Simulate ajax request
                    setTimeout(function() {
                        // Hide loading indication
                        submitButton.removeAttribute('data-kt-indicator');
                        // Enable button
                        submitButton.disabled = false;
                        var formData = $("#kt_sign_in_form").serialize();
                        $.ajax({
                            type: "post",
                            url: "/Login/GirisYap/",
                            data: formData,
                            success: function (data) {                                
                                if (data.sonuc) {
                                    Swal.fire({
                                        text: "Giriþ Ýþlemi Baþarýlý",
                                        icon: "success",
                                        buttonsStyling: false,
                                        confirmButtonText: "Tamam",
                                        customClass: {
                                            confirmButton: "btn btn-primary"
                                        }
                                    }).then(function () {
                                        window.location.href = "/Lisans/LisansGetir";
                                    });
                                    
                                }
                                else if (data.sonuc == false) {
                                    Swal.fire({
                                        text: "Kullanýcý Adý Ve/Veya Þifre Yanlýþ",
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
                                    text: "Giriþ Ýþlemi Baþarýsýz",
                                    icon: "error",
                                    buttonsStyling: false,
                                    confirmButtonText: "Tamam",
                                    customClass: {
                                        confirmButton: "btn btn-primary"
                                    }
                                });
                            }
                        });  
                    }, 1000);   						
                }
                else {                    
                    Swal.fire({
                        text: "Tüm Alanlarý Doldurun !!",
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
    }

    // Public functions
    return {
        // Initialization
        init: function() {
            form = document.querySelector('#kt_sign_in_form');
            submitButton = document.querySelector('#kt_sign_in_submit');
            
            handleForm();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTSigninGeneral.init();
});
