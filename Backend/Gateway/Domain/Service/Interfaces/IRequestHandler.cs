namespace ECommerceAPIGateway.Domain.Service.Interfaces
{
    public interface IRequestHandler
    {
        Task<string> SendRequest(dynamic? body, string service, string endpoint, string httpMethod);
    }
}
