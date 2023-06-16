using Csv;
using System.Runtime.CompilerServices;

public class PoliczSilnie
{
    
        string exceptionMessage = "Liczba nie może być mniejsza od zera!";

        public int Silnia(int num)
        {
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException();

            } else {

            int silnia = 1;

            for (int i = 1; i <= num; i++)
            {
                silnia *= i;
            }
                return silnia;
            }
        }

    public static void Main()
    {
        var n = new PoliczSilnie();
        n.Silnia(3);

        var csv = File.ReadAllText("C:\\Users\\asial\\Desktop\\silnia.csv");

            foreach (var line in CsvReader.ReadFromText(csv))
            {
                // Header is handled, each line will contain the actual row data
                var num = line["liczba"];
                var wynik = line["silnia"];
            Console.WriteLine(num + " " + wynik);
            }


    }

}