﻿using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GT86Registry.Web.Controllers
{
    [Authorize]
    public class GarageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly VehicleRepository _vehicleRepository;

        public GarageController(VehicleRepository vehicleRepository, UserManager<ApplicationUser> userManager)
        {
            _vehicleRepository = vehicleRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var user2 = User.Identity.Name;
            var vehicles = _vehicleRepository.GetVehiclesByUserId(user.Id);

            return View(vehicles);
        }

        public IActionResult AddVehicle()
        {
            var vm = new AddVehicleViewModel();

            return View(vm);
        }

        public IActionResult AddVehicle(AddVehicleViewModel viewModel)
        {
            return View();
        }

        public IActionResult EditVehicle()
        {
            return View();
        }

        public IActionResult DeleteVehicle()
        {
            return View();
        }
    }
}