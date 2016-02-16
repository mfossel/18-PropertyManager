using PropertyManager.API.Infrastructure;
using PropertyManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PropertyManager.API.Controllers
{
    public class AccountsController : ApiController
    {
        private AuthorizationRepository _repo = new AuthorizationRepository();
        
        [AllowAnonymous]
        [Route("api/accounts/register")]
        public async Task<IHttpActionResult> Register(RegistrationModel registration)
        {
            //1. Server Side Validation
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //2. Pass the reg onto AuthReposityory
            var result = await _repo.RegisterUser(registration);

            //3. Check if reg was successful
            if(!result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Registration form was invalid.");
            }

        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
        }

    }
}
