using MentalMathTrainer.Models;

namespace MentalMathTrainer.Review;

public interface IReviewStrategy
{
    string Name { get; }
    List<MathExample> Order(List<MathExample> examples);
}