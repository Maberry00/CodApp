using CodApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodApp.Controllers
{
    public class WeaponsController : Controller
    {

        private readonly IWeaponsRepository repo;

        public WeaponsController(IWeaponsRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var weapons = repo.GetAllWeapons();

            return View(weapons);
        }

        public IActionResult ViewWeapons(int id)
        {
            var weapons = repo.GetWeapons(id);
            return View(weapons);
        }

        public IActionResult UpdateWeapon(int id)
        {
            Weapons gun = repo.GetWeapons(id);
            if (gun == null)
            {
                return View("WeaponNotFound");
            }
            return View(gun);
        }

        public IActionResult UpdateWeaponToDatabase(Weapons weapons)
        {
            repo.UpdateWeapons(weapons);

            return RedirectToAction("ViewWeapon", new { id = weapons.Gun_Id });
        }

    }
}
