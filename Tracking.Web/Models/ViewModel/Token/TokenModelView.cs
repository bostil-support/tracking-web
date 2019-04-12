using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Tracking.Web.Models.ViewModel.Auth
{
   
    public class TokenModelView
    {      
        public string userName { get; set; }
        public string App { get; set; } 
        public string redirectUrl { get; set; }
    }
}
