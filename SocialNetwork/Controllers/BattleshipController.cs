using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class BattleshipController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
