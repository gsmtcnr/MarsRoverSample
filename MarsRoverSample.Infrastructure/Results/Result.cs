using System.Collections.Generic;

namespace MarsRoverSample.Infrastructure.Results
{
    public class Result<T> : BaseResult<T>, IResult<T>
    where T : class, new()
    {
        public Result(T data) : base(data)
        {
        }

        public Result(List<string> errorMessages) : base(errorMessages)
        {
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data);
        }
        public static Result<T> Fail(string errorMessage)
        {
            return new Result<T>(new List<string> { errorMessage });
        }
        public static Result<T> Fail(List<string> errorMessages)
        {
            return new Result<T>(errorMessages);
        }
    }
    public class Result : BaseResult, IResult
    {
        public Result()
        {
        }

        public Result(List<string> errorMessages) : base(errorMessages)
        {
        }

        public static Result Success()
        {
            return new Result();
        }
        public static Result Fail(string errorMessage)
        {
            return new Result(new List<string> { errorMessage });
        }
        public static Result Fail(List<string> errorMessages)
        {
            return new Result(errorMessages);
        }
    }
}
