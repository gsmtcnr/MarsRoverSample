using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Domain.Rovers.Inputs;
using MarsRoverSample.Domain.Rovers.Validations;
using MarsRoverSample.Infrastructure.Validations;
using System.Collections.Generic;

namespace MarsRoverSample.Domain.Rovers
{
    public class Rover : BaseRover, IRover
    {
        public static Result<Rover> Create(CreateInputModel createInputModel)
        {
            #region Domain Validations

            List<IValidation<CreateInputModel>> validations = new List<IValidation<CreateInputModel>>
            {
                new NameEmptyValidation(),
                new PlateuNullCheckValidation(),
                new DirectionNullCheckValidation(),
                new LowerCoordinateXValidation(),
                new LowerCoordinateYValidation(),
                new UpperCoordinateXValidation(),
                new UpperCoordinateYValidation()
            };

            List<string> errorMessages = new List<string>();
            foreach (var validation in validations)
            {
                IResult validateResult = validation.Validate(createInputModel);
                if (!validateResult.IsSuccess)
                {
                    errorMessages.AddRange(validateResult.ErrorMessages);
                }
            }

            if (errorMessages.Count > 0)
            {
                return Result<Rover>.Fail(errorMessages);
            }

            #endregion

            Rover rover = new Rover
            {
                Name = createInputModel.Name,
                CurrentX = createInputModel.CoordinateX,
                CurrentY = createInputModel.CoordinateY,
                Direction = createInputModel.Direction,
                Plateau = createInputModel.Plateau
            };

            return Result<Rover>.Success(rover);
        }
    }
}
