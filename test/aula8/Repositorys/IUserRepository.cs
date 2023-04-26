using aula8.Data.VO;
using aula8.Models;

namespace aula8.Repositorys
{
    public interface IUserRepository
    {
        User ValidateCredential(UserVO user);
        User ValidateCredential(string userName);
        bool RevokeToken(string username);
        User RefreshUserInfo(User user);
    }
}
