using Microsoft.AspNetCore.Http;

namespace Hosted.Infrastructure.UsuarioContext {
    public class UsuarioContext : IUsuarioContext {
        private readonly IHttpContextAccessor _contextAccessor;
        public UsuarioContext(IHttpContextAccessor contextAccessor) {
            _contextAccessor = contextAccessor;
        }

        public string UserId {
            get {
                if (_contextAccessor != null) {
                    if (_contextAccessor.HttpContext != null) {
                        return _contextAccessor.HttpContext.User.Claims.First(x => x.Type == "UserId").Value;
                    }
                }
                return string.Empty;
            }
        }
    }
}
