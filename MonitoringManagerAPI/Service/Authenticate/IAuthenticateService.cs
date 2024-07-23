namespace MonitoringManagerAPI.Service.Authenticate
{
    public interface IAuthenticateService
    {
        public string Authenticate(string userName, string password);
    }
}
