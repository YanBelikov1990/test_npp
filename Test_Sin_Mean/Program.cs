

using System;
using System.IO;
using System.Globalization; // Необходимо для CultureInfo.InvariantCulture

class SineGenerator
{
    static void Main()
    {
        // Параметры сигнала
        double amplitude = 1.0; // Амплитуда
        double frequency = 5.0; // Частота (Гц)
        double sampleRate = 100.0; // Частота дискретизации (Гц)
        double duration = 1.0; // Длительность (секунды)

        // Переменные для статистики
        double maxSignal = -double.MaxValue;
        double minSignal = double.MaxValue;
        double sumSignal = 0;
        int zeroLevel = 0;

        int numSamples = (int)(duration * sampleRate);

        // Подготовка к записи в файл
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string filePath = $"sine_{date}.txt";

        // Используем StreamWriter для записи в файл
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Записываем параметры (метаданные)
            writer.WriteLine("# Signal Generation Parameters");
            writer.WriteLine($"# Frequency: {frequency} Hz");
            writer.WriteLine($"# Amplitude: {amplitude}");
            writer.WriteLine($"# SampleRate: {sampleRate} Hz");
            writer.WriteLine($"# Duration: {duration} sec");
            writer.WriteLine($"# Date: {DateTime.Now}");
            writer.WriteLine("# -----------------------------");

            // Генерация сигнала
            for (int i = 0; i < numSamples; i++)
            {
                double t = i / sampleRate; // Текущее время
                double signal = amplitude * Math.Sin(2 * Math.PI * frequency * t);

                // Вывод в консоль
                Console.WriteLine($"{i}: {t:F3}s: {signal:F4}");

                // Запись в файл с использованием инвариантной культуры (точка вместо запятой)
                writer.WriteLine(signal.ToString("F6", CultureInfo.InvariantCulture));

                // Статистика
                sumSignal += signal;
                maxSignal = Math.Max(maxSignal, signal);
                minSignal = Math.Min(minSignal, signal);

                // Подсчет пересечений с нулем (с учетом погрешности)
                if (Math.Abs(signal) < 0.0001) 
                {
                    zeroLevel++;
                }
            }
        }

        // Вывод результатов в консоль после завершения цикла
        Console.WriteLine($"\nМаксимальное значение: {maxSignal}");
        Console.WriteLine($"Минимальное значение: {minSignal}");
        
        double avgSignal = sumSignal / numSamples;
        Console.WriteLine($"Среднее значение: {avgSignal}");
        Console.WriteLine($"Количество пересечений с нулем: {zeroLevel}");
        
        Console.WriteLine($"\nСигнал и параметры сохранены в {filePath}");
    }
}
