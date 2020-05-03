function tokenTest() {
    let url = "http://localhost:58760/api/user";
    let accesstoken = localStorage.getItem("token");

    $.ajax({
        type: "GET",
        url: url,
        async: false,
        crossDomain: true,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            navbarMenu(data);
        },
        error: function (error) {
            console.log(error);
            if (error.status == 401) {
                getUserDataRefreshToken();
            }
            else {
                window.location = "/Home/Login";
            }
        },
        contentType: "application/json",
        dataType: "json"
    });
};