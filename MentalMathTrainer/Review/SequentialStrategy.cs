using MentalMathTrainer.Models;

namespace MentalMathTrainer.Review;

public class SequentialStrategy : IReviewStrategy
{
    public string Name => "послідовно";
    public List<MathExample> Order(List<MathExample> examples) => new(examples);
}