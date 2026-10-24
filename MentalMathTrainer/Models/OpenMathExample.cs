namespace MentalMathTrainer.Models;

public class OpenMathExample : MathExample
{
    public string Answer { get; set; } = "";
    public List<string> Synonyms { get; set; } = new();

    public OpenMathExample() { }

    public OpenMathExample(int id, string expression, string answer, string category = "Загальна")
        : base(id, expression, category)
    {
        Answer = answer;
    }

    public OpenMathExample(int id, string expression, string answer, string category, params string[] synonyms)
        : this(id, expression, answer, category)
    {
        Synonyms.AddRange(synonyms);
    }

    public override bool Check(string given)
    {
        var value = given.Trim();
        if (Same(value, Answer)) return true;
        foreach (var synonym in Synonyms)
            if (Same(value, synonym)) return true;
        return false;
    }

    private static bool Same(string a, string b) =>
        string.Equals(a, b.Trim(), StringComparison.CurrentCultureIgnoreCase);

    public override string CorrectAnswer => Answer;
}