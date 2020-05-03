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
            getUserData();
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
function getUserData() {
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
            //navbarMenu(data);
            
            const userContent = `
               
            <div class="container">
                <div class="row">
                    <h2>Profiliniz</h2>
                    <hr />
                </div>
                <div class="row">
                    <div class="col-md-2">
                    <img src="/images/userboy.jpg" class="img-circle" with="128" height="128" />
                </div>

                <div class="col-md-8">
                    <h3>${data.name}  ${data.surName}</h3>
                    <br />
                    <h6><b>Username:</b>${data.id}</h6>
                    <h6><b>Email:</b>${data.email}</h6>
                    <br />
                    <h6><a href="#">More... </a></h6>
                </div>

                <div class="col-md-2 text-right">
                    <div class="btn-group">
                    <a class="btn dropdown-toggle btn-info" data-toggle="dropdown" href="#">
                        <span class="glyphicon glyphicon-cog">&nbsp;</span>İşlemler
                        <span class="icon-cog icon-white"></span><span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>
                            <a>
                                <span class="glyphicon glyphicon-edit">&nbsp;</span>
                                <button value="${data.id}" type="button" onclick="showUserUpdateForm(this.value)">
                                Düzenle
                                </button>
                            </a>
                        </li>
                        <li> 
                            <a>
                                <button value="${data.id}" onclick="userDelete(this.value)">
                                <span class="glyphicon glyphicon-log-out text-danger">&nbspSil</span>
                                </button>
                            </a>
                        </li>
                    </ul>
                </div>
                </div>
            </div>
            </div>`;
            //document.body.innerHTML = html;
            $("#userProfileDiv").html(userContent);
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
function getData() {
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
            window.alert("hello world");
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
function userDelete(value) {
    var r = confirm("Hesabınızı silmek istediğinizden emin misiniz?");
    if (r == true) {
    //let url = "http://localhost:58760/api/user/" + values;

    let url = "http://localhost:58760/api/user";
    let accesstoken = localStorage.getItem("token");
    var data = { "Id": value };
        $.ajax({
            type:"DELETE",
            url: url,
            crossDomain: true,
            dataType: "json",
            async: false,
            contentType: "application/json",
            data: JSON.stringify(data),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
            },
            success: function (data) {
                localStorage.clear();
                window.alert("hesabınız başarılı bir şekilde silindi");
                window.location = "/Home/Login";
            },
            error: function (error) {
                window.alert("hesabınız silinemedi");
                console.log(error);   
            },
        });
    }
};
function getUser(value) {

    var url = "http://localhost:58760/api/user/" + value;
    //var url = "http://localhost:58760/api/default";
    let accesstoken = localStorage.getItem("token");
    //var data = { "Id": value };

    $.ajax({
        //type: "POST",
        type:"GET",
        url: url,
        //async: false,
        crossDomain: true,
        contentType: "application/json",
        dataType: "json",
        //data: JSON.stringify(data),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            $("#userProfileDiv").hide();
            userUpdateForm(data.id, data.name, data.surName, data.email, data.password);
        },
        error: function (error) {
            console.log(error);
            if (error.status == 401) {
                getUserDataRefreshToken();
            }
            else {
                //window.location = "/Home/Login";
            }
        },
    });
    
};
function give() {
    window.alert("hello world");
};
