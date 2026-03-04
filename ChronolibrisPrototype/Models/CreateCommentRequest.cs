namespace ChronolibrisPrototype.Models
{
    public record CreateCommentRequest(
         long BookId,
         string Text,
         long? ParentCommentId = null
     );
}
