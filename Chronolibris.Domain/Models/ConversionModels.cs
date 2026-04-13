using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chronolibris.Domain.Models
{
    public sealed class ConversionResult
    {
        public required string BookId { get; init; }

        public required BookMeta Meta { get; init; }

        public int TotalElements { get; init; }

        public required StoredFileInfo TocFile { get; init; }

        public required IReadOnlyList<StoredFileInfo> PartFiles { get; init; }

        public DateTimeOffset CompletedAt { get; init; } = DateTimeOffset.UtcNow;
    }

    public sealed class StoredFileInfo
    {
        public required string BookId { get; init; }

        public required string FileName { get; init; }

        public required StoredFileType FileType { get; init; }

        public int GlobalStart { get; init; }

        public int GlobalEnd { get; init; }

        public int[]? XpStart { get; init; }

        public int[]? XpEnd { get; init; }

        public long SizeBytes { get; init; }
    }

    public enum StoredFileType
    {
        Toc,
        Part
    }

    public sealed record BookMeta
    {
        [JsonPropertyName("Annotation")]
        public string? Annotation { get; init; }

        [JsonPropertyName("Lang")]
        public string? Lang { get; init; }

        [JsonPropertyName("Title")]
        public string? Title { get; init; }

        [JsonPropertyName("Sequences")]
        public List<string>? Sequences { get; init; }

        [JsonPropertyName("Created")]
        public string? Created { get; init; }

        [JsonPropertyName("Updated")]
        public string? Updated { get; init; }

        [JsonPropertyName("Written")]
        public WrittenInfo? Written { get; init; }

        [JsonPropertyName("Authors")]
        public List<AuthorInfo>? Authors { get; init; }

        [JsonPropertyName("ArtID")]
        public string? ArtId { get; init; }

        [JsonPropertyName("UUID")]
        public string? Uuid { get; init; }
    }


    public sealed record WrittenInfo
    {
        [JsonPropertyName("DatePublic")]
        public string? DatePublic { get; init; }

        [JsonPropertyName("Date")]
        public string? Date { get; init; }
    }

    public sealed record AuthorInfo
    {
        [JsonPropertyName("Role")]
        public string Role { get; init; } = "author";

        [JsonPropertyName("First")]
        public string? First { get; init; }

        [JsonPropertyName("Last")]
        public string? Last { get; init; }
    }

}
