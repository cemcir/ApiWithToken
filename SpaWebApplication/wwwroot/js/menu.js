function navbarMenu(data) {
    const html = `
    <div>
        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a asp-area="" asp-controller="Home" asp-action="Index" class="navbar-brand">
                        SpaWebApplication
                    </a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="/Home/HomePage">
                                Home
                            </a>
                        </li>
                        <li>
                            <a asp-area="" asp-controller="Home" asp-action="About">About</a>
                        </li>
                            <li>
                                <a href="#">
                                    Contact
                                </a>
                            </li>
                     </ul>
                     <ul class="nav navbar-nav pull-right">
                        <li>
                            <a href="/Home/Profiler">
                            <span class="glyphicon glyphicon"></span>${data.name + " " + data.surName}
                            </a>
                        </li>
                        <li>
                            <a>
                                <button id="btnLogOut" onclick="logOut()">
                                    <span class="glyphicon glyphicon-log-out text-          danger">Çıkış
                                    </span>
                                </button>
                            </a>
                        </li>
                     </ul>
                </div>
            </div>
        </nav>
    </div>

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
    
     document.body.innerHTML = html;
   
};


