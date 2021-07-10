using MarsRoverSample.Domain.Results;
using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Domain.Rovers.Validations.Contants;
using MarsRoverSample.Domain.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class UpperCoordinateXValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (data.CoordinateX > data.Plateau.Position.UpperCoordinateForX)
            {
                return Result.Fail(string.Format(ValidationContants.Coordinate_OverValue, "X"));
            }
            return Result.Success();
        }
    }
}
