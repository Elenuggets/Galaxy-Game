using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Soldat
    {
        private int health;
        private int damage;
        private string name;
        private bool isHero;

        public Soldat(string Name)
        {
            // set the health
            Random random = new Random();
            health = random.Next(1000, 2000);

            // set the damage
            damage = random.Next(100, 500);

            // if is a hero ?
            isHero = false;

            // set the name
            name = Name;
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetDamage()
        {
            return damage;
        }

        public string GetName()
        {
            return name;
        }

        public void SetHealth(int hp)
        {
            if (hp > 0)
                health = hp;
            else
                health = 0;
        }

        public bool GetHero()
        {
            return isHero;
        }

        public void SetHero()
        {
            isHero = true;
        }

        public void attack(Soldat enemy)
        {
            // calculate the damage
            Random random = new Random();
            int p = random.Next(0, 100);

            // attack enemy - loose damage
            enemy.SetHealth(enemy.GetHealth() - damage * (1 + p/100));
            Console.WriteLine(name + " attack " + enemy.GetName() + "!\n");
            if (enemy.GetHealth() <= 0)
            {
                if (enemy.GetHero())
                    Console.WriteLine("Oh, the hero " + enemy.GetName() + " is dead..\n");
                else
                    Console.WriteLine(enemy.GetName() + " is dead..\n");
            }
            else
                Console.WriteLine(enemy.GetName() + " has " + enemy.GetHealth() + " life point.\n");
        }

        public bool isDead()
        {
            if (health <= 0)
                return true;
            return false;
        }

        public void print()
        {
            Console.WriteLine("My name is " + name + ", ");
            Console.WriteLine("I have " + health + " health and ");
            Console.WriteLine("I have " + damage + " damage. \n");
        }
    }
}
