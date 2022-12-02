namespace InteriorDesign.Core.Services.Common.EmailSendService
{
    public interface IAppEmailSender
    {
        Task SendAsync(string subject, string body, string emailTo);
    }
}
