using System.Collections.Generic;

namespace MarsRoverSample.Infrastructure.Results
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
