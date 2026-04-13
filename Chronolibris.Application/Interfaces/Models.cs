using System.Text.Json;
using System.Text.Json.Serialization;
using Chronolibris.Domain.Models;

namespace Chronolibris.Application.Interfaces
{

    /// <summary>
    /// Настройки процесса конвертации
    /// </summary>
    public sealed class ConversionOptions
    {
        /// <summary>
        /// Целевое число элементов (абзацев, разрывов, заголовков) в одном фрагменте
        /// </summary>
        public int TargetPartSize { get; init; } = 100;
    }

    /// <summary>Корень toc.json.</summary>
    public sealed class TocDocument
    {
        [JsonPropertyName("Meta")]
        public required BookMeta Meta { get; init; }

        [JsonPropertyName("full_length")]
        public int FullLength { get; set; }

        [JsonPropertyName("Body")]
        public required List<TocBodyEntry> Body { get; init; }

        [JsonPropertyName("Parts")]
        public required List<TocPartEntry> Parts { get; init; }
    }

    /// <summary>Запись верхнего уровня Body: описывает всю книгу или её том.</summary>
    public sealed class TocBodyEntry
    {
        [JsonPropertyName("s")]
        public int S { get; set; }

        [JsonPropertyName("e")]
        public int E { get; set; }

        [JsonPropertyName("t")]
        public string? T { get; set; }

        [JsonPropertyName("c")]
        public List<TocChapterEntry>? C { get; set; }
    }

    /// <summary>Запись одной главы / раздела в Body.</summary>
    public sealed class TocChapterEntry
    {
        [JsonPropertyName("s")]
        public int S { get; set; }

        [JsonPropertyName("e")]
        public int E { get; set; }

        [JsonPropertyName("t")]
        public string? T { get; set; }
    }

    /// <summary>Запись одного фрагментного файла в Parts.</summary>
    public sealed class TocPartEntry
    {
        [JsonPropertyName("s")]
        public int S { get; set; }

        [JsonPropertyName("e")]
        public int E { get; set; }

        [JsonPropertyName("xps")]
        public required int[] Xps { get; set; }

        [JsonPropertyName("xpe")]
        public required int[] Xpe { get; set; }

        [JsonPropertyName("url")]
        public required string Url { get; set; }
    }

    // ─────────────────────────────────────────────────────────────────────────────
    // Элементы фрагмента (*.js)
    // ─────────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Один элемент JSON-фрагмента верхнего уровня.
    ///
    /// Поле c сериализуется по правилу:
    ///   • нет сносок  → просто строка:           "c": "текст абзаца"
    ///   • есть сноски → массив строк и Note:     "c": ["текст", {t:"note",...}, "продолжение"]
    ///   • br          → поле c отсутствует
    /// </summary>
    [JsonConverter(typeof(PartElementJsonConverter))] //Что такое typeof и что он здесь делает?
    public sealed class PartElement
    {
        public required string T { get; init; }
        public required int[] Xp { get; init; }

        /// <summary>
        /// Null → br (нет поля c).
        /// string → абзац без сносок (c = строка).
        /// List&lt;object&gt; → абзац со сносками (c = массив строк и NoteSegment).
        /// </summary>
        public object? C { get; init; }
    }

    /// <summary>
    /// Note-сегмент внутри смешанного массива c.
    /// Сериализуется как обычный JSON-объект {t,role,xp,c,f}.
    /// Текстовые части массива — просто string.
    /// </summary>
    public sealed class NoteSegment
    {
        [JsonPropertyName("t")]
        public string T { get; init; } = "note";

        [JsonPropertyName("role")]
        public string Role { get; init; } = "footnote";

        /// <summary>xp сноски в notes-body.</summary>
        [JsonPropertyName("xp")]
        public required int[] Xp { get; init; }

        /// <summary>Видимая метка, например "[4]".</summary>
        [JsonPropertyName("c")]
        public required string C { get; init; }

        [JsonPropertyName("f")]
        public required FootnoteContent F { get; init; }
    }

    /// <summary>
    /// Раскрытое содержимое сноски.
    /// c — список параграфов; каждый параграф — строка (простой текст сноски).
    /// </summary>
    public sealed class FootnoteContent
    {
        [JsonPropertyName("t")]
        public string T { get; init; } = "footnote";

