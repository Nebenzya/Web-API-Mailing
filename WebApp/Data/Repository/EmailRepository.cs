using WebApp.Data.Interface;
using WebApp.Models;
using WebApp.Models.DTO;

namespace WebApp.Data.Repository;

public class EmailRepository : IEmailRepository
{
    private readonly WebApiContext _context;

    public EmailRepository(WebApiContext context)
    {
        _context = context;
    }

    public void Create(EmailDTO email)
    {
        var emailDB = new Email()
        {
            Body = email.Body,
            Subject = email.Subject,
            Date = DateTime.Now,
            Result = string.IsNullOrWhiteSpace(email.FailedMessage) ? "OK" : "Failed",
            FailedMessage = email.FailedMessage,
        };

        _context.Emails.Add(emailDB);

        if (email.Recipients?.Length > 0)
        {
            foreach (var item in email.Recipients)
            {
                _context.Recipients.Add(
                    new Recipient()
                    {
                        Address = item,
                        Email = emailDB
                    });
            }
        }
    }

    public IEnumerable<EmailDTO> GetEmails()
    {
        return from e in _context.Emails
               select new EmailDTO()
               {
                   Body = e.Body,
                   Subject = e.Subject,
                   Date = e.Date,
                   Result = e.Result,
                   FailedMessage = e.FailedMessage,
                   Recipients = (from s in _context.Recipients
                                 where s.Email.EmailId == e.EmailId
                                 select s.Address).ToArray()
               };
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
