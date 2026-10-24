cmeta using MentalMathTrainer.Models;
using MentalMathTrainer.Review;
using MentalMathTrainer.Storage;

namespace MentalMathTrainer.Session;

/// <summary>
/// Ядро тренажера. Не знає ані про консоль, ані про файли.
/// </summary>
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

    public List<MathExample> Cards() => strategy.Order(storage.Load());

    public bool Answer(MathExample card, string given)
    {
        var isCorrect = card.Check(given);
        summary += isCorrect; // Використання оператора + з ЛР 3
        if (!isCorrect)
            mistakes.Add(card);
        return isCorrect;
    }

    public IReadOnlyList<MathExample> Mistakes => mistakes;
    public SessionSummary Summary => summary;
}