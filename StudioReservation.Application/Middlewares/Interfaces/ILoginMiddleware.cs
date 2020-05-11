using System.Threading.Tasks;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.Shared.Entity;

namespace StudioReservation.Application.Middlewares.Interfaces 
{
    public interface ILoginMiddleware 
    {
        Task<ApiResponse<UserViewModel>> Authenticate(string username, string password);
    }
}