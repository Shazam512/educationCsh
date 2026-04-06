using System;

class Program
{
    static void Main()
    {
        string namePlayer = "Hero";
        int health = 100;
        int damag = 30;

        System.Console.WriteLine("Имя героя: " + namePlayer);
        System.Console.WriteLine("Здоровья игрока: " + heath);

        heath -= damag;
        System.Console.WriteLine($"Вы получили урон {damag}, у вас осталось {heath} здоровья");
    }
}
