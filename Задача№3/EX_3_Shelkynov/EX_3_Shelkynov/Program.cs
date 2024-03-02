using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите координаты ферзя и фигуры:");
        string input = Console.ReadLine();

        // Разделение введенной строки на координаты ферзя и фигуры
        string[] coordinates = input.Split(' ');

        // Проверка корректности введенных данных
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Введены некорректные координаты");
            return;
        }

        // Получение координат ферзя и фигуры
        char queenX = coordinates[0][0];
        char queenY = coordinates[0][1];
        char figureX = coordinates[1][0];
        char figureY = coordinates[1][1];

        // Проверка, может ли ферзь побить фигуру
        if (queenX == figureX || queenY == figureY || Math.Abs(queenX - figureX) == Math.Abs(queenY - figureY))
        {
            Console.WriteLine("Ферзь сможет побить фигуру");
        }
        else
        {
            Console.WriteLine("Ферзь не сможет побить фигуру");
        }
    }
}
