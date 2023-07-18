using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Recipient
{
    [Key]
    public int RecipientId { get; set; }
    public string Address { get; set; }
    public Email Email { get; set; }
}
