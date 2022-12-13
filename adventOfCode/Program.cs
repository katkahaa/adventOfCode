using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace adventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<int> elves = new List<int>();
            int calories = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                    calories += int.Parse(lines[i]);
                else
                {
                    elves.Add(calories);
                    calories = 0;
                }
            }
            elves.Add(calories);

            Console.WriteLine(GetMaxCalories(elves));
            Console.WriteLine(GetMaxCaloriesOfFirstElves(elves, 3));
            Console.ReadLine();
        }

        static int GetMaxCalories(List<int> elves)
        {
            int maxCalories = 0;
            foreach (var elf in elves)
            {
                if (elf > maxCalories)
                    maxCalories = elf;
            }
            return maxCalories;
        }

        static int GetMaxCaloriesOfFirstElves(List<int> elves, int elfCount)
        {
            int maxCalories;
            int totalCalories = 0;

            for (int i = 0; i < elfCount; i++)
            {
                maxCalories = GetMaxCalories(elves);
                elves.Remove(maxCalories);
                totalCalories += maxCalories;
            }
            return totalCalories;
        }
    }
}
