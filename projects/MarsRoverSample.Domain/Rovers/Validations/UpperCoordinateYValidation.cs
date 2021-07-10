using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Domain.Rovers.Validations.Contants;
using MarsRoverSample.Infrastructure.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class UpperCoordinateYValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (data.CoordinateY > data.Plateau.Position.UpperCoordinateForY)
            {
                return Result.Fail(string.Format(ValidationContants.Coordinate_OverValue, "Y"));
            }
            return Result.Success();
        }
    }
}
