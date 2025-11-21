using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.OperationResult
{
    /// <summary>
    /// Представляет результат операции, которая возвращает значение определенного типа <typeparamref name="T"/> в случае успеха.
    /// Наследует базовую функциональность Result Pattern от <see cref="BaseResult"/>.
    /// </summary>
    /// <typeparam name="T">Тип значения, которое будет возвращено при успешном завершении операции.</typeparam>
    public class Result<T> : BaseResult
    {
        public readonly T? _value;

        /// <summary>
        /// Защищенный конструктор для создания успешного результата.
        /// </summary>
        /// <param name="value">Значение типа <typeparamref name="T"/>, которое будет инкапсулировано в результат.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если предпринята попытка инициализировать успешный результат 
        /// с <c>null</c> для ссылочного типа, что является нарушением инварианта.</exception>
        private Result(T? value) : base(true, Error.None)
        {
            if(value is null && typeof(T).IsValueType == false)
            {
                throw new ArgumentNullException("Incorrect try to initialize result by null");
            }

            _value = value;
        }

        /// <summary>
        /// Защищенный конструктор для создания неудачного результата.
        /// </summary>
        /// <param name="error">Объект <see cref="Error"/>, описывающий причину неудачи.</param>
        private Result(Error error):base(false, error)
        {
            _value = default;
        }

        /// <summary>
        /// Получает значение, инкапсулированное в результат. 
        /// </summary>
        /// <exception cref="InvalidOperationException">Выбрасывается, если попытка доступа к значению 
        /// совершается, когда <see cref="BaseResult.IsFailure"/> равен <c>true</c>.</exception>
        public T Value
        {
            get
            {
                if (IsFailure)
                {
                    throw new InvalidOperationException("Value can only be accessed on a successful result.");
                }

                return _value!;
            }
        }

        /// <summary>
        /// Статический фабричный метод для создания успешного результата с инкапсулированным значением.
        /// </summary>
        /// <param name="value">Значение, которое будет возвращено.</param>
        /// <returns>Новый экземпляр <see cref="Result{T}"/>, представляющий успех.</returns>
        public static Result<T> Success(T value) => new(value);

        /// <summary>
        /// Статический фабричный метод для создания неудачного результата. Скрывает (shadows) базовый метод <see cref="BaseResult.Failure(Error)"/>.
        /// </summary>
        /// <param name="error">Объект <see cref="Error"/>, описывающий причину неудачи.</param>
        /// <returns>Новый экземпляр <see cref="Result{T}"/>, представляющий неудачу.</returns>
        public static new Result<T> Failure(Error error) => new(error);



    }
}
