function NgayGio() {
    var date = new Date();
    document.getElementById('myDate').valueAsDate = date;
    document.getElementById('myTime').defaultValue = "19:00"
}

function addOptionNguoiLon() {
    var i = 1;

    for (i; i < 50; i++) {
        var x = document.getElementById("myOptionNL");
        var option = document.createElement("option");
        option.text = i + " người lớn";
        x.add(option);
    }
}

function addOptionTreEm() {
    var j = 0;
    for (j; j < 50; j++) {
        var y = document.getElementById("myOptionTE");
        var option = document.createElement("option");
        option.text = j + " trẻ em";
        y.add(option);
    }
}