

using System; //библиотека

class SineGenerator // программный инструмент для генерации синусоидального аудиосигнала или числовой последовательности
{
    static void Main()
    {
        double amplitude = 1.0; // Амплитуда
        double frequency = 5.0; // Частота (Гц)
        double sampleRate = 100.0; // Частота дискретизации (Гц)
        double duration = 1.0; // Длительность (секунды)

        int numSamples = (int)(duration * sampleRate);
        
        for (int i = 0; i < numSamples; i++)
        {
            double t = i / sampleRate; // Текущее время
            // Формула: y = A * sin(2 * pi * f * t)
            double signal = amplitude * Math.Sin(2 * Math.PI * frequency * t);
            Console.WriteLine($"{t:F3}s: {signal:F4}");
        }
    }
}   

