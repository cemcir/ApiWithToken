function showProduct() {
    $("#link").click(function () {
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
                                <br/><br/><br/>
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
                                            <button class="btn btn-primary" id="btnUpdate" value="${val.id}" onclick="getButtonValue(this.value)">Güncelle
                                            </button>/
                                            <button type="button" id="btnDelete" value="${val.id}" onclick="productDelete()">Sil
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