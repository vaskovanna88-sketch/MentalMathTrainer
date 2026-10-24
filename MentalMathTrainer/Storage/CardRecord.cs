namespace MentalMathTrainer.Storage;

/// <summary>
/// Те, що справді лежить у файлі: спільні поля плюс словник
/// із даними, які потрібні конкретному різновиду.
/// </summary>
public class CardRecord
{
    public int Id { get; set; }
    public string Kind { get; set; } = "";
    public string Expression { get; set; } = "";
    public string Category { get; set; } = "Загальна";
    public Dictionary<string, string> Data { get; set; } = new();
}