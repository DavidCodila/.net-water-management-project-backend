$(document).ready(function () {
    $("#myForm").submit(function (e) {
        e.preventDefault(); // Prevent the default form submission
<<<<<<< HEAD
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
=======

        var formData = new FormData();
        formData.apartmentType = $("input[name=optradio]:checked", '#myForm').val()
        var appartmenttype = $("#appartmentType").val();

        console.log("Data from button: " + formData.apartmentType);
        console.log("Data fron textbox: " + appartmenttype)
        debugger;

>>>>>>> dev
        formData.corporationRatio = $("#corporationRatio").val();
        formData.borewellRatio = $("#borewellRatio").val();

        $.ajax({
<<<<<<< HEAD
            type: "POST",
            url: "/WaterAccounts/AddWaterAccount",
            data: JSON.stringify(formData),
            contentType: "application/json; charset=utf-8",
            success: success,
            dataType: "json"
          });

})})
=======
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
>>>>>>> dev
