namespace MentalMathTrainer.Storage;

/// <summary>Помилка читання чи запису колоди, зрозуміла людині.</summary>
public class CardStorageException : Exception
{
    public CardStorageException(string message, Exception inner)
        : base(message, inner) { }
}