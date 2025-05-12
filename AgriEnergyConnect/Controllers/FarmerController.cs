using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnect.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FarmerController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            var farmer = _context.Farmers.FirstOrDefault(f => f.Email == user.Email);
            var products = _context.Products.Where(p => p.FarmerId == farmer.FarmerId).ToList();
            return View(products);
        }

        public IActionResult AddProduct() => View();

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var farmer = _context.Farmers.FirstOrDefault(f => f.Email == user.Email);
                product.FarmerId = farmer.FarmerId;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyProducts");
            }
            return View(product);
        }
    }

}
