using aula8.Configurations;
using aula8.Data.VO;
using aula8.Repositorys;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Data;
using System.Security.Claims;

namespace aula8.Services.Implementations
{
    
    public class LoginServiceImplementations : ILoginServices
    {
        private const string dateFormat = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _Configuration;
        private IUserRepository _repository;
        private readonly ITokenInterface _tokenIterface;

        public LoginServiceImplementations(TokenConfiguration configuration, 
            IUserRepository repository, ITokenInterface tokenIterface)
        {
            _Configuration = configuration;
            _repository = repository;
            _tokenIterface = tokenIterface;
        }

        public TokenVO ValidationCredentials(UserVO userCredential)
        {
            var user = _repository.ValidateCredential(userCredential);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)
            };
            var acessToken = _tokenIterface.GenerateAcessToken(claims);
            var refreshToken = _tokenIterface.GenereteRefreshToken();
            user.RefreshToken=refreshToken;
            _repository.RefreshUserInfo(user);
            user.RefreshTokenExpiryTime=DateTime.Now.AddDays(_Configuration.DaysToExpiry);
            
            DateTime createDate= DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_Configuration.Minutes);

           
            return new TokenVO(
                true,createDate.ToString(dateFormat),
                expirationDate.ToString(dateFormat),
                acessToken,
                refreshToken

                );
        }

        public TokenVO ValidationCredentials(TokenVO token)
        {
            var acessToken = token.AcessToken;
            var refreshToken =token.RefreshToken;

            var principal=_tokenIterface.GetPrincipalFromExpiredToken(acessToken);
            string username = principal.Identity.Name;
            var user = _repository.ValidateCredential(username);
            var dateTime=DateTime.Now;
            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= dateTime
                ) return null;
            acessToken = _tokenIterface.GenerateAcessToken(principal.Claims);
            refreshToken = _tokenIterface.GenereteRefreshToken();
            user.RefreshToken=refreshToken;
            _repository.RefreshUserInfo(user);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_Configuration.Minutes);


            return new TokenVO(
                true, createDate.ToString(dateFormat),
                expirationDate.ToString(dateFormat),
                acessToken,
                refreshToken

                );
        }

        public bool RevokeToken(string username)
        {
            return _repository.RevokeToken(username);
        }
    }
}
