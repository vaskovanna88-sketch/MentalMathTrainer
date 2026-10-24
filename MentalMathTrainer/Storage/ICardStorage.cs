using MentalMathTrainer.Models;

namespace MentalMathTrainer.Storage;

public interface ICardStorage
{
    Task<List<MathExample>> LoadAsync();
    Task SaveAsync(List<MathExample> examples);
}