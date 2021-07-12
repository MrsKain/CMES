using Cnty.Core.BaseProvider;
using Cnty.Core.Utilities;
using Cnty.Entity.DomainModels;
using System.Threading.Tasks;

namespace Cnty.System.IServices
{
    public partial interface ISys_UserService
    {

        Task<WebResponseContent> Login(LoginInfo loginInfo, bool verificationCode = true);
        Task<WebResponseContent> ReplaceToken();
        Task<WebResponseContent> ModifyPwd(string oldPwd, string newPwd);
        Task<WebResponseContent> GetCurrentUserInfo();
    }
}

