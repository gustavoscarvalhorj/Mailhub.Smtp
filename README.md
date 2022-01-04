# Mailhub.Smtp [![Generic badge](https://img.shields.io/badge/v1.0.0-development-green.svg)](https://shields.io/)

## Introdução
O projeto Mailhub.Smtp é a implementação do envio de e-mail através de um Smtp Server e tem como base a abstração concedida pelo pacote Mailhub.Core que está disponível aqui no [GitHub](https://github.com/gustavoscarvalhorj/MailHub.Core) e no [NuGet](https://www.nuget.org/packages/Mailhub.Core)

## Instalação
Para mais informações sobre a instalação dentro do seu projeto, acesse:

[https://www.nuget.org/packages/Mailhub.Smtp/](https://www.nuget.org/packages/Mailhub.Smtp/)

## Utilizando a classe MailhubSmtpService
Para utilizar a classe MailhubSmtpService, basta você instalar este pacote e realizar o envio conforme exemplo abaixo:

```cs
var _from = new Email("SEUEMAIL@A.COM.BR");
var _to = new Email("SEUEMAIL@A.COM.BR");
var _subject = "Este é o assunto do seu e-mail";
var _body = "<p>Este é o corpo do meu e-mail</p>";
var message = new Message(_to, _from, _subject, _body);

var _host = new Host(Environment.GetEnvironmentVariable("SMTP_HOST"));
var _port = new Port(int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT")));
var _user = Environment.GetEnvironmentVariable("SMTP_USER");
var _password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
var smtpCredentials = new SmtpCredentials(_host,_port,_user,_password);

var service = new MailhubSmtpService();
var result = await service.SendAsync(message,smtpCredentials);
```

## License
MIT: Clique [aqui](LICENSE.txt) para visualizar a licença
