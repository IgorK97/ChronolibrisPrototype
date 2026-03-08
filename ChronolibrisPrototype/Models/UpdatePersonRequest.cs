public class UpdatePersonRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Если null — картинку не трогаем. 
    // Если пустая строка — возможно, пользователь хочет удалить фото (опционально).
    public string? ImageBase64 { get; set; }
    public string? FileName { get; set; }
}