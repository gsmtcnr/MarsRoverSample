using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Domain.Results;

namespace MarsRoverSample.Domain.Plateaus
{
    public class Plateau : BasePlateau, IPlateau
    {
        public static Result<Plateau> Create(IPosition position)
        {
            //Domain validations..

            var plateau = new Plateau
            {
                Position = position
            };

            return Result<Plateau>.Success(plateau); 
        }
    }
}
