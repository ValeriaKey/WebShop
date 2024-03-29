﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;

namespace WebShop.Core.ServiceInterface
{
    public interface ISpaceshipService : IApplicationService
    {
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Add(SpaceshipDto dto);
        Task<Spaceship> GetAsync(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);


    }
}