        [JsonPropertyName("xp")]
        public required int[] Xp { get; init; }

        /// <summary>
        /// Параграфы сноски. Каждый параграф — строка.
        /// (Если понадобится смешанный контент внутри сносок — расширить до List&lt;object&gt;.)
        /// </summary>
        [JsonPropertyName("c")]
        public required List<string> C { get; init; }
    }

    // ─────────────────────────────────────────────────────────────────────────────
    // Кастомный сериализатор для PartElement
    // ─────────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Сериализует PartElement так, чтобы поле c было:
    ///   • строкой  — если C имеет тип string
    ///   • массивом — если C имеет тип List&lt;object&gt; (строки + NoteSegment)
    ///   • отсутствовало — если C == null
    /// </summary>
    public sealed class PartElementJsonConverter : JsonConverter<PartElement>
    {
        public override PartElement Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
            => throw new NotSupportedException("Десериализация PartElement не реализована.");

        public override void Write(Utf8JsonWriter writer,
            PartElement value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("t", value.T);
            writer.WritePropertyName("xp");
            JsonSerializer.Serialize(writer, value.Xp, options);

            switch (value.C)
            {
                case null:
                    // br — поле c не пишем
                    break;

                case string plainText:
                    // Абзац без сносок → "c": "строка"
                    writer.WriteString("c", plainText);
                    break;

                case int pageNum:
                    // Номер страницы → "c": 10
                    writer.WriteNumber("c", pageNum);
                    break;

                case List<object> mixed:
                    // Абзац со сносками → "c": ["текст", {note}, "текст", ...]
                    writer.WritePropertyName("c");
                    writer.WriteStartArray();
                    foreach (var item in mixed)
                    {
                        if (item is string s)
                            writer.WriteStringValue(s);
                        else
                            JsonSerializer.Serialize(writer, item, item.GetType(), options);
                    }
                    writer.WriteEndArray();
                    break;
            }

            writer.WriteEndObject();
        }
    }

    // ─────────────────────────────────────────────────────────────────────────────
    // Промежуточные структуры парсера
    // ─────────────────────────────────────────────────────────────────────────────

    /// <summary>Элемент, накапливаемый в процессе обхода XML до разбивки на фрагменты.</summary>
    public sealed class ParsedElement
    {
        public required string Type { get; init; }   // p / br / title / subtitle

        /// <summary>
        /// null        → br
        /// string      → абзац без сносок
        /// List&lt;object&gt; → абзац со сносками (строки + NoteSegment)
        /// </summary>
        public object? Content { get; init; }

        // Координата
        public int BodyIndex { get; set; }
        public int SectionIndex { get; set; }
        public int ElemIndex { get; set; }

        // Глобальный порядковый номер (s в Parts)
        public int GlobalIndex { get; set; }

        // Плоский текст — только для BuildChapters / CalculateFullLength
        public string? Text { get; init; }
    }

    /// <summary>
    /// Сегмент курсивного текста внутри абзаца: {t:"em", c:"текст"}.
    /// </summary>
    public sealed class EmSegment
    {
        [JsonPropertyName("t")]
        public string T { get; init; } = "em";

        [JsonPropertyName("c")]
        public required string C { get; init; }
    }

    /// <summary>
    /// Сегмент жирного текста внутри абзаца: {t:"st", c:"текст"}.
    /// </summary>
    public sealed class StSegment
    {
        [JsonPropertyName("t")]
        public string T { get; init; } = "st";

        [JsonPropertyName("c")]
        public required string C { get; init; }
    }


    /// <summary>
    /// Сегмент изображения. Используется как элемент верхнего уровня (t="p" с единственным img)
    /// или как вложенный сегмент внутри абзаца.
    /// {t:"img", src:"1.jpg", w:768, h:230}
    /// w/h — null если размер не удалось определить.
    /// </summary>
    public sealed class ImgSegment
    {
        [JsonPropertyName("t")]
        public string T { get; init; } = "img";

        /// <summary>Имя файла в MinIO: "1.jpg", "2.png" и т.д.</summary>
        [JsonPropertyName("src")]
        public required string Src { get; init; }
    }
}