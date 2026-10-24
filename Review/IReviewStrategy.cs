using MentalMathTrainer.Models;

namespace MentalMathTrainer.Review;

/// <summary>У якому порядку показувати приклади.</summary>
public interface IReviewStrategy
{
    string Name { get; }
    List<MathExample> Order(List<MathExample> examples);
}