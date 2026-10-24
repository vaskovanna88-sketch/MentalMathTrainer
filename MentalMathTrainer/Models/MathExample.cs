namespace MentalMathTrainer.Models;

/// <summary>Спільна основа всіх математичних прикладів.</summary>
public abstract class MathExample
{
    public int Id { get; set; }
    public string Expression { get; set; } = "";
    public string Category { get; set; } = "Загальна";

    protected MathExample() { }

    protected MathExample(int id, string expression, string category)
    {
        Id = id;
        Expression = expression;
        Category = category;
    }

    /// <summary>Позначка різновиду: під нею приклад пишуть у файл.</summary>
    public abstract string Kind { get; }

    /// <summary>Записує власні дані різновиду до словника.</summary>
    public abstract void WriteData(IDictionary<string, string> data);

    /// <summary>Читає власні дані різновиду зі словника.</summary>
    public abstract void ReadData(IReadOnlyDictionary<string, string> data);

    /// <summary>Перевіряє відповідь. Кожен різновид виконує це по-своєму.</summary>
    public abstract bool Check(string given);

    /// <summary>Правильна відповідь текстом – для показу.</summary>
    public abstract string CorrectAnswer { get; }

    /// <summary>Підказка, як відповідати. Різновид може її змінити.</summary>
    public virtual string Prompt => "Ваша відповідь";

    public override string ToString() => $"#{Id} [{Category}] Вираз: {Expression}";
}