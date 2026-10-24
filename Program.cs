using System.Text;
using MentalMathTrainer.Models;
using MentalMathTrainer.Session;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Тренажер усного рахунку");
Console.WriteLine($"Платформа: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
Console.WriteLine();

// Набір містить різні різновиди карток завдяки спільній абстрактній основі MathExample
var deck = new List<MathExample>
{
    new OpenMathExample(1, "Столиця України", "Київ", "Географія", "Київ"),
    new ChoiceMathExample(2, "Найбільше озеро світу", 3, "Географія", "Байкал", "Вікторія", "Каспійське море", "Гурон"),
    new NumericMathExample(3, "Рік видання «Кобзаря»", 1840, 0, "Література"),
    new NumericMathExample(4, "Приблизне значення Пі (округлено до сотих)", 3.14, 0.01, "Математика")
};

Console.WriteLine($"Прикладів у тренажері: {deck.Count}.");
Console.WriteLine();

var list = new StringBuilder();
foreach (var ex in deck)
{
    list.AppendLine($"  {ex}");
}
Console.Write(list.ToString());
Console.WriteLine();

var summary = new SessionSummary(0, 0);

foreach (var card in deck)
{
    Console.WriteLine();
    Console.WriteLine($"Обчисліть / Дайте відповідь: {card.Expression}");

    // Якщо це картка вибору варіанта, виводимо список варіантів через індексатор
    if (card is ChoiceMathExample choice)
    {
        for (var n = 1; n <= choice.Options.Count; n++)
        {
            Console.WriteLine($"  {n}. {choice[n]}");
        }
    }

    Console.Write($"{card.Prompt}: ");
    var given = Console.ReadLine() ?? "";

    var isCorrect = card.Check(given);
    summary += isCorrect; // Використання перевантаженого оператора +

    if (isCorrect)
    {
        Console.WriteLine("Правильно! Молодець.");
    }
    else
    {
        Console.WriteLine($"Ні. Правильна відповідь: {card.CorrectAnswer}");
    }
}

Console.WriteLine();
Console.WriteLine($"Підсумок: {summary.Correct} з {summary.Asked} ({summary.Percent:F0}%). Правильних: {summary.Correct}, Помилок: {summary.Wrong}.");