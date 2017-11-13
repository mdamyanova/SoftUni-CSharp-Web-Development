namespace CarDealer.Web.Controllers
{
    using Services.Contracts;
    using Services.Models.Parts;
    using Microsoft.AspNetCore.Mvc;

    public class PartsController : Controller
    {
        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        [HttpGet("parts/all")]
        public IActionResult All()
        {
            var model = this.parts.All();
            return this.View(model);
        }

        [HttpGet("parts/create")]
        public IActionResult Create() => this.View();

        [HttpPost("parts/create")]
        public IActionResult Create(PartFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var supplierExists = this.parts.SupplierExists(model.SupplierName);

            if (!supplierExists)
            {
                return this.NotFound();
            }
          
            this.parts.Create(model.Name, model.Price, model.SupplierName);
            return this.RedirectToAction(nameof(this.Create));
        }
    }
}