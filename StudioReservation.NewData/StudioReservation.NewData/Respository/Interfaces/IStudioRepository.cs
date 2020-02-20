using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository.Interfaces 
{
    public interface IStudioRepository 
    {
        Task<ICollection<Studio>> GetAllStudiosAvailable();
    }
}