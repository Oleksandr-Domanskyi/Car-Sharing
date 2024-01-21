using CarSharingDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingDomain.Interfaces
{
    public interface ICarSharingRepositories
    {
        Task<IEnumerable<CarProfileModel?>> GetAll();
        Task<CarProfileModel?> GetByName(string name);
    }
}
