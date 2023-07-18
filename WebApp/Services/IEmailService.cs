using WebApp.Models.DTO;

namespace WebApp.Services;

public interface IEmailService
{
    /// <summary>
    /// Отправляет сообщение
    /// </summary>
    /// <param name="email">Объект используется для отправки сообщения</param>
    /// <returns>Возвращает текст ошибки</returns>
    public string SendEmail(EmailDTO email);
}
