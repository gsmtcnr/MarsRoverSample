using MarsRoverSample.Domain.Results;

namespace MarsRoverSample.Domain.Validations
{
    public abstract class BaseValidation<T> : IValidation<T>
           where T : class, new()
    {

        public abstract IResult Validate(T data);
     
    }
}
