using System.Collections.Generic;

namespace MarsRoverSample.Domain.Results
{
    public abstract class BaseResult<T> : IResult<T>
     where T : class, new()
    {
        public BaseResult()
        {

        }
        public BaseResult(T data)
        {
            Data = data;
            IsSuccess = true;
        }
        public BaseResult(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
            IsSuccess = false;
        }
        public T Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public List<string> ErrorMessages { get; private set; }
    }
    public abstract class BaseResult : IResult
    {
        public BaseResult()
        {
            IsSuccess = true;
        }

        public BaseResult(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
            IsSuccess = false;
        }
        public bool IsSuccess { get; private set; }
        public List<string> ErrorMessages { get; private set; }
    }
}
