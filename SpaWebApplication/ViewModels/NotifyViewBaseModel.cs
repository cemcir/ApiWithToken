using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaWebApplication.ViewModels
{
    public class NotifyViewModelBase
    {
        public string Header { get; set; }
        public string Title { get; set; }
        public string RedirectingUrl { get; set; }
        public int RedirectingTimeout { get; set; }

        public NotifyViewModelBase()
        {
            Header = "Yönlendiriliyorsunuz!";
            Title = "Geçersiz İşlem";
            RedirectingUrl = "/Home/Login";
            RedirectingTimeout = 5000;
        }

    }

}

