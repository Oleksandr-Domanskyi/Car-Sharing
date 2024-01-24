using CarSharingDomain.DomainModels;
using CarSharingDomain.Interfaces;
using CarSharingInfrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingInfrastructure.Repositories
{
    public class CarSharingRepositories : ICarSharingRepositories
    {
        private readonly CarSharingDbContext _dbContext;

        public CarSharingRepositories(CarSharingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CarProfile Repositories

        public async Task Create(CarProfileModel model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarProfileModel?>> GetAll()
            =>await _dbContext.CarProfileModels.Include(img=>img.Image).ToListAsync();
  
        public async Task<CarProfileModel?> GetByName(string name)
            =>await _dbContext.CarProfileModels.FirstOrDefaultAsync(Enteties => Enteties.Name == name);


        //Images Repositories

        public async Task<Image?> GetImageById(Guid imageId)
            => await _dbContext.Images.FirstOrDefaultAsync(Enteties => Enteties.Id == imageId);
       
    }
}
