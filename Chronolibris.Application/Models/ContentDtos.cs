// File: Chronolibris.Application.Models.ContentDtos.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chronolibris.Application.Models
{
    public class ContentDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CountryId { get; set; }
        public string? CountryName { get; set; }
        public long ContentTypeId { get; set; }
        public string? ContentType { get; set; }
        public long LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public int? Year { get; set; }
        public long? ParentContentId { get; set; }
        public int? Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<string> Authors { get; set; } = new();
        public List<ThemeDto> Themes { get; set; } = new();
        public int BooksCount { get; set; }
    }

    public class CreateContentRequest
    {
        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public long CountryId { get; set; }

        [Required]
        public long ContentTypeId { get; set; }

        [Required]
        public long LanguageId { get; set; }

        public int? Year { get; set; }
        public long? ParentContentId { get; set; }
        public int? Position { get; set; }
        public List<long> PersonIds { get; set; } = new();
        public List<long> ThemeIds { get; set; } = new();
    }

    public class UpdateContentRequest
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public long CountryId { get; set; }

        [Required]
        public long ContentTypeId { get; set; }

        [Required]
        public long LanguageId { get; set; }

        public int? Year { get; set; }
        public long? ParentContentId { get; set; }
        public int? Position { get; set; }
        public List<long> PersonIds { get; set; } = new();
        public List<long> ThemeIds { get; set; } = new();
    }

    

    public class ContentListResponse
    {
        public List<ContentDto> Items { get; set; } = new();
        public string? NextCursor { get; set; }
        public string? PrevCursor { get; set; }
        public int TotalCount { get; set; }
        public bool HasMore { get; set; }
    }
}