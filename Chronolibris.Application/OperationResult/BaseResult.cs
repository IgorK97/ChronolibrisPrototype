using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Application.OperationResult
{
    public class BaseResult
    {

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
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static BaseResult Success() => new(true, Error.None);
        public static BaseResult Failure(Error error) => new(false, error);
    }
}
