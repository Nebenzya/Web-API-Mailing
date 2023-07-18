using WebApp.Models.DTO;

namespace WebApp.Data.Interface;

public interface IEmailRepository
{
    /// <summary>
    /// Возвращает все сохранённые записи
    /// </summary>
    /// <returns>коллекцию объектов <see cref="EmailDTO"/></returns>
    public IEnumerable<EmailDTO> GetEmails();

    /// <summary>
    /// Добавляет запись об объектe, 
    /// которая будет сохранена при вызове метода <see cref="IEmailRepository.Save"/>
    /// </summary>
    /// <param name="email">Объект, который будет записан</param>
    public void Create(EmailDTO email);

    /// <summary>
    /// Сохраняет все полученные изменения
    /// </summary>
    /// <returns>Возвращает количество изменённых строк</returns>
    public int Save();
}
