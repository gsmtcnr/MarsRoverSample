using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;

namespace MarsRoverSample.Domain.Plateaus.Validations
{
    public class PositionNullCheckValidation : BaseValidation<Plateau>, IValidation<Plateau>
    {
        public override IResult Validate(Plateau data)
        {
            if (data.Position == null)
            {
                return Result.Fail(ValidationConstant.Plateu_Null);
            }
            return Result.Success();
        }
    }
}
