using System.Threading.Tasks;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.Application.Middlewares.Interfaces
{
    public interface ILoginMiddleware 
    {
        Task<UserViewModel> Authenticate(string username, string password);
    }
}