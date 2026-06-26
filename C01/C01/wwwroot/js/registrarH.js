$(function () {

    $("#Registro").validate({
        rules: {
            NumeroHabitacion: {
                required: true
            },
            MontoTotal: {
                required: true,
                number: true,
                min: 0.01
            },
            TipoHabitacion: {
                required: true
            }
        },
        messages: {
            NumeroHabitacion: {
                required: "Campo obligatorio"
            },
            MontoTotal: {
                required: "Campo obligatorio",
                number: "Debe digitar un monto válido",
                min: "El monto debe ser mayor a cero"
            },
            TipoHabitacion: {
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