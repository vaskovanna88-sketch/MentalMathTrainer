namespace MentalMathTrainer.Session;

/// <summary>Підсумок сеансу: скільки запитано й скільки правильно.</summary>
public record SessionSummary(int Asked, int Correct)
{
    public int Wrong => Asked - Correct;
    public double Percent => Asked == 0 ? 0 : 100.0 * Correct / Asked;

    /// <summary>Додає до підсумку ще один результат відповіді через оператор +.</summary>
    public static SessionSummary operator +(SessionSummary s, bool correct) =>
        new(s.Asked + 1, s.Correct + (correct ? 1 : 0));
}