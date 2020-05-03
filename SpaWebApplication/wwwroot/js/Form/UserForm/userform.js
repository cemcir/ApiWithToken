function userUpdateForm(id, name, surName, email,password) {
    const htmlUserUpdateForm = `
         <br/><br/><br/>
         <form>
            <div class="form-group">
                <label for="exampleInputEmail1">Ad</label>
                <input type="text" value="${name}" class="form-control" id="Name" aria-describedby="emailHelp">
                <div class="text-danger" id="name_errormessage"></div>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Soyad</label>
                <input type="text" value="${surName}" class="form-control" id="SurName">
                <div class="text-danger" id="surname_errormessage"></div>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Email</label>
                <input type="text" value="${email}" class="form-control" id="Email">
                <div class="text-danger" id="email_errormessage"></div>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Şifre</label>
                <input type="password" value="${password}" class="form-control" id="Password">
                <div class="text-danger" id="password_errormessage"></div>
            </div>
            <button type="button" value="${id}" onclick="UpdateUser(this.value)" class="btn btn-primary">Kaydet</button>
            <button type="button" onclick="cancelProfileUpdateOperation()" class="btn btn-danger">
                İptal Et
            </button>
         </form>`;

    $("#userUpdateProfileDiv").html(htmlUserUpdateForm);
    $("#userProfileDiv").hide();
    $("#userUpdateProfileDiv").show();
};
function showUserUpdateForm(id) {
    getUser(id);
   //$("#userProfileDiv").hide();
   // userUpdateForm(id, name, surName, email);
    /*
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
            $("#userProfileDiv").hide();
            userUpdateForm(data.id, data.name, data.surName, data.email);
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
    */
};
function deleteUserProfile(id) {
    $("#userProfileDiv").hide();
}
function UpdateUser(id) {
    let name = $("#Name").val();
    let surname = $("#SurName").val();
    let Email = $("#Email").val();
    let Password = $("#Password").val();
    let user = {"Id": id, "Name": name, "SurName": surname, "Email": Email, "Password": Password };
    var url = "http://localhost:58760/api/user";
    let accesstoken = localStorage.getItem("token");
    $.ajax({
        type: "PUT",
        crossDomain: true,
        url: url,
        data: JSON.stringify(user),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            console.table(data);
            document.getElementById("name_errormessage").innerHTML = "";
            document.getElementById("surname_errormessage").innerHTML = "";
            document.getElementById("errormessage").innerHTML = "";
            //document.getElementById("user_errormessage").innerHTML = "";
            document.getElementById("message").innerHTML = "profiliniz başarıyla güncellendi";
        },
        error: function (error) {
            console.error(error);
            validateName();
            validateSurName();
            validateEmail();
            validatePassword();
            //document.getElementById("user_errormessage").innerHTML = "";
            document.getElementById("errormessage").innerHTML = "";
            /*
            if (error.responseText == "kullanıcı güncellenemedi") {
                document.getElementById("email_errormessage").innerHTML = "";
                document.getElementById("user_errormessage").innerHTML = "kullanıcı gün";
            }
            */
            document.getElementById("message").innerHTML = "";
            document.getElementById("errormessage").innerHTML = "profiliniz güncellenemedi";
        },
        contentType: "application/json",
        dataType: "json"
    });
};