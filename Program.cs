using System;
using System.Collections.Generic;

namespace RPGGame
{

    class Program
    {
        static void Main()
        {
            Hero player = new Hero();
            
            Console.WriteLine("Enter your hero's name:");
            String HeroName = Console.ReadLine();

            player.Name = HeroName;
            player.Health = 100;

            Console.WriteLine($"Player: {player.Name} has {player.Health} health.");

            bool isPlaying = true; // Variable to control the game loop
            while (isPlaying)
            {
                Console.WriteLine("Where do you want to go? (1) Dark Forest (2) Deep Cave (3) Quit");
                String choice = Console.ReadLine();
                if (choice == "1")
                {
                    Monster zombie = new Monster();
                    zombie.Name = "Zombie";
                    zombie.Health = 40;
                    zombie.Damage = 30;

                    while (zombie.Health > 0 && player.Health > 0)
                    {
                        player.AttackMonster(zombie); // Player attacks the zombie

                        if (zombie.Health > 0)
                        {
                            zombie.Attack(player); // Zombie attacks the player back (if survived)
                        }
                    }
                }

                else if (choice == "2")
                {
                    Monster vampire = new Monster();
                    vampire.Name = "Vampire";
                    vampire.Health = 30;
                    vampire.Damage = 20;


                    while (vampire.Health > 0 && player.Health > 0)
                    {
                        player.AttackMonster(vampire); // Player attacks the vampire

                        if (vampire.Health > 0)
                        {
                            vampire.Attack(player); // Vampire attacks the player back (if survived)
                        }
                    }
                }

                else if(choice == "3")
                {
                    break; // Exit the game loop
                }
            }

        }

        class Hero
        {
            public string Name;
            public int Health;

            public void TakeDamage(int damage)
            {
                this.Health = this.Health - damage;
                Console.WriteLine($"Player: {this.Name} has {this.Health} health left.");
            }

            public void AttackMonster(Monster target)
            {
                Console.WriteLine($"{this.Name} attacks {target.Name}!");
                target.Health -= 10; // Hero deals 10 damage to the monster
                Console.WriteLine($"Monster: {target.Name} has {target.Health} health left.");
            }
        }
        
        class Monster
        {
            public string Name;
            public int Health;
            public int Damage;

            // Method for the monster to attack the hero (player)
            public void Attack(Hero target)
            {
                Console.WriteLine($"{this.Name} attacks {target.Name}!");

                target.TakeDamage(Damage); // Monster deals {Damage} to the hero (player)
            }
        }
    }
}