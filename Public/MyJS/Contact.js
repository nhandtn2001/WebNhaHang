
var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();
            var email = $('#txtEmail').val();
            var content = $('#txtContent').val();

            $.ajax({
                url: '/Site/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    content: content
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert("Gửi thành công");
                        contact.resetForm();
                    }
                    else window.alert(res.message);
                },
            });
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtContent').val('');
    }
}
contact.init();