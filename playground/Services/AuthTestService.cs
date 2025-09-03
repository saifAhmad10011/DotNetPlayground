namespace DotNetPlayground.Services
{
    public interface IAuthTestService
    {
        string GetPublicMessage();
        string GetProtectedMessage();
        string GetAdminMessage();
    }

    public class AuthTestService : IAuthTestService
    {
        public string GetPublicMessage() => "This endpoint is public.";
        public string GetProtectedMessage() => "This endpoint requires authentication.";
        public string GetAdminMessage() => "This endpoint requires Admin role.";
    }
}
