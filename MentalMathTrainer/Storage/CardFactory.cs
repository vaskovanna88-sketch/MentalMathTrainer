using MentalMathTrainer.Models;

namespace MentalMathTrainer.Storage;

public static class CardFactory
{
    public static MathExample? Create(string kind) => kind switch
    {
        "open" => new OpenMathExample(),
        "choice" => new ChoiceMathExample(),
        "numeric" => new NumericMathExample(),
        _ => null
    };

    public static MathExample? FromRecord(CardRecord record)
    {
        var example = Create(record.Kind);
        if (example is null) return null;
        example.Id = record.Id;
        example.Expression = record.Expression;
        example.Category = record.Category;
        example.ReadData(record.Data);
        return example;
    }

    public static CardRecord ToRecord(MathExample example)
    {
        var record = new CardRecord
        {
            Id = example.Id,
            Kind = example.Kind,
            Expression = example.Expression,
            Category = example.Category
        };
        example.WriteData(record.Data);
        return record;
    }
}