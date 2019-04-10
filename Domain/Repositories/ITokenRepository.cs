using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Repositories
{
    public interface ITokenRepository
    {
        string Decrypt(string data);
    }
}
