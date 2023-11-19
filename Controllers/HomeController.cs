using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormValidationsPractice.Models;

namespace FormValidationsPractice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("user/create")]
    public IActionResult Register(User newUser){
        // Evalua si el modelo paso las validaciones, si estas no pasan, redirecciones la url que se requiera, para que los errores persistan, deberia redireccionar a la misma url dond esta el formilario. para este caso es el Index.
        // Pero hay que asegurarse de que el formulario contenga los errores para poder redireccionarlo a la misma página donde esta el formulari, por tal motivo se realizad un if evaluando el estado del modelo, si es valido lo deje pasar de lo contrario que lo redireccione a la url que corresponda
        if(ModelState.IsValid){
            Console.WriteLine(newUser.Name);
            Console.WriteLine(newUser.Lastname);
            Console.WriteLine(newUser.Email);
            Console.WriteLine(newUser.Password);

            return RedirectToAction("Index");
        }else{
            return View("Index");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
