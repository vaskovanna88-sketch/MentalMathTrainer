namespace MentalMathTrainer.Models;

/// <summary>Один математичний приклад для тренування.</summary>
public class MathExample
{
    public int Id { get; set; }
    public string Expression { get; set; } = "";
    public string Answer { get; set; } = "";
    public string Category { get; set; } = "Загальна";

    public MathExample() { }

    public MathExample(int id, string expression, string answer, string category)
    {
        Id = id;
        Expression = expression;
        Answer = answer;
        Category = category;
    }

    public bool Check(string given) =>
        string.Equals(given.Trim(), Answer.Trim(), StringComparison.CurrentCultureIgnoreCase);

    public override string ToString() => $"#{Id} [{Category}] Вираз: {Expression}";
}