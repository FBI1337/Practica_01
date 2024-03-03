using System;

namespace EX_8
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите координаты первого поля:");
            string field1 = Console.ReadLine();

            Console.WriteLine("Введите координаты второго поля:");
            string field2 = Console.ReadLine();

            if (IsValidField(field1) && IsValidField(field2))
            {
                if (AreFieldsSameColor(field1, field2))
                {
                    Console.WriteLine("Поля одного цвета.");
                }
                else
                {
                    Console.WriteLine("Поля разного цвета.");
                }
            }
            else
            {
                Console.WriteLine("Некорректные координаты полей. Введите корректные значения от a1 до h8.");
            }
        }

        // Проверка корректности координат поля
        static bool IsValidField(string field)
        {
            if (field.Length == 2)
            {
                char letter = field[0];
                char digit = field[1];

                bool isLetterValid = letter >= 'a' && letter <= 'h';
                bool isDigitValid = digit >= '1' && digit <= '8';

                return isLetterValid && isDigitValid;
            }

            return false;
        }

        // Проверка, являются ли поля одного цвета
        static bool AreFieldsSameColor(string field1, string field2)
        {
            return GetFieldColor(field1) == GetFieldColor(field2);
        }

        // Получение цвета поля
        static bool GetFieldColor(string field)
        {
            int sum = field[0] + field[1];
            return sum % 2 == 0; // Поле чёрное, если сумма координат чётная
        }
    }
}