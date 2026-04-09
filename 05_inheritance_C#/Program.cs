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

    public virtual void Attack(Unit target)
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
}

class Mage : Unit
{
    public int mana = 50;

    public Mage(string name, int health, int damage) : base(name, health, damage) { }

    public override void Attack(Unit target)
    {
        if (mana >= 20)
        {
            mana -= 20;
            int spellDamage = damage * 2;
            target.health -= spellDamage;
            System.Console.WriteLine($"{name} пускает огненый шар в {target.name} на {spellDamage} урон! Мана осталось: {mana}");
        }
        else
        {
            System.Console.WriteLine($"{name} пытается колдовать, но маны нет!");
            base.Attack(target);
        }
    }
}
class Program
{
    static void Main()
    {
        Mage player = new Mage("Hero", 100, 40);
        Unit dragon = new Unit("Dragon", 200, 40);

        System.Console.WriteLine("----НАЧАЛО БИТВЫ!----");

        while (dragon.health > 0 && player.health > 0)
        {
            player.Attack(dragon);
            if (dragon.health > 0) dragon.Attack(player);
        }

        System.Console.WriteLine("-------КОНЕЦ!-------");
    }
}