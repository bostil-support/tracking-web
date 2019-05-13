using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Services
{
    public interface IUserService
    {
       Task<TrackingUser>  GetCurrentUserAsync();
    }
}