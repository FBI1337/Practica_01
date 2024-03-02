using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите координаты коня и фигуры (например, a1 e5):");
        string input = Console.ReadLine();

        // Разделение введенной строки на координаты коня и фигуры
        string[] coordinates = input.Split(' ');

        // Проверка корректности введенных данных
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Введены некорректные координаты");
            return;
        }

        // Получение координат коня и фигуры
        char knightX = coordinates[0][0];
        char knightY = coordinates[0][1];
        char figureX = coordinates[1][0];
        char figureY = coordinates[1][1];

        // Преобразование символов в числовые значения
        int knightCol = knightX - 'a';
        int knightRow = '8' - knightY;
        int figureCol = figureX - 'a';
        int figureRow = '8' - figureY;

        // Проверка, может ли конь побить фигуру
        bool canHit = false;

        // Возможные варианты ходов коня
        int[,] moves = {
            { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
            { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
        };

        for (int i = 0; i < 8; i++)
        {
            int newRow = knightRow + moves[i, 0];
            int newCol = knightCol + moves[i, 1];

            // Проверка, находится ли фигура на новой клетке
            if (newRow == figureRow && newCol == figureCol)
            {
                canHit = true;
                break;
            }
        }

        // Вывод результата
        if (canHit)
        {
            Console.WriteLine("Конь сможет побить фигуру");
        }
        else
        {
            Console.WriteLine("Конь не сможет побить фигуру");
        }
    }
}
