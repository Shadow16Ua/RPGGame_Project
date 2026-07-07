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
                    zombie.Damage = 20;

                    while (zombie.Health > 0 && player.Health > 0)
                    {

                        Console.WriteLine("Do you want to attack, heal or run away? (a/h/r)"); // Prompt the player to choose between attacking, healing, or running away
                        string Choice = Console.ReadLine();

                        if (Choice.ToLower() == "a") // ToLower() method is used to make the input case-insensitive
                        {
                            player.AttackMonster(zombie); // Player attacks the zombie
                        }
                        else if (Choice.ToLower() == "h")
                        {
                            player.Heal(20); // Heal the player for 20 
                        }

                        else if (Choice.ToLower() == "r")
                        {
                            bool ranAway = player.RunAway(); // Attempt to run away

                            if (ranAway == true)
                            {
                                break; // Exit the battle loop if the player successfully runs away
                            }
                        }

                        if (zombie.Health > 0)
                        {
                            zombie.Attack(player); // Zombie attacks the player back (if survived)
                        }

                        else
                        {
                            Console.WriteLine($"{player.Name} has defeated the {zombie.Name}!");
                        }
                    }
                }

                else if (choice == "2")
                {
                    Monster vampire = new Monster();
                    vampire.Name = "Vampire";
                    vampire.Health = 30;
                    vampire.Damage = 10;


                    while (vampire.Health > 0 && player.Health > 0)
                    {
                        Console.WriteLine("Do you want to attack, heal or run away? (a/h/r)"); // Prompt the player to choose between attacking, healing, or running away
                        string Choice = Console.ReadLine();

                        if (Choice.ToLower() == "a") // ToLower() method is used to make the input case-insensitive
                        {
                            player.AttackMonster(vampire); // Player attacks the vampire
                        }
                        else if (Choice.ToLower() == "h")
                        {
                            player.Heal(20); // Heal the player for 20 
                        }

                        else if (Choice.ToLower() == "r")
                        {
                            bool ranAway = player.RunAway(); // Attempt to run away

                            if (ranAway == true)
                            {
                                break; // Exit the battle loop if the player successfully runs away
                            }
                        }

                        if (vampire.Health > 0)
                        {
                            vampire.Attack(player); // Vampire attacks the player back (if survived)
                        }
                        else 
                        {
                            Console.WriteLine($"{player.Name} has defeated the {vampire.Name}!");
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
                Console.WriteLine($"{this.Name} has {this.Health} health left.");
            }

            public void AttackMonster(Monster target)
            {
                Console.WriteLine($"{this.Name} attacks {target.Name}!");
                target.Health -= 20; // Hero deals 20 damage to the monster
                Console.WriteLine($"{target.Name} has {target.Health} health left.");
            }

            public void Heal(int amount)
            {
                this.Health += amount;
                Console.WriteLine($"{this.Name} heals for {amount} health. Total health: {this.Health}");
            }

            public bool RunAway() // Method for the hero to attempt to run away 
            {
                int chance = new Random().Next(0, 100); // Randomly generate a number between 0 and 100
                if (chance > 50) // 50% chance to successfully run away
                {
                    Console.WriteLine($"{this.Name} successfully runs away from the battle!");
                    return true;
                }
                else
                {
                    Console.WriteLine($"{this.Name} failed to run away and must continue fighting!");
                    return false;
                }
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