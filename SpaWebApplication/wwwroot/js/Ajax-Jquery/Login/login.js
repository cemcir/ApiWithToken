function logOut() {
    $(document).ready(function () {
        let refreshToken = localStorage.getItem("refreshToken");

        var url = "http://localhost:58760/api/login/revokerefreshtoken";

        var data = { "RefreshToken": refreshToken };

        $.ajax({
            type: "POST",
            url: url,
            crossDomain: true,
            data: JSON.stringify(data),
            success: function (data) {
                console.log(data);
                localStorage.setItem("token", data.token);
                localStorage.setItem("refreshToken", data.refreshToken);
                window.location = "/Home/Login";
            },
            error: function (error) {

                if ("refreshtoken bulunamadı" == error.responseText) {
                    localStorage.setItem("token", null);
                    localStorage.setItem("refreshToken", null);
                    window.location = "/Home/Login";
                }
                console.log(error.responseText);
            },
            contentType: "application/json",
            dataType: "json"
        });
    });
};
function getUserDataRefreshToken() {
    let refreshToken = localStorage.getItem("refreshToken");

    var url = "http://localhost:58760/api/login/refreshtoken";

    var data = { "RefreshToken": refreshToken };

    $.ajax({
        type: "POST",
        url: url,
        async: false,
        crossDomain: true,
        data: JSON.stringify(data),
        success: function (data) {
            console.log(data);
            localStorage.setItem("token", data.token);
            localStorage.setItem("refreshToken", data.refreshToken);
            // $("#userDiv").hide();
           // getUserData();
            tokenTest();
        },
        error: function (error) {

            if ("refreshtoken bulunamadı" == error.responseText || "refreshtoken suresi dolmus" == error.responseText) {
                window.location = "/Home/Login";

            }
            console.log(error.responseText);
        },
        contentType: "application/json",
        dataType: "json"
    });
};