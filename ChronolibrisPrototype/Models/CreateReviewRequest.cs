namespace ChronolibrisPrototype.Models
{
    public class CreateReviewRequest
    {
        public long BookId { get; init; }
        public string? ReviewText { get; init; }
        public short Score { get; init; }
    }
}
