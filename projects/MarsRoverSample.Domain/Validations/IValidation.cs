using MarsRoverSample.Domain.Results;

namespace MarsRoverSample.Domain.Validations
{
    public interface IValidation<T>
        where T : class, new()
    {
        IResult Validate(T data);
    }
}
