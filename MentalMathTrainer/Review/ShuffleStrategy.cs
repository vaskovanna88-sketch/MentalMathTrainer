using MentalMathTrainer.Models;

namespace MentalMathTrainer.Review;

public class ShuffleStrategy : IReviewStrategy
{
    private readonly Random random;

    public ShuffleStrategy() : this(Random.Shared) { }
    public ShuffleStrategy(Random random) => this.random = random;

    public string Name => "перемішано";

    public List<MathExample> Order(List<MathExample> examples)
    {
        var copy = new List<MathExample>(examples);
        for (var i = copy.Count - 1; i > 0; i--)
        {
            var j = random.Next(i + 1);
            (copy[i], copy[j]) = (copy[j], copy[i]);
        }
        return copy;
    }
}