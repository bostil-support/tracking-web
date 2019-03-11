using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
        public string BankABI { get; set; }
    }
}
