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

    public static void ChangeDisplay(string[] array, string letter, int arg = 0)
    {
        if (arg < 2)
        {
            array[arg * 2] = letter;
        }
        else
        {
            array[(arg * 2) + 8] = letter;
        }
    }

    public static void GuessColors(string[] colors)
    {
        string[] display = { "\n\t\t\t\ti", " ", "i", " ", "x", "-", "x", "-", "x", "-", "x", " ", "i", " ", "i\n" };
        while (!(display[0] == "o" && display[2] == "o" && display[12] == "o" && display[14] == "o"))
        {
            foreach (string d in display)
            {
                Console.Write(d);
            }
            Console.WriteLine("\nGuess the colors : \"o\" = good place | \"w\" = wrong place | \"i\" = non-existent color\n");
            Console.WriteLine("\t\t--> red green blue cyan magenta gray darkblue yellow <--");
            string[] colorPlayer = Console.ReadLine().Split(' ');
            CheckArray(colorPlayer);
            display[0] = "i"; display[2] = "i"; display[12] = "i"; display[14] = "i";
            for (int i = 0; i < colorPlayer.Length; i++)
            {
                display[(i * 2) + 4] = colorPlayer[i];
            }
            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 0; j < colorPlayer.Length; j++)
                {
                    if (colors[i].Contains(colorPlayer[j]))
                    {
                        ChangeDisplay(display, "w", j);
                    }
                }
                if (colors[i].Equals(colorPlayer[i]))
                {
                    ChangeDisplay(display, "o", i);
                }
            }
        }
        Console.WriteLine("\n--- Congratulations ! You won ! ---");
    }

}