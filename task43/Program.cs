// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;
// значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

int[] GetFunctionParametersFromUser()
{
    // В контексте данной задачи рассматриваются только формулы вида 'y = k*x + b'
    // Поэтому запрашиваем у пользователя только 2 значения
    int[] result = new int[2];
    Console.Write("Введите через запятую значения переменных для уравнения A*x + B. Например '3,1' > ");
    string userInput = Console.ReadLine();
    int i = 0;
    foreach (string numberStr in userInput.Split(','))
    {
        if (! int.TryParse(numberStr, out result[i]))
        {
            Console.WriteLine($"Не удалось распарсить '{numberStr}', число задано как 0");
        }
        i++;
    }
    return result;
}

double[] FindIntersectionPoints(int[] func1, int[] func2)
{
    double[] combinedFunc = new double[2];
    combinedFunc[0] = func1[0] - func2[0];
    combinedFunc[1] = func1[1] - func2[1];
    // На данном этапе в result хранится итоговая функция, теперь подсчитаем координаты
    double x = -(combinedFunc[1]/combinedFunc[0]);
    double y = func1[0] * x + func1[1];
    return new double[] {x, y};
}

Console.WriteLine("Уравнения y = k1*x + b1 и y = k2*x + b2");
Console.WriteLine("Для первого уравнения");
int[] y1 = GetFunctionParametersFromUser();
Console.WriteLine("Для второго уравнения");
int[] y2 = GetFunctionParametersFromUser();

if (y1[0] == y2[0])
{
    Console.WriteLine("Угловые коэффициенты равны, функции не пересекаются т.к. Параллельны");
}
else
{
    Console.WriteLine($"Функции пересекаются в точке ({String.Join(", ", FindIntersectionPoints(y1, y2))})");
}
// проверено с использованием https://www.mathway.com/ru/graph
