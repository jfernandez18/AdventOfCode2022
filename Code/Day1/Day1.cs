
namespace AdventOfCode2022.Code
{
    public class Day1
    {
        public static void CalculateCalories(string filePath)
        {
            // Lista de los 3 elfos con mas calorías.
            List<int> moreCalorieElfs = new(3);
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
                    if (moreCalorieElfs.Count < 3)
                    {
                        moreCalorieElfs.Add(calorieCounter);
                    }
                    else
                    {
                        min = moreCalorieElfs.Min();

                        if (calorieCounter > min)
                        {
                            int index = moreCalorieElfs.IndexOf(min);
                            moreCalorieElfs.RemoveAt(index);
                            moreCalorieElfs.Add(calorieCounter);
                        }                        
                    }
                    calorieCounter = 0;
                }

                if (streamReader.EndOfStream)
                {
                    // Obtenemos los 3 elfos con el mayor número de calorias
                    if (moreCalorieElfs.Count < 3)
                    {
                        moreCalorieElfs.Add(calorieCounter);
                    }
                    else
                    {
                        min = moreCalorieElfs.Min();

                        if (calorieCounter > min)
                        {
                            int index = moreCalorieElfs.IndexOf(min);
                            moreCalorieElfs.RemoveAt(index);
                            moreCalorieElfs.Add(calorieCounter);
                        }
                    }
                }
            }

            moreCalorieElfs = moreCalorieElfs.OrderBy(x => x).ToList();

            Console.WriteLine(String.Format("El número de calorías que tiene el elfo con más calorías es: {0}", moreCalorieElfs.Last()));
            Console.WriteLine(String.Format("El número de calorías que tienen los tres elfos con más calorías es: {0}", moreCalorieElfs.Sum()));
        }
    }
}
