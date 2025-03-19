
using System.Web.Http;
using static WebAppKS.IAuthService;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using WebApplication1;

namespace WebAppKS.Controllers
{
    [System.Web.Http.RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [System.Web.Http.Route("login")]
        public IHttpActionResult Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Invalid request data.");

            var token = _authService.Authenticate(request.Username, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }

        [HttpPost]
        [System.Web.Http.Route("login-2fa")]
        public IHttpActionResult LoginWith2FA([FromBody] Login2FARequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Token))
                return BadRequest("Invalid request data.");

            var token = _authService.AuthenticateWith2FA(request.Username, request.Token);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
