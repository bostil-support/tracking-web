using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    [DataContract]
    public class TokenModel
    {
        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string App { get; set; }
        [DataMember]
        public string valueTenant { get; set; }
        [DataMember]
        public string redirectUrl { get; set; }
    }
}
