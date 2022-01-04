using Mailhub.Core.Domain.Model;
using Mailhub.Core.Domain.ValueObject;
using Mailhub.Smtp.Domain.Model;
using Mailhub.Smtp.Domain.ValueObject;
using System;
using Xunit;

namespace Mailhub.Smtp.Test
{
    public class MailhubSmtpServiceTest : IClassFixture<EnvFixture>
    {
        [Fact]
        public async void IsSended()
        {
            var _from = new Email(Environment.GetEnvironmentVariable("EMAIL_TO"));
            var _to = new Email(Environment.GetEnvironmentVariable("EMAIL_FROM"));
            var _subject = "Teste";
            var _body = "<p>Este é o corpo do meu e-mail</p>";
            var message = new Message(_to, _from, _subject, _body);

            var _host = new Host(Environment.GetEnvironmentVariable("SMTP_HOST"));
            var _port = new Port(int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT")));
            var _user = Environment.GetEnvironmentVariable("SMTP_USER");
            var _password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
            var smtpCredentials = new SmtpCredentials(_host,_port,_user,_password);

            var service = new MailhubSmtpService();
            var result = await service.SendAsync(message,smtpCredentials);
            Assert.False(result.HasErrors);
        }
    }
}