using MentalMathTrainer.Models;

namespace MentalMathTrainer.Review;

/// <summary>Показує приклади в тому порядку, у якому вони лежать.</summary>
public class SequentialStrategy : IReviewStrategy
{
    public string Name => "послідовно";

    public List<MathExample> Order(List<MathExample> examples) => new(examples);
}