using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class LowerCoordinateYValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (data.CoordinateY < data.Plateau.Position.LowerCoordinateForY)
            {
                return Result.Fail(string.Format(ValidationConstant.Coordinate_LowValue, "Y"));
            }
            return Result.Success();
        }
    }
}
