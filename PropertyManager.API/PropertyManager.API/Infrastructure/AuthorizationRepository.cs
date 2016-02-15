using Microsoft.AspNet.Identity;
using PropertyManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PropertyManager.API.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PropertyManager.API.Infrastructure
{
    public class AuthorizationRepository :IDisposable
    {
        private PropertyManagerDataContext _db;

        private UserManager<PropertyManagerUser> _userManager = new UserManager<PropertyManagerUser>(new UserStore<PropertyManagerUser>());

        public AuthorizationRepository()
        {
            _db = new PropertyManagerDataContext();
            _userManager = new UserManager<PropertyManagerUser>(new UserStore<PropertyManagerUser>(_db));
        }

        public async Task<IdentityResult> RegisterUser(RegistrationModel model)
        {           

            var propertyManagerUser = new PropertyManagerUser
            {
                UserName = model.Username

            };

            var result = await _userManager.CreateAsync(propertyManagerUser, model.Password);

            return result;
        }



        public void Dispose()
        {
            _userManager.Dispose();
        }

    }
}