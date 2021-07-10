using MarsRoverSample.Infrastructure.Results;

namespace MarsRoverSample.Infrastructure.Validations
{
    public interface IValidation<T>
        where T : class, new()
    {
        IResult Validate(T data);
    }
}
