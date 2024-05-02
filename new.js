$(document).ready(function () {
    $("#myForm").submit(function (e) {
        e.preventDefault(); // Prevent the default form submission

        var formData = new FormData();
        formData.apartmentType = $("input[name=optradio]:checked", '#myForm').val()
        var appartmenttype = $("#appartmentType").val();

        console.log("Data from button: " + formData.apartmentType);
        console.log("Data fron textbox: " + appartmenttype)
        debugger;

        formData.corporationRatio = $("#corporationRatio").val();
        formData.borewellRatio = $("#borewellRatio").val();

        $.ajax({
            url: "/WaterAccounts/AddWaterAccount",
            type: "POST",
            data: JSON.stringify(formData),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.success) {
                    alert(result.message);
                } else {
                    error: function error(jqXhr, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                }
            },
    });
});})