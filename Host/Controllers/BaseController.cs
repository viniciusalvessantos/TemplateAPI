using Microsoft.AspNetCore.Mvc;

namespace Hosted.Controllers {
    [ApiController]
    public abstract class BaseController : ControllerBase {
        protected string TenantId => HttpContext.Items["TenantId"]?.ToString()!;
    }
}
