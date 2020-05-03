using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaWebApplication.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool Test;

        public UserViewModel()
        {
            this.Test = false;
        }
    }
}
