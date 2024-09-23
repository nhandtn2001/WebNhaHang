var form = {
    init: function () {
        form.registerEvents();
    },
    registerEvents: function () {
        $('#btnsend').off('click').on('click', function () {
            var name = $('#txtten').val();
            var phone = $('#txtsdt').val();
            var email = $('#txtemail').val();
            var date = $('#myDate').val();
            var time = $('#myTime').val();
            var slnl = $('#myOptionNL').val();
            var slte = $('#myOptionTE').val();
            var ghichu = $('#txtGhichu').val();

            $.ajax({
                url: '/Site/SendTable',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    phone:phone,
                    email: email,
                    date: date,
                    time: time,
                    slnl: slnl,
                    slte: slte,
                    ghichu:ghichu,
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Gửi thành công');
                        form.resetForm();
                    }
                    else window.alert(res.message);
                }
            });
        });
    },
    resetForm: function () {
        $('#txtten').val('');
        $('#txtsdt').val('');
        $('#txtemail').val('');
        $('#myDate').val();
        $('#myTime').val();
        $('#myOptionNL').val();
        $('#myOptionTE').val();
        $('#txtGhichu').val('');
    }
}
form.init();