using Microsoft.AspNetCore.Mvc;


namespace Tasks.WebApi.Controllers
{

    
    [Produces("application/json")]
    [Route("api/init")]
    public class InitController : Controller
    {

                
        // GET api/init
        public string Index()
        {

            return "Aplication ON";
        }


    }
}
