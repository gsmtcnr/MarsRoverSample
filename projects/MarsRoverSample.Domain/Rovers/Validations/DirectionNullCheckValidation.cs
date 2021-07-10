using MarsRoverSample.Domain.Results;
using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Domain.Rovers.Validations.Contants;
using MarsRoverSample.Domain.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class DirectionNullCheckValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (data.Direction == null)
            {
                return Result.Fail(ValidationContants.Direction_Null);
            }
            return Result.Success();
        }
    }
}
