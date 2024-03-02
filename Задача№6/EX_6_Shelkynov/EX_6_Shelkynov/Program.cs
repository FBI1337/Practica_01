using System;

namespace EX_6_Shelkynov;
class Program
{
    static int playerHealthe = 500;
    static int bossHealthe = 2500;
    static bool IceShieldActive = false;
    static bool interdimensionalRiftActive = false;
    static bool Combo = false;
    static bool bossFrozen = false;
    static bool Run = false;

    static void Main()
    {
        Console.WriteLine("Добро пожаловать, Гэндельф");
        Console.WriteLine("Босс появился! Бой начался!");

        while (playerHealthe > 0 && bossHealthe > 0)
        {
            Console.WriteLine($"ЗДОРОВЬЕ ГЭНДЕЛЬФА:{playerHealthe}");
            Console.WriteLine($"ЗДОРОВЬЕ БОССА: {bossHealthe}");

            Console.WriteLine("Выберите заклинание:");
            Console.WriteLine("1. Исцеляющий свет - заклинание создает яркий свет, который обладает целебными свойствами и исцеляет раны или изгоняет темные силы.");
            Console.WriteLine("2. Огненый шар - создает огненный шар, который летит к цели и наносит огненный урон по попаданию.");
            Console.WriteLine("3. Ледяной щит - заклинание создает непроницаемый щит из льда, который защищает мага от атак врагов и снижает получаемый урон.");
            Console.WriteLine("4. Небесная кара - призывает Божью кару с небес, которая ударяет по врагам с разрушительной силой, нанося мощный электрический урон.");
            Console.WriteLine("5. Трансформация - заклинание позволяет магу преобразовать себя или другого субъекта в другое существо или предмет на определенное время, получая новые способности или возможности.");
            Console.WriteLine("6. Пропустить ход");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    HealingLight();
                    break;
                case 2:
                    Fireball();
                    break;
                case 3:
                    IceShield();
                    break;
                case 4:
                    HeavenlyPunishment();
                    break;
                case 5:
                    Transformation();
                    break;
                case 6:
                    SkipTurn();
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пропуск хода.");
                    break;
            }
            Combo = (choice == 2);
            BossAttack();
        }

        if (playerHealthe <= 0)
        {
            Console.WriteLine("Вы проиграли!");
        }
        else
        {
            Console.WriteLine("Вы выйграли!");
        }
    }

    //Исцеляющий свет
    static void HealingLight()
    {
        Console.WriteLine("Вы вызвали личебный свет и восстановили 100 здоровья");
        playerHealthe += 100;
        interdimensionalRiftActive = true;
    }

    //огненый шар
    static void Fireball()
    {
        int damage = 120;
        Console.WriteLine($"Вы призвали огненый шар и нанесли {damage} урона.");
        bossHealthe -= damage;
    }

    //ледяной щит
    static void IceShield()
    {
        Console.WriteLine("Вы создали ледянной щит. Атаки босса на 50% меньше.");
        IceShieldActive = true;
    }

    //небесная кара
    static void HeavenlyPunishment()
    {
        int damage = 1000;
        if (Combo)
        {
            damage *= 2;
            Console.WriteLine("Подсказка: Прошлым ходом вы призвали огненый шар и он усилил Небесную кару.");
            Console.WriteLine($"Вы нанесли {damage} урона, а так-же оглушили его.");
            bossFrozen = true;
            Combo = false;
        }
        Console.WriteLine($"Вы призвали Небесную кару и нанесли {damage} урона.");
        bossHealthe -= damage;

    }

    //трансформация
    static void Transformation()
    {
        Console.WriteLine("1. Оборотень - мистическое животное, которое наносит 120 урона.");
        Console.WriteLine("2. Гномик - маленький юркий гном.");
        Console.WriteLine("Выберите существо: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                int damage = 120;
                Console.WriteLine($"Вы превратились в Оборотня и нанесли {damage} урона.");
                bossHealthe -= damage;
                break;
            case 2:
                Console.WriteLine("Вы превратились в гномика и укланились от атаки.");
                Run = true;
                break;
        }
    }

    //пропуск хода
    static void SkipTurn()
    {
        Console.WriteLine("Вы пропустили ход.");
    }

    static void BossAttack()
    {
        if (!interdimensionalRiftActive)
        {
            if (!Run)
            {
                if (!bossFrozen)
                {

                    int bossDamage = 150;
                    if (IceShieldActive)
                    {
                        Console.WriteLine("Босс атакует, но наносит на 50% меньше своего урона.");
                        bossDamage /= 2;
                        Console.WriteLine($"Вы получили {bossDamage} урона");
                        IceShieldActive = false;
                    }
                    else
                    {
                        Console.WriteLine($"Босс атакует вас и наносит {bossDamage} урона.");
                    }

                    playerHealthe -= bossDamage;
                }
                else
                {
                    Console.WriteLine("Босс не атакует из-за оглушения.");
                    bossFrozen = false;
                }
            }
            else
            {
                Console.WriteLine("Босс не смог вам нанести урон так как вы перебежали.");
                Run = false;
            }
        }
        else
        {
            Console.WriteLine("Босс не атакует из-за заклинания.");
        }
        interdimensionalRiftActive = false;
    }
}
