namespace MentalMathTrainer.Models;

public class ChoiceMathExample : MathExample
{
    public List<string> Options { get; set; } = new();

    public int CorrectNumber { get; set; }

    public string this[int number] => Options[number - 1];

    public ChoiceMathExample() { }

    public ChoiceMathExample(int id, string expression, int correctNumber, string category, params string[] options)
        : base(id, expression, category)
    {
        CorrectNumber = correctNumber;
        Options.AddRange(options);
    }

    public override bool Check(string given)
    {
        if (!int.TryParse(given.Trim(), out var number))
            return false;
        return number == CorrectNumber;
    }

    public override string CorrectAnswer =>
        CorrectNumber >= 1 && CorrectNumber <= Options.Count
            ? $"{CorrectNumber}. {this[CorrectNumber]}"
            : CorrectNumber.ToString();

    public override string Prompt => "Номер варіанта";
}