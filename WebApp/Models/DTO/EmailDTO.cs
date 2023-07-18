namespace WebApp.Models.DTO;

public class EmailDTO
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public string[] Recipients { get; set; }
    public DateTime Date { get; set; } = DateTime.MinValue;
    public string Result { get; set; } = string.Empty;
    public string FailedMessage { get; set; } = string.Empty;

}
