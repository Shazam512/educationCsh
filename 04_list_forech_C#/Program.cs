using System;
using System.Collections.Generic;

class Unit
{
    public string name;
    public int health;
    public int damage;

    public Unit(string name, int health, int damage)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
    }

    public void Attack(Unit target)
    {
        if (target.health <= 0)
        {
            System.Console.WriteLine($"{this.name} мертв и не может атаковать!");
            return;
        }
        if (target.health > 0)
        {
            target.health -= this.damage;
            System.Console.WriteLine($"{this.name} ударил {target.name} на {this.damage} урона!");

            if (target.health <= 0)
            {
                target.health = 0;
                System.Console.WriteLine($"{target.name} быо убит!");
            }
        }
        else
        {
            System.Console.WriteLine("{target.name} уже мертв!");
        }
    }

    public void ShowStatus()
    {
        System.Console.WriteLine($"--- {name}: HP {health} ---");
    }
}
class Program
{
    static void Main()
    {
        Unit player = new Unit("Hero", 100, 100);
        List<Unit> enemise = new List<Unit>();

        for (int i = 1; i <= 10; i++)
        {
            enemise.Add(new Unit($"Орк {i}", 50 + (i * 10), 10));
        }

        Console.WriteLine("--- СПИСОК ВРАГОВ ---");
        foreach (Unit enemy in enemise)
        {
            enemy.ShowStatus();
        }

        Console.WriteLine($"На игрока напали {enemise.Count} врагов!");

        foreach (Unit enemy in enemise)
        {
            player.Attack(enemy);
        }

        foreach (Unit enemy in enemise)
        {
            if (enemy.health > 0)
            {
                enemy.Attack(player);
            }
        }

        player.ShowStatus();
    }
}