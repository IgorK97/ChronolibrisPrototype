using System.ComponentModel.DataAnnotations;

namespace ChronolibrisWeb.InputModels
{
    public record CreateCommentInputModel(
         [Range(1, long.MaxValue, ErrorMessage = "Книга не указана")]
         long BookId,
         [MaxLength(5000, ErrorMessage ="Максимальная длина комментария - 5000 символов")]
         [MinLength(1, ErrorMessage ="Комментарий должен быть написан")]
         [Required(ErrorMessage ="Комментарий должен быть написан")]
         string Text,
         long? ParentCommentId = null
     );
}
