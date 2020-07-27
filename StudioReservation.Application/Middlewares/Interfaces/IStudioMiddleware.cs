using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.Application.Middlewares.Interfaces 
{
    public interface IStudioMiddleware 
    {
        Task<ICollection<StudioViewModel>> ListAllStudioAvaiable();

        Task<ICollection<StudioRoom>> ListAllRoomsFromStudio(int studioId);
    }
}