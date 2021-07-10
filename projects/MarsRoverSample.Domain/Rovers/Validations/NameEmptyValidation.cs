using MarsRoverSample.Domain.Results;
using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Domain.Rovers.Validations.Contants;
using MarsRoverSample.Domain.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class NameEmptyValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                return Result.Fail(ValidationContants.Name_EmptyOrNull);
            }
            return Result.Success();
        }
    }
}
