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
                UserName = model.Username,
                Email = model.EmailAddress

            };

            var result = await _userManager.CreateAsync(propertyManagerUser, model.Password);

            return result;
        }

        public async Task<PropertyManagerUser> FindUser(string username, string password)      
        {
            return await _userManager.FindAsync(username, password);
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }

    }
}