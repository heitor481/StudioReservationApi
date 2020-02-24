using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.Application.Middlewares.Interfaces 
{
    public interface IStudioMiddleware 
    {
        Task<ICollection<StudioViewModel>> ListAllStudioAvaiable();
    }
}