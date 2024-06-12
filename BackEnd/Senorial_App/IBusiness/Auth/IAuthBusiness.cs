using RequestResponseModels.Request.Auth;
using RequestResponseModels.Response.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Auth
{
    public interface IAuthBusiness
    {
        LoginResponse LoginDashboard(LoginDashboardRequest request);
    }
}
