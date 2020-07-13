using ExpenseApp.Business.Contracts;
using ExpenseApp.Entites;
using ExpenseApp.Web.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseApp.Web
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        readonly IUserManager _userManager;
        AuthController()
        {
        }
        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<bool> Register([FromBody]User user)
        {
            return await _userManager.Register(user);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody]UserDto userModel)
        {
            var user = await _userManager.AuthenticateUser(userModel.EmailId, userModel.Password);

            if (user == null)
                return BadRequest("Username or password are incorrect");

            return Ok(user);
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}
