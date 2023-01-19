// Задача 41: Пользователь вводит с клавиатуры M чисел.
// Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3

int CountSymbol(char symbol, string text)
{
    int result = 0;
    for (int i=0;i<text.Length;i++)
    {
        if (text[i] == symbol) result++;
    }
    return result;
}

int[] GetArrayFromUser()
{
    int arrayLength = 0;
    Console.Write("Введите числа. Например: '3, 4, 0, -5' > ");
    string userInput = Console.ReadLine();
    // Количество цифр считаю исходя из количества запятых + 1
    int[] numbers = new int[CountSymbol(',', userInput)+1];
    // Теперь перебираю строку, создавая подстроки и
    // пытаясь сохранить результат их парсинга в массиве
    // Как альтернативу можно использовать Strint.Split()
    int i = 0;
    string tmp = "";
    for (int textI=0;textI<userInput.Length;textI++)
    {
        if (userInput[textI] == ',')
        {
            if (! int.TryParse(tmp, out numbers[i]))
            {
                Console.WriteLine($"Не удалось распарсить '{tmp}', число задано как 0");
            }
            tmp = "";
            i++;
        }
        else
        {
            tmp += userInput[textI];
        }
    }
    // Распарсим последний элемент т.к. он не заканчивается ','
    if (! int.TryParse(tmp, out numbers[i]))
        {
            Console.WriteLine($"Не удалось распарсить '{tmp}', число задано как 0");
        }
    return numbers;
}

int CountPositiveNumbers(int[] array)
{
    int result = 0;
    foreach (int num in array)
    {
        if (num > 0) result++;
    }
    return result;
}

int[] userArray = GetArrayFromUser();
Console.WriteLine($"Вы ввели [{String.Join(", ", userArray)}], положительных среди них {CountPositiveNumbers(userArray)}");
