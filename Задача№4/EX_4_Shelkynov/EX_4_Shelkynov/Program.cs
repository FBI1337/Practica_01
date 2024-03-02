using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите координаты короля и фигуры:");
        string input = Console.ReadLine();

        // Разделение введенной строки на координаты короля и фигуры
        string[] coordinates = input.Split(' ');

        // Проверка корректности введенных данных
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Введены некорректные координаты");
            return;
        }

        // Получение координат короля и фигуры
        char kingX = coordinates[0][0];
        char kingY = coordinates[0][1];
        char figureX = coordinates[1][0];
        char figureY = coordinates[1][1];

        // Проверка, может ли король побить фигуру
        int deltaX = Math.Abs(kingX - figureX);
        int deltaY = Math.Abs(kingY - figureY);

        if (deltaX <= 1 && deltaY <= 1)
        {
            Console.WriteLine("Король сможет побить фигуру");
        }
        else
        {
            Console.WriteLine("Король не сможет побить фигуру");
        }
    }
}
