using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class DirectionNullCheckValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (data.Direction == null)
            {
                return Result.Fail(ValidationConstant.Direction_Null);
            }
            return Result.Success();
        }
    }
}
