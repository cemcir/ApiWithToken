function productRegisterForm() {
    const htmlProductForms = `
         <br/><br/><br/>
         <form>
            <div class="form-group">
                <label for="exampleInputEmail1">Ürün Adı</label>
                <input type="text"  class="form-control" id="Name" aria-describedby="emailHelp">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Kategori</label>
                <input type="text"  class="form-control" id="Category">
            </div>
            <div class="form-group">
                <input type="number" class="form-control" id="Price">
            </div><label for="exampleInputPassword1">Fiyat</label>
                
            <button type="button" onclick="" class="btn btn-primary">okul</button>
         </form>`;

    $("#productRegisterDivs").html(htmlProductForms);
};
function productUpdateForm(id, name, category, price) {

    const html = `
         <br/><br/><br/>
         <form>
            <div class="form-group">
                <label for="exampleInputEmail1">Ürün Adı</label>
                <input type="text" value="${name}" class="form-control" id="Name" aria-describedby="emailHelp">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Kategori</label>
                <input type="text" value="${category}" class="form-control" id="Category">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Fiyat</label>
                <input type="number" value="${price}" class="form-control" id="Price">
            </div>
            <button type="button" value="${id}" onclick="updateProduct(this.value)" class="btn btn-primary">
                Kaydet
            </button>
         </form>`;

    $("#productDiv").html(html);
};
function productRegister() {
    const htmlProductRegister = `
    <br/><br/><br/>
    <form>
        <div class="form-group">
            <label for="exampleInputEmail1">Ürün Adı</label>
            <input type="text"  class="form-control" id="Name" aria-describedby="emailHelp">
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Kategori</label>
            <input type="text"  class="form-control" id="Category">
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Fiyat</label>
            <input type="number" class="form-control" id="Price">
        </div>
        <button type="button" onclick="" class="btn btn-primary">okul</button>
    </form>`;
    $("#productRegisterDiv").html(htmlProductRegister);
};