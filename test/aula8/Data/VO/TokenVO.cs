namespace aula8.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool authentication, string created, string expiration, string acessToken, string refreshToken)
        {
            Authentication = authentication;
            Created = created;
            Expiration = expiration;
            AcessToken = acessToken;
            RefreshToken = refreshToken;
        }

        public bool Authentication { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
