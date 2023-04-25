using aula8.Data.VO;
using aula8.Models;

namespace aula8.Repositorys
{
    public interface IUserRepository
    {
        User ValidateCredential(UserVO user);
        User RefreshUserInfo(User user);
    }
}
