using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.MvpApp.Controllers
{
    public class BlogController : Controller
    {
        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            return View();
        }
    }
}
