using Mailhub.Core.Domain.Contracts;
using Mailhub.Core.Domain.Model;
using Mailhub.Core.Resource.ExtensionMethods;
using Mailhub.Smtp.Domain.Model;
using System.Net.Mail;

namespace Mailhub.Smtp
{
    public class MailhubSmtpService : IEmailService<Message, SmtpCredentials>
    {
        public async Task<Result> SendAsync(Message message, SmtpCredentials smtp)
        {
            try
            {
                using (var client = new SmtpClient(smtp.Host.ToString(), smtp.Port))
                {
                    client.EnableSsl = smtp.UseSSL;
                    client.Credentials = new System.Net.NetworkCredential(smtp.User, smtp.Password);
                    await client.SendMailAsync(message.toMailMessage());
                    return new Result();
                }
            }
            catch (Exception ex)
            {
                return new Result(new List<String>() { ex.Message });
            }
        }
    }
}
