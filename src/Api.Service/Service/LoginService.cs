using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;

namespace Api.Service.LoginService
{
    public class LoginService : ILoginService
    {
        private IuserRepository _repository;
        public LoginService(IuserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            var baseUser = new UserEntity();
            if (user != null && !String.IsNullOrWhiteSpace(user.Email))
            {
                return await _repository.FindByLogin(user.Email);
                // if (baseUser == null)
                // {
                //     return null;
                // }
                // else
                // {
                //     return baseUser;
                // }
            }
            else
            {
                return null;
            }
        }
    }
}
