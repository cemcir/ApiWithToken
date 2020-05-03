function showProduct() {
    $(document).ready(function () {
        let url = "http://localhost:58760/api/product";
        let accesstoken = localStorage.getItem("token");

        $.ajax({
            type: "GET",
            crossDomain: true,
            url: url,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
            },
            success: function (products) {

                var table = `
                                           <br/><br/><br/><br/> 
                                            <table class="table table-bordered">
                                                <tr>
                                                    <th>Ürün Adı</th>
                                                    <th>Kategori</th>
                                                    <th>Fiyat</th>
                                                    <th>Güncelle/Sil</th>
                                                </tr>`;
                $.each(products, (key, val) => {
                    table += `<tr>
                                                <td>${val.name}</td>
                                                <td>${val.category}</td>
                                                <td>${val.price}</td>
                                                <td>
                                                    <button class="btn btn-primary"            id="btnUpdate" value="${val.id}" onclick="productFormPage(this.value)">Güncelle
                                                    </button>/
                                                    <button type="button" class="btn btn-warning" id="btnDelete" value="${val.id}" onclick="productDelete(this.value)">Sil
                                                    </button>
                                                </td>
                                           </tr>`
                })
                table += "</table>";

                $("#productDiv").html(table);

            },
            error: function (error) {
                console.log(error);
                $("#productDiv").html("ürünler getirilemedi giriş yapınız");
            },
            contentType: "application/json",
            dataType: "json"
        });
    });
};
function productDelete(value) {
    var values = value;
    let url = "http://localhost:58760/api/product/" + value;
    let accesstoken = localStorage.getItem("token");

    $.ajax({
        type: "DELETE",
        url: url,
        crossDomain: true,
        dataType: "json",
        async: false,
        contentType: "application/json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            showProduct();
        },
        error: function (error) {

        },
    });
}
function productFormPage(id) {

    let url = "http://localhost:58760/api/product/" + id;
    let accesstoken = localStorage.getItem("token");

    $.ajax({
        type: "GET",
        crossDomain: true,
        url: url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (products) {
            productUpdateForm(products.id, products.name, products.category, products.price);

        },
        error: function (error) {

        },
        contentType: "application/json",
        dataType: "json"
    });
};
function updateProduct(value) {

    let name = $("#Name").val();
    let price = $("#Price").val();
    let category = $("#Category").val();

    let url = "http://localhost:58760/api/product/" + value;
    let accesstoken = localStorage.getItem("token");
    let product = { "Name": name, "Price": price, "Category": category };
    $.ajax({
        type: "PUT",
        url: url,
        crossDomain: true,
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(product),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (products) {
            window.alert("ürün güncellendi");
        },
        error: function (error) {

        },
    });
};
function productPageShow() {
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

            const productContent = `
            <div class="container">
                <div class="row">
                    <div class="col-md-3">

                        <div class="list-group">
                            <h1>Liste</h1>
                            <a href="#" id="link" onclick="showProduct()" class="list-group-item">
                                <span class="glyphicon glyphicon-arrow-right"></span>Ürünleri Listele
                    </a>
                            <a href="/Home/ProductRegister" id="addProductLink" class="list-group-item">
                                <span class="glyphicon glyphicon-arrow-right"></span>Ürün Ekle
                    </a>
                        </div>
                    </div>
                    <div id="productDiv" class="col-md-9">

                    </div>
                </div>
            </div>`;
            $("#productListDiv").html(productContent);
        },
        error: function (error) {
            console.log(error);
            /*
            if (error.status == 401) {
                getUserDataRefreshToken();
            }
            else {
                window.location = "/Home/Login";
            }
            */
        },
        contentType: "application/json",
        dataType: "json"
    });
};
function addProduct() {
    let name = $("#Name").val();
    let price = $("#Price").val();
    let category = $("#Category").val();

    let url = "http://localhost:58760/api/products";
    let accesstoken = localStorage.getItem("token");
    let product = { "Name": name, "Price": price, "Category": category };
    $.ajax({
        type: "POST",
        url: url,
        crossDomain: true,
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(product),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (products) {
            document.getElementById("productRegisterErrorMessage").innerHTML = "";
            document.getElementById("productNameErrorMessage").innerHTML = "";
            document.getElementById("productCategoryNameErrorMessage").innerHTML = "";
            document.getElementById("productPriceErrorMessage").innerHTML = "";
            document.getElementById("productRegisterMessage").innerHTML = "ürün başarıyla eklendi";
        },
        error: function (error) {
            validateProductName();
            validateProductCategoryName();
            validateProductPrice();
            document.getElementById("productRegisterMessage").innerHTML = "";
            document.getElementById("productRegisterErrorMessage").innerHTML = "ürün eklenemedi";
        },
    });
};
function getProductRegister() {
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
            const htmlProducts = `
            <br/><br/><br/>
            <form>
                <div class="form-group">
                    <label for="exampleInputEmail1">Ürün Adı</label>
                    <input type="text" class="form-control" id="Name" aria-describedby="emailHelp">
                    <div class="text-danger" id="productNameErrorMessage"></div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Kategori</label>
                    <input type="text" class="form-control" id="Category">
                    <div class="text-danger" id="productCategoryNameErrorMessage"></div>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Fiyat</label>
                    <input type="number" min="1" class="form-control" id="Price">
                    <div class="text-danger" id="productPriceErrorMessage"></div>
                </div>
                <button type="button" onclick="addProduct()" class="btn btn-primary">Kaydet</button>
            </form>`;
            $("#productRegisterForm").html(htmlProducts);
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