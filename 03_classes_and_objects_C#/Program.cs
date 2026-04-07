using System;

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
        System.Console.WriteLine($"Игрок {name}, здоровье {health}");
    }
}

class Program
{
    static void Main()
    {
        Unit player = new Unit("Hero", 100, 25);
        Unit enemy = new Unit("Ork", 500, 5);

        enemy.ShowStatus();
        player.ShowStatus();
        while (enemy.health > 0 && player.health > 0)
        {
            player.Attack(enemy);
            if (enemy.health > 0) enemy.Attack(player);
        }

    }
}