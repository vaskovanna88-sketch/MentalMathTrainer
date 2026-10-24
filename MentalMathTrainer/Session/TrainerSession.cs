using MentalMathTrainer.Models;
using MentalMathTrainer.Review;
using MentalMathTrainer.Storage;

namespace MentalMathTrainer.Session;

public class TrainerSession
{
    private readonly ICardStorage storage;
    private readonly IReviewStrategy strategy;
    private readonly List<MathExample> mistakes = new();
    private SessionSummary summary = new(0, 0);

    public TrainerSession(ICardStorage storage, IReviewStrategy strategy)
    {
        this.storage = storage;
        this.strategy = strategy;
    }

    public string StrategyName => strategy.Name;

    public async Task<List<MathExample>> CardsAsync() => 
        strategy.Order(await storage.LoadAsync());

    public bool Answer(MathExample example, string given)
    {
        var isCorrect = example.Check(given);
        summary += isCorrect;
        if (!isCorrect)
            mistakes.Add(example);
        return isCorrect;
    }

    public IReadOnlyList<MathExample> Mistakes => mistakes;
    public SessionSummary Summary => summary;
}