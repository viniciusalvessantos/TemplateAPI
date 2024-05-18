using Microsoft.AspNetCore.Mvc;

namespace Hosted.Controllers {
    /// <summary>
    ///  Base controle, responsavel por capturar variaveis que deve ser Global nos controles 
    /// </summary>
    public abstract class BaseController : ControllerBase {
        protected string? TenantId => HttpContext.Items["TenantId"]?.ToString()!;
    }
}
