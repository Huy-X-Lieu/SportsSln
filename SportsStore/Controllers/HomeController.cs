using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View();
    }
}
