using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Domain.Interfaces.Services;
using MediatR;

public record UpdatePersonCommand(
    long Id,
    string Name,
    string Description,
    byte[]? ImageData,
    string? FileName) : IRequest;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IGenericRepository<Person> _repository;
    private readonly IStorageService _fileService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonHandler(IGenericRepository<Person> repository, IStorageService fileService, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePersonCommand request, CancellationToken token)
    {
        var person = await _repository.GetByIdAsync(request.Id, token);
        if (person == null) throw new KeyNotFoundException("Person not found");

        // Обновляем текстовые поля
        person.Name = request.Name;
        person.Description = request.Description;
        //person.UpdatedAt = DateTime.UtcNow;

        // Логика работы с изображением
        if (request.ImageData != null && request.ImageData.Length > 0)
        {
            // 1. Сохраняем старый путь, чтобы удалить файл позже
            var oldImagePath = person.ImagePath;

            // 2. Загружаем новое изображение
            using var stream = new MemoryStream(request.ImageData);
            var newPath = await _fileService.UploadFileAsync(stream, request.FileName ?? "updated.jpg", "image/jpeg", token);

            // 3. Обновляем путь в сущности
            person.ImagePath = newPath;

            // 4. Удаляем старый файл из MinIO (если это не дефолтная заглушка)
            if (!string.IsNullOrEmpty(oldImagePath) && oldImagePath != "default.png")
            {
                await _fileService.DeleteFileAsync(oldImagePath, token);
            }
        }

        _repository.Update(person);
        await _unitOfWork.SaveChangesAsync(token);
    }
}