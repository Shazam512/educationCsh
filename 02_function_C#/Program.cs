using System;

class Program
{
    static void Main()
    {
        int health = 100;
        string name = "Hero";
        int mana = 50;

        health = TakeDamage(name, health, 50);
        health = TakeDamage(name, health, 70);
        mana = CastSpell(mana, 25);
        mana = CastSpell(mana, 50);
    }
    static int TakeDamage(string targetName, int currentHealth, int damage)
    {
        int newHealth = currentHealth - damage;

        if (newHealth <= 0)
        {
            System.Console.WriteLine($"{targetName} погиб!");
            return 0;
        }
        else
        {
            System.Console.WriteLine($"{targetName} получил {damage} урон. Осталось {newHealth}");
            return newHealth;
        }
    }
    static int CastSpell(int currentMana, int cost)
    {
        int newMana = currentMana - cost;
        if (newMana >= 0)
        {
            System.Console.WriteLine("Недостаточно маны!");
            return 0;
        }
        else
        {
            System.Console.WriteLine("Заклинание применено!");
            return newMana;
        }
    }
}