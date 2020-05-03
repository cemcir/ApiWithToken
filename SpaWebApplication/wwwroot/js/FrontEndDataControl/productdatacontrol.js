function validateProductName() {
    let regex = /^[a-zA-ZğüşıöçĞÜŞİÖÇ]{2,}$/;
    let regex1 = /^\(?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})\)?[ ]?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})$/;
    let productName = document.getElementById("Name").value;
    let result1 = productName.match(regex);
    let result2 = productName.match(regex1);
    document.getElementById("productNameErrorMessage").innerHTML = "";
    if (productName == "") {
        document.getElementById("productNameErrorMessage").innerHTML = "ürün adı alanı boş bırakılamaz";
    }
    else if (productName.charAt(0) == " ") {
        document.getElementById("productNameErrorMessage").innerHTML = "ürün adının ilk karakteri boş olamaz";
    }
    else if (productName.length == 1) {
        document.getElementById("productNameErrorMessage").innerHTML = "ürün adı tek karakter olamaz";
    }
    else if (result1 == null) {
        if (result2 == null) {
            document.getElementById("productNameErrorMessage").innerHTML = "ürün ismi arasında bir karakter boşluk bırakınız";
        }
    }
};
function validateProductCategoryName() {
    let regex = /^[a-zA-ZğüşıöçĞÜŞİÖÇ]{2,}$/;
    let regex1 = /^\(?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})\)?[ ]?([a-zA-ZğüşıöçĞÜŞİÖÇ]{2,})$/;
    let productCategoryName = document.getElementById("Category").value;
    let result1 = productCategoryName.match(regex);
    let result2 = productCategoryName.match(regex1);
    document.getElementById("productCategoryNameErrorMessage").innerHTML = "";
    if (productCategoryName == "") {
        document.getElementById("productCategoryNameErrorMessage").innerHTML = "ürün kategori adı alanı boş bırakılamaz";
    }
    else if (productCategoryName.charAt(0) == " ") {
        document.getElementById("productCategoryNameErrorMessage").innerHTML = "ürün kategori adının ilk karakteri boş olamaz";
    }
    else if (productCategoryName.length == 1) {
        document.getElementById("productCategoryNameErrorMessage").innerHTML = "ürün kategori adı tek karakter olamaz";
    }
    else if (result1 == null) {
        if (result2 == null) {
            document.getElementById("productCategoryNameErrorMessage").innerHTML = "ürün kategori adı arasında bir karakter boşluk bırakınız";
        }
    }
};
function validateProductPrice() {
    let regex = /^[0-9]{1,}$/;
    let productPrice = document.getElementById("Price").value;
    let result = productPrice.match(regex);
    document.getElementById("productPriceErrorMessage").innerHTML = "";
    /*
    if (productPrice == "") {
        document.getElementById("productPriceErrorMessage").innerHTML = "";
    }
    else if (result == null) {
        document.getElementById("productPriceErrorMessage").innerHTML = "rakam dışında karakter girmeyiniz";
    }
    */
    if (productPrice < 1) {
        document.getElementById("productPriceErrorMessage").innerHTML = "ürün fiyatı 1 TL den küçük olamaz";
    }
};