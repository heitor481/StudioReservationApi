using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.Application.Middlewares.Interfaces 
{
    public interface IStudioMiddleware 
    {
        Task<ICollection<Studio>> ListAllStudioAvaiable();
    }
}