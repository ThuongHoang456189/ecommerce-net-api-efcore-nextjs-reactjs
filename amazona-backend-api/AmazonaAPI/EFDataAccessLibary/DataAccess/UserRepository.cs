using EFDataAccessLibary.DataAccess;
using EFDataAccessLibary.DTOs;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AmazonaContext _context;
        public UserRepository(AmazonaContext context)
        {
            _context = context;
        }
        public User? Login(string email)
        {
            return _context.users.FirstOrDefault(x => x.email.Equals(email));
        }

        public void Register(RegistrationInfo registrationInfo)
        {
            _context.users.Add(
                new User
                {
                    name = registrationInfo.name,
                    email = registrationInfo.email,
                    password = BCrypt.Net.BCrypt.HashPassword(registrationInfo.password, BCrypt.Net.BCrypt.GenerateSalt(13)),
                    isAdmin = false,
                    createdAt = null,
                    updatedAt = null
                });
            _context.SaveChanges();
        }
    }
}
