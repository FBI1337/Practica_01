using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите координаты слона и фигуры:");

        string[] coordinates = Console.ReadLine().Split(' ');

        // Проверка корректности введенных данных
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Введены некорректные координаты");
            return;
        }

        // Получение координат ладьи и фигуры
        int x1 = Convert.ToInt32(coordinates[0][0] - 'a' + 1);
        int y1 = Convert.ToInt32(coordinates[0][1] - '0');
        int x2 = Convert.ToInt32(coordinates[1][0] - 'a' + 1);
        int y2 = Convert.ToInt32(coordinates[1][1] - '0');

        if (x1 < 1 || x1 > 8 || y1 < 1 || y1 > 8 || x2 < 1 || x2 > 8 || y2 < 1 || y2 > 8)
        {
            Console.WriteLine("Введены некоретные координаты");
        }


        // Проверка находятся ли фигуры на одной горизонтали или вертикали
        if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
        {
            Console.WriteLine("Слон сможет побить фигуру");
        }
        else
        {
            Console.WriteLine("Слон не сможет побить фигуру");
        }
    }
}