using MarsRoverSample.Domain.Results;
using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Domain.Rovers.Validations.Contants;
using MarsRoverSample.Domain.Validations;

namespace MarsRoverSample.Domain.Rovers.Validations
{
    public class PlateuNullCheckValidation : BaseValidation<CreateInputModel>, IValidation<CreateInputModel>
    {
        public override IResult Validate(CreateInputModel data)
        {
            if (data.Plateau == null)
            {
                return Result.Fail(ValidationContants.Plateu_Null);
            }
            return Result.Success();
        }
    }
}
