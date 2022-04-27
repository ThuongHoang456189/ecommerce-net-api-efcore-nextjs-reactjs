using EFDataAccessLibary.DTOs;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;

namespace AmazonaAPI.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public User? Login(LoginInfo loginInfo)
        {
            User? found = _repository.Login(loginInfo.email);
            if (found != null && BCrypt.Net.BCrypt.Verify(text: loginInfo.password, hash: found.password))
                return found;
            return null;
        }
        public bool Register(RegistrationInfo registrationInfo)
        {
            if(_repository.Login(registrationInfo.email) == null)
            {
                _repository.Register(registrationInfo);
                return true;
            }
            return false;
        }
    }
}
