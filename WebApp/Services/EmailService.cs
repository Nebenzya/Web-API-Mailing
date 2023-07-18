using MailKit.Net.Smtp;
using MimeKit;
using WebApp.Models.DTO;

namespace WebApp.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Отправляет сообщение, используя <see cref="SmtpClient"/>
    /// </summary>
    /// <param name="email">Объект используется для отправки сообщения</param>
    /// <returns>Возвращает текст ошибки. При отсутствие ошибок возваращает пустую строку</returns>
    public string SendEmail(EmailDTO email)
    {
        try
        {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(_config["EmailAddress"]));

            if (email.Recipients?.Length > 0)
            {
                foreach (var address in email.Recipients)
                    message.To.Add(MailboxAddress.Parse(address));
            }
            else
                throw new Exception("No delivery destination");
            
            message.Subject = email.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = email.Body };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_config["EmailHost"], int.Parse(_config["EmailPort"]), MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_config["EmailAddress"], _config["EmailPassword"]);
                smtp.Send(message);
                smtp.Disconnect(true);
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return string.Empty;
    }
}
