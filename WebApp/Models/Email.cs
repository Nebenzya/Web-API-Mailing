using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Email
{
    [Key]
    public int EmailId { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
    public string Result { get; set; }
    public string FailedMessage { get; set; } = null;
}
