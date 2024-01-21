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
        public async Task<IEnumerable<CarProfileModel?>> GetAll()
            =>await _dbContext.CarProfileModels.ToListAsync();
  
        public async Task<CarProfileModel?> GetByName(string name)
            =>await _dbContext.CarProfileModels.FirstOrDefaultAsync(x => x.Name == name);
    }
}