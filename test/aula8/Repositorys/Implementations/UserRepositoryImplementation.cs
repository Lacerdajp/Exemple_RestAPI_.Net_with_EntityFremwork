using aula8.Data.VO;
using aula8.Models;
using aula8.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace aula8.Repositorys.Implementations
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private readonly SqlContext _context;

        public UserRepositoryImplementation(SqlContext context)
        {
            _context = context;
        }

        public User ValidateCredential(UserVO user)
        {
            string pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            Console.WriteLine(pass);
            return _context.users.FirstOrDefault(u =>  (u.UserName == user.UserName) && (u.Password == pass));
        } 
        public User ValidateCredential(string userName)
        {
            return _context.users.SingleOrDefault(u => (u.UserName == userName));
        }
        public User RefreshUserInfo (User user)
        {
            if(!_context.users.Any(p => p.Id.Equals(user.Id)))
            {
                return null;
            }
            var result = _context.users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception )
                {
                    throw;
                }

            }
            return result;
        } 
        public bool RevokeToken(string username)
        {
            var user=_context.users.SingleOrDefault(u => u.UserName == username);
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }
        private string ComputeHash(string input, SHA256CryptoServiceProvider alghorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes=alghorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);

        }

       
    }
}
