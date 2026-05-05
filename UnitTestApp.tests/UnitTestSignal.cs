using Xunit;
using System;

public class SineGenerator
{
    private readonly SignalGenerator _generator = new SignalGenerator();
    private const double Frequency = 5.0; // Частота 5 Гц для простоты расчетов
    private const double Amplitude = 1.0; // Амплитуда 1
    private const double Precision = 1e-10; // Допустимая погрешность для double

    [Theory]
    [InlineData(0.0, 0.0)] // t=0, ожидаем 0
    [InlineData(0.25, 1.0)] // t=1/4 периода (T/4), ожидаем +A
    [InlineData(0.5, 0.0)] // t=1/2 периода (T/2), ожидаем 0
    [InlineData(0.75, -1.0)] // t=3/4 периода (3T/4), ожидаем -A
    [InlineData(1.0, 0.0)] // t=1 период (T), цикл замкнулся, ожидаем 0
    public void GenerateSineWave_ReturnsCorrectValue(double time, double expectedValue)
    {
        // Act: Вызываем метод генерации с заданными параметрами
        double actualValue = _generator.GenerateSineWave(time, Frequency, Amplitude);

        // Assert: Проверяем, что полученное значение близко к ожидаемому в пределах погрешности
        Assert.Equal(expectedValue, actualValue, precision: 10); 
        // *Примечание: В xUnit можно передать количество знаков после запятой через 'precision'.
        // Для универсальности лучше использовать дельту (в новых версиях xUnit это делается иначе),
        // но для наглядности примера используем этот подход или метод Equal с дельтой.
    }
}