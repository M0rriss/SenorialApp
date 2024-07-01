using CommonModels.Common;

namespace App_Senorial.Middleware
{
    public interface IHelperHttpContext
    {
        InfoRequest GetInfoRequest(HttpContext request);
    }
}
