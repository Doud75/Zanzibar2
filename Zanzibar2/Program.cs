using System;
using System.Collections;

namespace ZanzibarGame
{
    public class Zanzibar2
    {
        private static ArrayList players = new ArrayList();

        private static void setPlayers()
        {
            bool keepAdding = true;
            do
            {
                Console.WriteLine("Ajouter un joueur (help pour afficher l'aide, et entrez ok pour valider)");
                string player = Console.ReadLine();

                if (player == "help")
                {
                    Zanzibar2.displayHelp();
                }
                else if (player == "ok")
                {
                    if (Zanzibar2.players.Count == 0)
                    {
                        Console.WriteLine("Minimum 1 joueur");
                    }
                    else
                    {
                        keepAdding = false;
                    }
                }
                else
                {
                    players.Add(player);
                }
            } while (keepAdding);
        }

        private static void displayHelp()
        {
            Console.WriteLine("le but du jeu est de deviner un nombre entre 1 et 5");
        }

        public static void Main(string[] args)
        {
            Zanzibar2.setPlayers();
            Zanzibar2.playGame();
        }

        private static void playGame()
        {
            do
            {
                foreach (string player in Zanzibar2.players)
                {
                    Console.WriteLine($"{player}, Choisi un chiffre entre 1 et 5");
                    try
                    {
                        int myNumber = int.Parse(Console.ReadLine());

                        if (myNumber < 1)
                        {
                            Console.WriteLine("As tu bien compris les régles?");
                            Zanzibar2.displayHelp();
                        }
                        else if (myNumber < 5)
                        {
                            Console.WriteLine($"{myNumber + 1}, Perdu tu bois!!");
                        }
                        else if (myNumber == 5)
                        {
                            Console.WriteLine("4, Perdu tu bois!!");
                        }
                        else if (myNumber == 42)
                        {
                            Console.WriteLine("Gagné!! fini ton verre tu es un génie!!");
                            return;
                        }
                        else
                            Console.WriteLine("Tu as trop bu, arrête de jouer");
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Arrête de boire, écris");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Booba a dit, si tu te vesqui, t'es une lopsa!!");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("J'ai dit un chiffre!! Tu bois!!");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Cul sec!!");
                    }
                }
            }
            while (true);
        }
    }
}