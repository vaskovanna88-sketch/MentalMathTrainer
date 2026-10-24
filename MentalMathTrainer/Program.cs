using System.Text;
using MentalMathTrainer.Models;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Тренажер усного рахунку");
Console.WriteLine($"Платформа: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
Console.WriteLine();

// Складання набору записів у пам'яті (колекція List<T>)
var examples = new List<MathExample>
{
    new MathExample(1, "12 + 15", "27", "Додавання"),
    new MathExample(2, "50 - 18", "32", "Віднімання"),
    new MathExample(3, "7 * 8", "56", "Множення")
};

Console.WriteLine($"Прикладів у тренажері: {examples.Count}.");
Console.WriteLine();

// Збирання переліку за допомогою StringBuilder
var list = new StringBuilder();
foreach (var ex in examples)
{
    list.AppendLine($"  {ex}");
}
Console.Write(list.ToString());
Console.WriteLine();

// Цикл опитування користувача
foreach (var ex in examples)
{
    Console.WriteLine($"Обчисліть: {ex.Expression}");
    Console.Write("Ваша відповідь: ");
    var given = Console.ReadLine() ?? "";

    if (ex.Check(given))
    {
        Console.WriteLine("Правильно! Молодець.");
    }
    else
    {
        Console.WriteLine($"Ні. Правильна відповідь: {ex.Answer}");
    }
    Console.WriteLine();
}