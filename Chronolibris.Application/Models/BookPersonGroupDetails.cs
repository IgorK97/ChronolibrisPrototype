using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.Models
{
    /// <summary>
    /// Представляет группу людей, выполняющих определенную роль 
    /// при создании или публикации книги (например, все авторы или все редакторы).
    /// </summary>
    public class BookPersonGroupDetails
    {
        /// <summary>
        /// Идентификатор роли, которую выполняет данная группа людей 
        /// по отношению к книге (например, ID для "Автор" или "Переводчик").
        /// </summary>
        public required long Role { get; set; }

        //public required string RoleName { get; set; }

        /// <summary>
        /// Коллекция <see cref="PersonDetails"/>, представляющая всех людей, 
        /// выполняющих указанную <see cref="Role"/>.
        /// Инициализируется пустым списком.
        /// </summary>
        public IEnumerable<PersonDetails> Persons { get; set; } = [];
    }
}
