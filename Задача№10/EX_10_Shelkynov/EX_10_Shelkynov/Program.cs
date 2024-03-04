using System;

namespace EX_10_Shelkynov; 

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите фигуру:");
        string figure = Console.ReadLine().ToLower();

        //рандомные координаты
        Random random = new Random();
        char latter1 = (char)('a' + random.Next(8));
        char num1 = (char)('1' +  random.Next(8));

        char latter2 = (char)('a' + random.Next(8));
        char num2 = (char)('1' + random.Next(8));

        string coordinates1 = $"{latter1}{num1}";
        string coordinates2 = $"{latter2}{num2}";

        Console.WriteLine($"Сгенерированы координаты полей: {coordinates1}, {coordinates2}");

        switch (figure)
        {
            case "ладья":
                Rook(coordinates1, coordinates2);
                break;
            case "слон":
                Bishop(coordinates1, coordinates2);
                break;
            case "король":
                King(coordinates1, coordinates2);
                break;
            case "ферзь":
                Queen(coordinates1, coordinates2);
                break;
            default:
                Console.WriteLine("Такой фигуры нет!");
                break;
        }

        Console.ReadLine();

    }

    static void Bishop (string coordinates1, string coordinates2)
    {
        int dif1 = Math.Abs(coordinates1[0] - coordinates2[0]);
        int dif2 = Math.Abs(coordinates1[1] - coordinates2[1]);

        if (dif1 != dif2)
        {
            Console.WriteLine("Слон не угражает полю.");
        }
        else
        {
            Console.WriteLine("Слон угражает полю.");
        }
    }

    static void King (string coordinates1, string coordinates2)
    {
        int dif1 = Math.Abs(coordinates1[0] - coordinates2[0]);
        int dif2 = Math.Abs(coordinates1[1] - coordinates2[1]);
        if (dif1 <= 1 && dif2 <= 1)
        {
            Console.WriteLine("Король угражает полю.");
        }    
        else
        {
            Console.WriteLine("Король не угражает полю.");
        }
    }

    static void Queen (string coordinates1, string coordinates2)
    {
        int dif1 = Math.Abs(coordinates1[0] - coordinates2[0]);
        int dif2 = Math.Abs(coordinates1[1] - coordinates2[1]);
        if (coordinates1[0] != coordinates2[0] && coordinates1[1] != coordinates2[1] && dif1 != dif2)
        {
            Console.WriteLine("Ферзь не угражает полю.");
        }
        else
        {
            Console.WriteLine("Ферзь угражает полю.");
        }
    }

    static void Rook (string coordinates1, string coordinates2)
    {
        if (coordinates1[0] != coordinates2[0] && coordinates1[1] != coordinates2[1])
        {
            Console.WriteLine("Ладья не угражает полю.");
        }
        else
        {
            Console.WriteLine("Ладья угражает полю.");
        }
    }
}