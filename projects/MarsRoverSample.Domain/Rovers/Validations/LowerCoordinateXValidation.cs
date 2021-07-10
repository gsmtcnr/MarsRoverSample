using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class LowerCoordinateXValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (data.CoordinateX < data.Plateau.Position.LowerCoordinateForX)
            {
                return Result.Fail(string.Format(ValidationConstant.Coordinate_LowValue, "X"));
            }
            return Result.Success();
        }
    }
}
