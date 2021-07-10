using System.Collections.Generic;

namespace MarsRoverSample.Domain.Results
{
    public interface IResult
    {
        public bool IsSuccess { get; }
        public List<string> ErrorMessages { get; }
    }

    public interface IResult<T> : IResult
    where T : class, new()
    {
        public T Data { get; }

    }
}
