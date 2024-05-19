using Hosted.Domain.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Hosted.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [RequireTenantId(true)]
    public class TenantController : BaseController {
    }
}
