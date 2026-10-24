using System.Text.Encodings.Web;
using System.Text.Json;
using MentalMathTrainer.Models;

namespace MentalMathTrainer.Storage;

public class JsonCardStorage : ICardStorage
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    private readonly string path;

    public JsonCardStorage(string path) => this.path = path;

    public string Path => path;

    public async Task<List<MathExample>> LoadAsync()
    {
        if (!File.Exists(path))
            return new List<MathExample>();

        string json;
        try
        {
            json = await File.ReadAllTextAsync(path);
        }
        catch (IOException ex)
        {
            throw new CardStorageException($"Не вдалося прочитати файл {path}.", ex);
        }

        List<CardRecord>? records;
        try
        {
            records = JsonSerializer.Deserialize<List<CardRecord>>(json, Options);
        }
        catch (JsonException ex)
        {
            throw new CardStorageException($"Файл {path} пошкоджено: це не коректний JSON.", ex);
        }

        var examples = new List<MathExample>();
        foreach (var record in records ?? new List<CardRecord>())
        {
            var example = CardFactory.FromRecord(record);
            if (example is not null)
                examples.Add(example);
        }
        return examples;
    }

    public async Task SaveAsync(List<MathExample> examples)
    {
        var records = new List<CardRecord>();
        foreach (var example in examples)
            records.Add(CardFactory.ToRecord(example));

        var json = JsonSerializer.Serialize(records, Options);
        try
        {
            var folder = System.IO.Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(folder))
                Directory.CreateDirectory(folder);

            await File.WriteAllTextAsync(path, json);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new CardStorageException($"Не вдалося записати файл {path}.", ex);
        }
    }
}