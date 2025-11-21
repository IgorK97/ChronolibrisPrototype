using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.OperationResult
{
    public class Result<T> : BaseResult
    {
        public readonly T? _value;

        private Result(T? value) : base(true, Error.None)
        {
            if(value is null && typeof(T).IsValueType == false)
            {
                throw new ArgumentNullException("Incorrect try to initialize result by null");
            }

            _value = value;
        }

        private Result(Error error):base(false, error)
        {
            _value = default;
        }

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

        public static Result<T> Success(T value) => new(value);

        public static new Result<T> Failure(Error error) => new(error);



    }
}
