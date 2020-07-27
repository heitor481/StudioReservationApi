using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.NewData.Repository.Interfaces 
{
    public interface IStudioRepository 
    {
        Task<ICollection<StudioViewModel>> GetAllStudiosAvailable();

        Task<Studio> GetStudiosById(int studioId);

        Task<ICollection<StudioRoom>> ListAllRoomsFromStudio(int studioId);
    }
}