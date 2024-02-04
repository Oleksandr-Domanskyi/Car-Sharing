﻿using CarSharingDomain.DomainModels;
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
  
        public async Task<CarProfileModel?> GetByName(Guid id)
            =>await _dbContext.CarProfileModels.Include(img=>img.Image).FirstOrDefaultAsync(Enteties => Enteties.Id == id);
        public async Task SaveChanges()
            => await _dbContext.SaveChangesAsync();
       
        //Images Repositories

        public async Task<Image?> GetImageById(Guid imageId)
            => await _dbContext.Images.FirstOrDefaultAsync(Enteties => Enteties.Id == imageId);

        public async Task DeleteImageById(Guid id)
        {
            var image = await _dbContext.Images.FirstOrDefaultAsync(src => src.Id == id);
            if (image == null)
            {
                throw new ArgumentException(message:"Some problem with Repositories");
            }
            _dbContext.Images.Remove(image);
            await _dbContext.SaveChangesAsync();
           
        }
    }
}
