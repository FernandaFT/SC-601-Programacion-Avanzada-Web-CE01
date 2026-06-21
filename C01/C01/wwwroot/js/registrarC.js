$(function () {

    $("#RegistroCliente").validate({
        rules: {
            Cedula: {
                required: true
            },
            Nombre: {
                required: true
            },
            Correo: {
                required: true,
                email: true
            }
        },
        messages: {
            Cedula: {
                required: "Campo obligatorio"
            },
            Nombre: {
                required: "Campo obligatorio"
            },
            Correo: {
                required: "Campo obligatorio",
                email: "Formato no válido"
            }
        },
        errorElement: "span",
        errorPlacement: function (error, element) {
            error.addClass("text-danger small d-block mt-1");
            error.insertAfter(element);
        },
        highlight: function (element) {
            $(element).addClass("is-invalid");
        },
        unhighlight: function (element) {
            $(element).removeClass("is-invalid").addClass("is-valid");
        },
        submitHandler: function (form) {
            form.submit();
        }
    });

});