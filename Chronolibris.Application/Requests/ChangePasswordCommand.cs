using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Chronolibris.Application.Requests
{
    public class ChangePasswordCommand : IRequest<Unit> // Unit означает, что команда не возвращает данных
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public long UserId { get; set; } // Добавляем ID пользователя
    }
}
