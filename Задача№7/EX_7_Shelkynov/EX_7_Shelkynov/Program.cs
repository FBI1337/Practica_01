using System;
using System.Collections.Generic;
using System.IO;

namespace EX_7
{

    // Основной класс программы
    class Program
    {
        
        static void Main()
        {
            Console.CursorVisible = false;
            
            //сам лабиринт
            string[] lines = File.ReadAllLines("C:\\Users\\slava\\OneDrive\\Documents\\Учеба и игры\\УП.01\\Задача№7\\EX_7_Shelkynov\\EX_7_Shelkynov\\bin\\Debug\\net8.0\\map.txt"); // Путь указать самому к файлу map.txt

            int playerRow = 1;
            int playerCol = 5;

            Console.Clear();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            List<Tuple<int, int>> route = new List<Tuple<int, int>>();
            bool showDots = false;

            while (true)
            {
                DisplayRoute(lines, route, showDots);

                //управляемый персонаж
                Console.SetCursorPosition(playerCol, playerRow);
                Console.Write("■");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                Console.SetCursorPosition(playerCol, playerRow);
                Console.Write(' ');

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;



                //настройка управления
                if (key == ConsoleKey.UpArrow && CanMoveTo(lines[playerRow - 1][playerCol]))
                {
                    newPlayerRow--;
                }
                else if (key == ConsoleKey.DownArrow && CanMoveTo(lines[playerRow + 1][playerCol]))
                {
                    newPlayerRow++;
                }
                else if (key == ConsoleKey.LeftArrow && CanMoveTo(lines[playerRow][playerCol - 1]))
                {
                    newPlayerCol--;
                }
                else if (key == ConsoleKey.RightArrow && CanMoveTo(lines[playerRow][playerCol + 1]))
                {
                    newPlayerCol++;
                }
                else if (key == ConsoleKey.F1)
                {
                    showDots = !showDots;
                }

                
                //при контакте с 'F' завершение лабиринта
                if (lines[newPlayerRow][newPlayerCol] == 'F')
                {
                    Console.Clear();
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }

                    Console.WriteLine("Поздравляем! Вы прошли лабиринт!");
                    break;
                }

                if (CanMoveTo(lines[newPlayerRow][newPlayerCol]))
                {
                    route.Add(new Tuple<int, int>(playerRow, playerCol));
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            Console.CursorVisible = true;
        }

        // Отображение текущего состояния лабиринта с учетом маршрута и настроек отображения точек
        static void DisplayRoute(string[] lines, List<Tuple<int, int>> route, bool showDots)
        {
            Console.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                char[] lineChars = lines[i].ToCharArray();

                for (int j = 0; j < lineChars.Length; j++)
                {
                    Console.SetCursorPosition(j, i);

                    if (lineChars[j] == '+' && !showDots)
                    {

                    }

                    else
                    {
                        Console.Write(lineChars[j]);
                    }
                }
            }
            Console.WriteLine("F1 - вкл/выкл маршрут до финиша");
        }

        // Проверка, можно ли двигаться на клетку с данным символом
        static bool CanMoveTo(char symbol)
        {
            return symbol != '═' && symbol != '║' && symbol != '╣' && symbol != '╠' && symbol != '╦' && symbol != '╩'
                && symbol != '╔' && symbol != '╗' && symbol != '╚' && symbol != '╝';
        }
    }
}