using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class NameEmptyValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                return Result.Fail(ValidationConstant.Name_EmptyOrNull);
            }
            return Result.Success();
        }
    }
}
