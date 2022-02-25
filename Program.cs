// cheung kai chun ronald 202670M
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket
{
    class Program
    {
        static void Main(string[] args)
        {
            //PokemonMaster list for checking pokemon evolution availability.    
            List<PokemonMaster> pokemonMasters = new List<PokemonMaster>(){
            new PokemonMaster("Pikachu", 2, "Raichu"),
            new PokemonMaster("Eevee", 3, "Flareon"),
            new PokemonMaster("Charmander", 1, "Charmeleon")
            };

            //Use "Environment.Exit(0);" if you want to implement an exit of the console program
            //Start your assignment 1 requirements below.
            List<Pokemon> pokemons = new List<Pokemon>();
            while (true)
            {
                Console.WriteLine("*****************************");
                Console.WriteLine("Welcome to Pocket Pocket App");
                Console.WriteLine("*****************************");
                Console.WriteLine("(1). Add pokemon to my pocket");
                Console.WriteLine("(2). List pokemon(s) in my pocket");
                Console.WriteLine("(3). Check if i can evolve pokemon");
                Console.WriteLine("(4). Evolve pokemon");
                Console.WriteLine("(5) Remove pokemon from pocket");
                Console.Write("Please only enter [1,2,3,4,5] or Q to quit:");
                string input = Console.ReadLine().ToUpper();

                // each object in pokemonMasters list
                var p_evolve = pokemonMasters[0];
                var e_evolve = pokemonMasters[1];
                var c_evolve = pokemonMasters[2];
                // name of each pokemon in pokemonMasters list
                var p_name = p_evolve.Name;
                var e_name = e_evolve.Name;
                var c_name = c_evolve.Name;
                // no of each pokemon needed to evolve from pokemonMasters list
                var no_of_pikachu_to_evolve = p_evolve.NoToEvolve;
                var no_of_eevee_to_evolve = e_evolve.NoToEvolve;
                var no_of_charmander_to_evolve = c_evolve.NoToEvolve;
                //evolved name of each pokemon in pokemonMasters list
                var p_evolved_name = p_evolve.EvolveTo;
                var e_evolved_name = e_evolve.EvolveTo;
                var c_evolved_name = c_evolve.EvolveTo;

                // no of each pokemon subclass object in list
                var p_count = pokemons.Where(p => p.pname.ToUpper() == p_name.ToUpper()).Count();
                var e_count = pokemons.Where(p => p.pname.ToUpper() == e_name.ToUpper()).Count();
                var c_count = pokemons.Where(p => p.pname.ToUpper() == c_name.ToUpper()).Count();

                // add pokemon
                if (input == "1")
                {
                    try
                    {
                        Console.Write("Enter Pokemon's name:");
                        string pname = Console.ReadLine();
                        if (pname.ToUpper() != p_name.ToUpper() && pname.ToUpper() != e_name.ToUpper() && pname.ToUpper() != c_name.ToUpper())
                        {
                            Console.WriteLine("Invalid pokemon name!");
                            continue;
                        }

                        Console.Write("Enter Pokemon's HP:");
                        int hp = Convert.ToInt32(Console.ReadLine());
                        if (hp <= 0)
                        {
                            Console.WriteLine("Pokemon HP cannot be zero or negative!");
                            continue;
                        }

                        Console.Write("Enter Pokemon's Exp:");
                        int exp = Convert.ToInt32(Console.ReadLine());
                        if (exp < 0)
                        {
                            Console.WriteLine("Pokemon EXP cannot be negative!");
                            continue;
                        }

                        if (pname.ToUpper() == p_name.ToUpper())
                        {
                            pokemons.Add(new Pikachu(pname, hp, exp, "Lightning Bolt"));
                        }
                        else if (pname.ToUpper() == e_name.ToUpper())
                        {
                            pokemons.Add(new Eevee(pname, hp, exp, "Run Away"));
                        }
                        else if (pname.ToUpper() == c_name.ToUpper())
                        {
                            pokemons.Add(new Charmander(pname, hp, exp, "Solar Power"));
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Only integers are accepted for HP and EXP field!");
                    }

                }
                // display all pokemons in ascending hp order
                else if (input == "2")
                {
                    if (pokemons.Count > 0)
                    {
                        try
                        {
                            List<Pokemon> SortedList = pokemons.OrderBy(p => p.hp).ToList();
                            Console.WriteLine("-----------------");
                            foreach (Pokemon p in SortedList)
                            {
                                Console.WriteLine("Name: " + p.pname);
                                Console.WriteLine("HP: " + p.hp);
                                Console.WriteLine("Exp: " + p.exp);
                                Console.WriteLine("Skill: " + p.skill);
                                Console.WriteLine("-----------------");
                                Console.WriteLine("-----------------");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No pokemon in pocket!");
                    }
                }
                // check if any pokemon in pocket can be evolved
                else if (input == "3")
                {
                    if (pokemons.Count > 0)
                    {
                        try
                        {
                            if (p_count >= no_of_pikachu_to_evolve)
                            {
                                Console.WriteLine(p_name + " --> " + p_evolved_name);
                            }
                            if (e_count >= no_of_eevee_to_evolve)
                            {
                                Console.WriteLine(e_name + " --> " + e_evolved_name);
                            }
                            if (c_count >= no_of_charmander_to_evolve)
                            {
                                Console.WriteLine(c_name + " --> " + c_evolved_name);
                            }
                            if (p_count < no_of_pikachu_to_evolve && e_count < no_of_eevee_to_evolve && c_count < no_of_charmander_to_evolve)
                            {
                                Console.WriteLine("No pokemon can be evolved!");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No pokemon in pocket!");
                    }
                }
                // evolve all pokemons that can be evolved
                // assuming evolving consumes any extra pokemons needed
                else if (input == "4")
                {
                    if (pokemons.Count > 0)
                    {
                        try
                        {
                            if (p_count >= no_of_pikachu_to_evolve)
                            {
                                Console.WriteLine(Evolve(pokemons, p_name, p_evolved_name));
                                // remove one pikachu after evolving
                                var remove = pokemons.First(p => p.pname.ToUpper() == p_name.ToUpper());
                                pokemons.Remove(remove);
                            }
                            if (e_count >= no_of_eevee_to_evolve)
                            {
                                Console.WriteLine(Evolve(pokemons, e_name, e_evolved_name));
                                // remove two eevees after evolving
                                for (int i = 0; i < 2; i++)
                                {
                                    var remove = pokemons.First(p => p.pname.ToUpper() == e_name.ToUpper());
                                    pokemons.Remove(remove);
                                }
                            }
                            if (c_count >= no_of_charmander_to_evolve)
                            {
                                Console.WriteLine(Evolve(pokemons, c_name, c_evolved_name));
                            }
                            if (p_count < no_of_pikachu_to_evolve && e_count < no_of_eevee_to_evolve && c_count < no_of_charmander_to_evolve)
                            {
                                Console.WriteLine("No pokemon to evolve!");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No pokemon in pocket!");
                    }

                }
                // remove pokemon based on user input
                else if (input == "5")
                {
                    if (pokemons.Count > 0)
                    {
                        try
                        {
                            Console.Write("Enter Pokemon's name to remove:");
                            string pname = Console.ReadLine();
                            Console.Write("Enter Pokemon's HP to remove:");
                            int hp = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Pokemon's Exp to remove:");
                            int exp = Convert.ToInt32(Console.ReadLine());
                            var remove = pokemons.First(p => p.pname.ToUpper() == pname.ToUpper() && p.hp == hp && p.exp == exp);
                            Console.WriteLine(remove.pname + " with " + remove.hp + " HP and " + remove.exp + " EXP removed!");
                            pokemons.Remove(remove);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("No such pokemon to remove!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Only integers are accepted for HP and EXP field!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No pokemon in pocket!");
                    }

                }
                // exit program
                else if (input == "Q")
                {
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Invalid choice!");
                }

            }
        }
        //evolve method
        public static string Evolve(List<Pokemon> pokemons, string name, string evolved_name)
        {
            var pk = pokemons.Find(p => p.pname.ToUpper() == name.ToUpper());
            // evolve pokemon
            pk.pname = evolved_name;
            pk.hp = 0;
            pk.exp = 0;

            string text = name + " evolved to " + evolved_name;
            return text;
        }
    }
}
