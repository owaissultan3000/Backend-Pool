namespace carpool.Services.UserServices
{
    public interface IJwtAuthentication
    {
        string Authenticate(string email, string password);
    }
}