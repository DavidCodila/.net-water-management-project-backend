$(document).ready(function () {
    $("#myForm").submit(function (e) {
        e.preventDefault(); // Prevent the default form submission
        var formData = new FormData();
        if ($('#input[id=radio1]').is(':checked')) {
            formData.appartmentType = "2BHK";
        }
        else {
            formData.appartmentType = "3BHK";
        }
        console.log(formData.appartmentType);
        debugger;
        //formData.appartmentType = $("#appartmentType").val();
        formData.corporationRatio = $("#corporationRatio").val();
        formData.borewellRatio = $("#borewellRatio").val();

        $.ajax({
            type: "POST",
            url: "/WaterAccounts/AddWaterAccount",
            data: JSON.stringify(formData),
            contentType: "application/json; charset=utf-8",
            success: success,
            dataType: "json"
          });

})})