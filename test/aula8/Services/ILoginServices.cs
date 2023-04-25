using aula8.Data.VO;

namespace aula8.Services
{
    public interface ILoginServices
    {
        TokenVO ValidationCredentials(UserVO user);
    }
}
