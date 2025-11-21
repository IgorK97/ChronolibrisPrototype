using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.OperationResult
{

    /// <summary>
    /// Базовый класс, реализующий шаблон Result Pattern (Шаблон Результата).
    /// Используется для представления результата операции, который может быть либо успешным (<see cref="IsSuccess"/>), 
    /// либо неудачным (<see cref="IsFailure"/>) с конкретной ошибкой (<see cref="Error"/>).
    /// </summary>
    public class BaseResult
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BaseResult"/>. 
        /// Конструктор защищен, чтобы гарантировать создание результатов только через статические фабричные методы.
        /// </summary>
        /// <param name="_IsSuccess">Флаг, указывающий на успех операции.</param>
        /// <param name="error">Объект ошибки, описывающий причину неудачи. Должен быть <c>Error.None</c> при успехе.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если логика Result Pattern нарушена 
        /// (например, успех указан с ненулевой ошибкой или неудача указана без ошибки).</exception>
        protected BaseResult(bool _IsSuccess, Error error)
        {
            if(IsSuccess && error !=Error.None ||
                !IsSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = _IsSuccess;
            Error = error;
        }

        /// <summary>
        /// Получает значение, указывающее, завершилась ли операция успешно.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Получает значение, указывающее, завершилась ли операция неудачей.
        /// Это удобное свойство, эквивалентное <c>!IsSuccess</c>.
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Получает объект ошибки, связанный с результатом. 
        /// Если <see cref="IsSuccess"/> равен <c>true</c>, это свойство будет <c>Error.None</c>.
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Статический фабричный метод для создания успешного результата.
        /// </summary>
        /// <returns>Новый экземпляр <see cref="BaseResult"/>, где <see cref="IsSuccess"/> = <c>true</c> и <see cref="Error"/> = <c>Error.None</c>.</returns>
        public static BaseResult Success() => new(true, Error.None);

        /// <summary>
        /// Статический фабричный метод для создания неудачного результата.
        /// </summary>
        /// <param name="error">Объект <see cref="Error"/>, описывающий причину неудачи.</param>
        /// <returns>Новый экземпляр <see cref="BaseResult"/>, где <see cref="IsSuccess"/> = <c>false</c> и <see cref="Error"/> = <paramref name="error"/>.</returns>
        public static BaseResult Failure(Error error) => new(false, error);
    }
}
