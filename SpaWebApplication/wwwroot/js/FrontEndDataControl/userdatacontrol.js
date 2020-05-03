function validateName() {
    let regex = /^[a-zA-ZğüşıöçĞÜŞİÖÇ]{3,}$/;
    let regex1 = /^\(?([a-zA-ZğüşıöçĞÜŞİÖÇ]{3,})\)?[ ]?([a-zA-ZğüşıöçĞÜŞİÖÇ]{3,})$/;
    let name = document.getElementById("Name").value;
    let result1 = name.match(regex);
    let result2 = name.match(regex1);
    document.getElementById("name_errormessage").innerHTML = "";
    //window.alert(result);
    if (name == "") {
        document.getElementById("name_errormessage").innerHTML = "isim alanı boş bırakılamaz";
    }
    else if (name.charAt(0) == " ") {
        document.getElementById("name_errormessage").innerHTML = "ismin ilk karakteri boş olamaz";
        //return;
    }
    else if (result1 == null) {
        if (result2 == null) {
            document.getElementById("name_errormessage").innerHTML = "isim arasında bir karakter boşluk bırakınız";
            //return;
        }
    }

    /*
    else if (result1 == null) {
        if (result2 == null) {
            document.getElementById("errormessage").innerHTML = "yanlış giriş";
            return;
        }
    }
    */
};
function validateSurName() {
    let regex = /^[a-zA-ZğüşıöçĞÜŞİÖÇ]{2,}$/;
    let surName = document.getElementById("SurName").value;
    let result = surName.match(regex);
    document.getElementById("surname_errormessage").innerHTML = "";
    if (surName == "") {
        document.getElementById("surname_errormessage").innerHTML = "soyisim alanı boş bırakılamaz";
    }
    else if (surName.charAt(0) == " ") {
        document.getElementById("surname_errormessage").innerHTML = "soyisimin ilk karakteri boş olamaz";
        return;
    }
    else if (result == null) {
        document.getElementById("surname_errormessage").innerHTML = "yanlış giriş";
        return;
    }
};
function validateEmail() {
    let regex = /[a-zA-Z0-9_\.\-]/g;
    let regex1 = /(hotmail.com|gmail.com|outlook.com)/g;
    let test = false;
    let email = document.getElementById("Email").value;

    let result = email.match(regex);
    document.getElementById("message").innerHTML = "";
    document.getElementById("email_errormessage").innerHTML = "";
    
    if (email == "") {
        document.getElementById("email_errormessage").innerHTML = "e-posta alanı boş bırakılamaz";
    }
    
    else {
        for (var i = 0; i < email.length; i++) {
            var s = email.charCodeAt(i);
            if (s == 64) {
                test = true;
                break;
            }
        }
        if (test == false) {
            document.getElementById("email_errormessage").innerHTML = "@ işareti koymayı unutmayınız";
        }
        else if (email.match(regex) == null || email.match(regex1) == null) {
            document.getElementById("email_errormessage").innerHTML = "yanlış giriş";
        }
    }
    
};
function validatePassword() {
    var password = document.getElementById("Password").value;
    var patt1 = /^[0-9]{3}$/;
    var pattern = /^[a-zA-Z0-9]{1}$/;
    var pattern1 = /[a-z]/g;
    var pattern2 = /[A-Z]/g;
    var pattern3 = /[0-9]/g;
    var pattern4 = /[+*-_.\?]/g;
    var regex = /^\(?([+*-_.\?a-zA-Z0-9]{1})\)?[\s]?([+*-_.\?a-zA-Z0-9]{1})?[\s]?([+*-_.\?a-zA-Z0-9]{1})?[\s]?([+*-_.\?a-zA-Z0-9]{1})?[\s]?([+*-_.\?a-zA-Z0-9]{4})$/;
    var result = password.match(patt1);
    var result1 = password.match(regex);
    var result2 = password.match(pattern1);
    document.getElementById("password_errormessage").innerHTML = "";

    if (password == "") {
        document.getElementById("password_errormessage").innerHTML = "şifre alanı boş bırakılamaz";
    }
    else if (password.match(pattern4) == null) {
        document.getElementById("password_errormessage").innerHTML = "şifrede en az bir tane özel karakter bulunmalıdır";
    }
    else if (password.match(pattern1) == null) {
        document.getElementById("password_errormessage").innerHTML = "şifrede en az bir tane küçük harf bulunmalıdır";
        //return;
    }
    else if (password.match(pattern2) == null) {
        document.getElementById("password_errormessage").innerHTML = "şifrede en az bir tane büyük harf bulunmalıdır";
        //return;
    }
    else if (password.match(pattern3) == null) {
        document.getElementById("password_errormessage").innerHTML = "şifrede en az bir tane rakam bulunmalıdır";
        //return;
    }
    else if (password.length != 8) {
        document.getElementById("password_errormessage").innerHTML = "şifre 8 karakter olmalıdır";
        //return;
    }
};