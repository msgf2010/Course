$(() => {
    $("#candidate-form").on('change', function () {
        const firstName = $("#first-name").val();
        const lastName = $("#last-name").val();
        const phoneNumber = $("#phonenumber").val();
        const email = $("#email").val();

        const isValid = firstName !== '' && lastName !== '' && phoneNumber !== '' && email !== '';

        $("#add-person").prop('disabled', !isValid);
    });
});