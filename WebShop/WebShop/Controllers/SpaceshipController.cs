using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Core.Dtos;
using WebShop.Core.ServiceInterface;
using WebShop.Data;
using WebShop.Models.Spaceship;

namespace WebShop.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly WebShopDbContext _context;
        private readonly ISpaceshipService _spaceshipService;

        public SpaceshipController
            (
                WebShopDbContext context,
                ISpaceshipService spaceshipService
            )
            {
            _context = context;
            _spaceshipService = spaceshipService;


            }
        public IActionResult Index()
        {
           var result = _context.Spaceship
                .Select(x => new SpaceshipListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Mass = x.Mass,
                    Price = x.Price,
                    Crew = x.Crew,
                    ConstructedAt = x.ConstructedAt
                });

            return View(result);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipService.Delete(id);

            if (spaceship == null)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), spaceship);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SpaceshipViewModel model = new SpaceshipViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipListViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                Mass = model.Mass,
                Price = model.Price,
                Crew = model.Crew,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt
            };

            var result = await _spaceshipService.Add(dto);
            if (result == null) 
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipService.Edit(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var model = new SpaceshipViewModel();

            model.Id = spaceship.Id;
            model.Name = spaceship.Name;
            model.Type = spaceship.Type;
            model.Mass = spaceship.Mass;
            model.Price = spaceship.Price;
            model.Crew = spaceship.Crew;
            model.ConstructedAt = spaceship.ConstructedAt;
            model.CreatedAt = spaceship.CreatedAt;
            model.ModifiedAt = spaceship.ModifiedAt;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                Mass = model.Mass,
                Price = model.Price,
                Crew = model.Crew,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt
            };

            var result = await _spaceshipService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }
    }
}
