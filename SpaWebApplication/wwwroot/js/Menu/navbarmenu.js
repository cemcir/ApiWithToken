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
                        Full Stack Web Uygulaması
                    </a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="/Home/Product">
                                Ana Sayfa
                            </a>
                        </li>
                     </ul>
                     <ul class="nav navbar-nav pull-right">
                        <li>
                            <a href="/Home/Profiler">
                            <span class="glyphicon glyphicon-user"></span>${data.name + " " + data.surName}
                            </a>
                        </li>
                        <li>
                            <a>
                                <button id="btnLogOut" onclick="logOut()">
                                    <span class="glyphicon glyphicon-log-out text-danger">Çıkış
                                    </span>
                                </button>
                            </a>
                        </li>
                     </ul>
                </div>
            </div>
        </nav>
    </div>`;        

    //document.body.innerHTML = html;
    $("#navbarMenuProfile").html(html);
    $("#navbarMenuProduct").html(html);
    $("#navbarMenuProductRegister").html(html);
};


