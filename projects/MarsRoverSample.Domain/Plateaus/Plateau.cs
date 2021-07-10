using MarsRoverSample.Domain.Plateaus.Validations;
using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;
using System.Collections.Generic;

namespace MarsRoverSample.Domain.Plateaus
{
    public class Plateau : BasePlateau, IPlateau
    {
        public static Result<Plateau> Create(IPosition position)
        {
            var plateau = new Plateau
            {
                Position = position
            };

            //Domain validations..
            #region Domain Validations

            List<IValidation<Plateau>> validations = new List<IValidation<Plateau>>
            {
                new PositionNullCheckValidation()
            };

            List<string> errorMessages = new List<string>();
            foreach (var validation in validations)
            {
                IResult validateResult = validation.Validate(plateau);
                if (!validateResult.IsSuccess)
                {
                    errorMessages.AddRange(validateResult.ErrorMessages);
                }
            }

            if (errorMessages.Count > 0)
            {
                return Result<Plateau>.Fail(errorMessages);
            }

            #endregion
          
            return Result<Plateau>.Success(plateau); 
        }
    }
}
