$("#idTest").on("click", function (e) {
    e.prevenDefault();
    $.ajax({
        type: "post",
        datatype: "json",
        url: "/Contact/test",
        data: {
            firstName: "Doan",
            lastName: "Xem",
        },
        success:function(data)
        {
            console.log(data.message);
        }
});
});
