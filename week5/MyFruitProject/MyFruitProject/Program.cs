using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFruitProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = ReadFile("values.csv");
            List<Food> food = new List<Food>();
            food = GetFoods(file);
            PrintFood(food);
        }

        static string[] ReadFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            return lines;
        }

        static List<Food> GetFoods(string[] file)
        {
            Dictionary<int, List<string>> file_items = new Dictionary<int, List<string>>();
            List<Food> food = new List<Food>();

            for (int i = 0; i < file.Length; i++) file_items.Add(i, GetItems(file[i]));

            for(int i = 1; i < file.Length; i++)
            {
                Food f;
                string type = "", name = "", color = "";
                int piece = 0;

                for (int j = 0; j < file_items[0].Count(); j++)
                {
                    switch (file_items[0][j])
                    {
                        case "type":
                            type = file_items[i][j];
                            break;
                        case "name":
                            name = file_items[i][j];
                            break;
                        case "color":
                            color = file_items[i][j];
                            break;
                        case "piece":
                            piece = int.Parse(file_items[i][j]);
                            break;
                        default:
                            Console.WriteLine($"Header '{file_items[0][j]}' is not valid header.");
                            break;
                    }
                }
                f = new Food(type, name, color, piece);
                food.Add(f);
            }
            return new List<Food>(food);
        }
        static List<string> GetItems(string line)
        {
            string current_word = "";
            List<string> items = new List<string>();

            //split line
            foreach(char c in line)
            {
                if (c == ',')
                {
                    if (current_word != "")
                    {
                        items.Add(current_word);
                        current_word = "";
                    }
                }
                else
                {
                    current_word += c.ToString();
                }
            }
            //kalan itemleri ekler
            if (current_word != "") items.Add(current_word);

            //items listesindeki örneği geri döndürür
            return new List<string>(items);
        }

        static void PrintFood(List<Food> food)
        {
            foreach (Food f in food)
            {
                Console.WriteLine($"{f.Name} {f.Piece.ToString()} taneli {f.Color} renkli bir {f.Type}dir.");
            }

        }
    }
}
