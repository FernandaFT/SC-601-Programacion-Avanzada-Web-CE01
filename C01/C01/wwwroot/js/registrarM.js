$(function () {

    $("#RegistroMascota").validate({
        rules: {
            Nombre: {
                required: true
            },
            Especie: {
                required: true
            },
            Raza: {
                required: true
            },
            Peso: {
                required: true
            },
            IdCliente: {
                required: true
            }
        },
        messages: {
            Nombre: {
                required: "Campo obligatorio"
            },
            Especie: {
                required: "Campo obligatorio"
            },
            Raza: {
                required: "Campo obligatorio"
            },
            Peso: {
                required: "Campo obligatorio"
            },
            IdCliente: {
                required: "Campo obligatorio"
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