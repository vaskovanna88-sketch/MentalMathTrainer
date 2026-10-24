using System.Globalization;

namespace MentalMathTrainer.Models;

public class NumericMathExample : MathExample
{
    public double Value { get; set; }
    public double Tolerance { get; set; }
    public string Unit { get; set; } = "";

    public NumericMathExample() { }

    public NumericMathExample(int id, string expression, double value, double tolerance = 0, string category = "Загальна", string unit = "")
        : base(id, expression, category)
    {
        Value = value;
        Tolerance = tolerance;
        Unit = unit;
    }

    public override bool Check(string given)
    {
        if (!TryParseNumber(given, out var number))
            return false;
        return Math.Abs(number - Value) <= Tolerance;
    }

    private static bool TryParseNumber(string text, out double value)
    {
        var trimmed = text.Trim();
        return double.TryParse(trimmed, NumberStyles.Float, CultureInfo.CurrentCulture, out value)
            || double.TryParse(trimmed, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }

    public override string CorrectAnswer
    {
        get
        {
            var number = Value.ToString(CultureInfo.CurrentCulture);
            var withUnit = string.IsNullOrEmpty(Unit) ? number : $"{number} {Unit}";
            return Tolerance > 0 ? $"{withUnit} (допуск ±{Tolerance})" : withUnit;
        }
    }

    public override string Prompt => string.IsNullOrEmpty(Unit) ? "Число" : $"Число, {Unit}";
}