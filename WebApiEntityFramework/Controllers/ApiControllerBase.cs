using Microsoft.AspNetCore.Mvc;

namespace WebApiEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller {  }
}
