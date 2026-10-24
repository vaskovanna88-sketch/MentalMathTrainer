using MentalMathTrainer.Models;

namespace MentalMathTrainer.Storage;

public class SampleCardStorage
{
    public static List<MathExample> Examples() => new()
    {
        new OpenMathExample(1, "Столиця України", "Київ", "Географія", "Київ"),
        new ChoiceMathExample(2, "Найбільше озеро світу", 3, "Географія", "Байкал", "Вікторія", "Каспійське море", "Гурон"),
        new NumericMathExample(3, "Рік видання «Кобзаря»", 1840, 0, "Література"),
        new NumericMathExample(4, "Приблизне значення Пі (округлено до сотих)", 3.14, 0.01, "Математика")
    };
}