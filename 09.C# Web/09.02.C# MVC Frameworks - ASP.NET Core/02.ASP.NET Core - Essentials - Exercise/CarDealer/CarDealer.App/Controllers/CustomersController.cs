namespace CarDealer.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        public IActionResult All()
        {    
            return this.View();
        }
    }
}