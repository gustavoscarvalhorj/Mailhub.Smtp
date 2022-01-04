using Mailhub.Smtp.Domain.ValueObject;

namespace Mailhub.Smtp.Domain.Model
{
    public class SmtpCredentials
    {
        public Host Host { get;  }
        public Port Port { get; }
        public bool UseSSL { get; private set; }
        public string User { get; }
        public string Password { get; }

        public SmtpCredentials(Host host, Port port, string user, string password)
        {
            Host = host;
            Port = port;
            User = user;
            Password = password;
            UseSSL = true;
        }

        public void DisableSSL()
        {
            UseSSL = false;
        }
    }
}
