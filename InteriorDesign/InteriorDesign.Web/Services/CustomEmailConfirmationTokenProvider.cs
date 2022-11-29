using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace InteriorDesign.Web.Services
{
    public class CustomEmailConfirmationTokenProvider<TUser>
        : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomEmailConfirmationTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<EmailConfirmationTokenProviderOptions> options,
            ILogger<DataProtectorTokenProvider<TUser>> logger)
                : base(dataProtectionProvider, options, logger)
        {
        }
    }
}
