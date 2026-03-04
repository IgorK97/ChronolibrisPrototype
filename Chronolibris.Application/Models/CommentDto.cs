using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    public record CommentDto(
        long Id,
        string Text,
        DateTime CreatedAt,
        long UserId,
        long? ParentCommentId,
        List<CommentDto>? Replies = null
    );
}
