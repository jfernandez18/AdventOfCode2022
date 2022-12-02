
namespace AdventOfCode2022.Code
{
    public class Day1
    {
        public static void CalculateCalories(string filePath)
        {
            // Lista de los 3 elfos con mas calorías.
            List<int> moreCalorieElves = new(3);
            int calorieCounter = 0;
            int min;

            using StreamReader streamReader = new(filePath);

            string? line;

            while ((line = streamReader.ReadLine()) != null)
            {
                if (!line.Equals(string.Empty))
                {
                    calorieCounter += int.Parse(line);
                }
                else
                {
                    // Obtenemos los 3 elfos con el mayor número de calorias
                    if (moreCalorieElves.Count < 3)
                    {
                        moreCalorieElves.Add(calorieCounter);
                    }
                    else
                    {
                        min = moreCalorieElves.Min();

                        if (calorieCounter > min)
                        {
                            int index = moreCalorieElves.IndexOf(min);
                            moreCalorieElves.RemoveAt(index);
                            moreCalorieElves.Add(calorieCounter);
                        }
                    }
                    calorieCounter = 0;
                }
            }

            if (moreCalorieElves.Count < 3)
            {
                moreCalorieElves.Add(calorieCounter);
            }
            else
            {
                min = moreCalorieElves.Min();

                if (calorieCounter > min)
                {
                    int index = moreCalorieElves.IndexOf(min);
                    moreCalorieElves.RemoveAt(index);
                    moreCalorieElves.Add(calorieCounter);
                }
            }

            moreCalorieElves = moreCalorieElves.OrderBy(x => x).ToList();

            Console.WriteLine(String.Format("El número de calorías que tiene el elfo con más calorías es: {0}", moreCalorieElves.Last()));
            Console.WriteLine(String.Format("El número de calorías que tienen los tres elfos con más calorías es: {0}", moreCalorieElves.Sum()));
        }
    }
}
