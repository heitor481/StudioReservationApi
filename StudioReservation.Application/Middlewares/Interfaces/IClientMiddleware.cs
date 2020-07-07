using System.Threading.Tasks;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.Application.Middlewares.Interfaces
{
    public interface IClientMiddleware
    {
        Task<bool> CreateClient(CreateClientViewModel createClient);
    }
}