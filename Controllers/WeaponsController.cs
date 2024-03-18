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
            var weapons = repo.GetWeapon(id);
            return View(weapons);
        }

        public IActionResult UpdateWeapon(int id)
        {
            Weapons gun = repo.GetWeapon(id);
            if (gun == null)
            {
                return View("WeaponNotFound");
            }
            return View(gun);
        }

        public IActionResult UpdateWeaponToDatabase(Weapons weapons)
        {
            repo.UpdateWeapon(weapons);

            return RedirectToAction("ViewWeapon", new { id = weapons.Gun_Id });
        }

        public IActionResult InsertWeapon (Weapons weaponsToInsert) 
        {
            return View(weaponsToInsert);
        }

        public IActionResult InsertWeaponToDatabase(Weapons weaponsToInsert)
        {
            repo.InsertWeapon(weaponsToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteWeapon(Weapons weapons)
        {
            repo.DeleteWeapon(weapons);
            return RedirectToAction("Index");
        }


    }
}
