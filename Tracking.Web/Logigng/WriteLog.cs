using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Logigng
{
    public static class WriteLog
    {        
        
       public static void Write(this ILogger logger, string message)
       {
          logger.LogError(message);
       }
        
    }
}
