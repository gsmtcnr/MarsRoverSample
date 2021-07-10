using MarsRoverSample.Infrastructure.Results;

namespace MarsRoverSample.Infrastructure.Validations
{
    public abstract class BaseValidation<T> : IValidation<T>
           where T : class, new()
    {

        public abstract IResult Validate(T data);
     
    }
}
