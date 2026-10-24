using System.Text;
using MentalMathTrainer.Models;
using MentalMathTrainer.Review;
using MentalMathTrainer.Session;
using MentalMathTrainer.Storage;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Картковий тренажер");
Console.WriteLine($"Платформа: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
Console.WriteLine();

// Впровадження залежностей (Dependency Injection)
ICardStorage storage = new SampleCardStorage();
IReviewStrategy strategy = new ShuffleStrategy(); // Можна змінити на new SequentialStrategy()

var session = new TrainerSession(storage, strategy);
var cards = session.Cards();

Console.WriteLine($"Прикладів у тренажері: {cards.Count}, порядок: {session.StrategyName}.");

foreach (var card in cards)
{
    Console.WriteLine();
    Console.WriteLine($"Обчисліть / Дайте відповідь: {card.Expression}");

    if (card is ChoiceMathExample choice)
    {
        for (var n = 1; n <= choice.Options.Count; n++)
        {
            Console.WriteLine($"  {n}. {choice[n]}");
        }
    }

    Console.Write($"{card.Prompt}: ");
    var given = Console.ReadLine() ?? "";

    var isCorrect = session.Answer(card, given);

    if (isCorrect)
    {
        Console.WriteLine("Правильно! Молодець.");
    }
    else
    {
        Console.WriteLine($"Ні. Правильна відповідь: {card.CorrectAnswer}");
    }
}

var summary = session.Summary;
Console.WriteLine();
Console.WriteLine($"Підсумок: {summary.Correct} з {summary.Asked} ({summary.Percent:F0}%). Правильних: {summary.Correct}, Помилок: {summary.Wrong}.");

if (summary.Wrong > 0)
{
    Console.WriteLine("Повторити варто:");
    foreach (var card in session.Mistakes)
    {
        Console.WriteLine($"  {card.Expression}");
    }
}