public class Mastermind
{
    static void Main()
    {
        Console.WriteLine("\t\t--- Pick 4 colors and write them separated by a space : ---");
        Console.WriteLine("\t\t--> red green blue cyan magenta gray darkblue yellow <--");
        string[] colors = Console.ReadLine().Split(' ');
        CheckArray(colors);
        Console.WriteLine("\n\t\t\t   ---- Start the game : ----");
        GuessColors(colors);
    }

    public static void CheckArray(string[] array)
    {
        string[] colors = new string[] { "red", "green", "blue", "cyan", "magenta", "gray", "darkblue", "yellow" };
        int goodColors = 0;
        while (goodColors <= 4)
        {
            foreach (string word in array)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i].Equals(word))
                    {
                        goodColors++;
                    }
                }
            }
            if (goodColors == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please pick 4 colors in this list :");
                Console.WriteLine("--> red green blue cyan magenta gray darkblue yellow <--");
                colors = Console.ReadLine().Split(' ');
            }
        }
    }

    public static void GuessColors(string[] colors)
    {
        bool loop = true;
        while (loop)
        {
            int count = 0;
            Console.WriteLine("\nGuess the colors : \"o\" = good place | \"w\" = wrong place | \"i\" = non-existent color\n");
            Console.WriteLine("\t\t--> red green blue cyan magenta gray darkblue yellow <--");
            string[] colorPlayer = Console.ReadLine().Split(' ');
            CheckArray(colorPlayer);

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i].Equals(colorPlayer[i]) && i < 2)
                {
                    count++;
                    Console.Write(" o " + count);
                    continue;
                } 

                for (int j = 0; j < colorPlayer.Length; j++)
                {
                    if (colorPlayer[i].Equals(colors[j]) && i < 2)
                    {
                        Console.Write(" w " + count);
                        break;
                    } 
                    else
                    {
                        if (j == 3 && i < 2)
                        {
                            Console.Write(" i ");
                        }  
                    }
                }
            }

            for (int i = 0; i < colorPlayer.Length; i++)
            {
                switch (colorPlayer[i])
                {
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red; break;
                    case "green":
                        Console.ForegroundColor = ConsoleColor.Green; break;
                    case "blue":
                        Console.ForegroundColor = ConsoleColor.Blue; break;
                    case "cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan; break;
                    case "magenta":
                        Console.ForegroundColor = ConsoleColor.Magenta; break;
                    case "gray":
                        Console.ForegroundColor = ConsoleColor.Gray; break;
                    case "darkblue":
                        Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow; break;
                }
                Console.Write($"{colorPlayer[i]} ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i].Equals(colorPlayer[i]) && i >= 2)
                {
                    count++;
                    Console.Write(" o " + count);
                    
                    continue;
                }

                for (int j = 0; j < colorPlayer.Length; j++)
                {
                    if (colorPlayer[i].Equals(colors[j]) && i >= 2)
                    {
                        Console.Write(" w " + count);
                        break;
                    }
                    else
                    {
                        if (j == 3 && i >= 2)
                        {
                            Console.Write(" i ");
                        }
                    }
                }
            }

            if (count == 4)
            {
                Console.WriteLine("fini");
                loop = false;
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n--- Congratulations ! You won ! ---");
    }

}