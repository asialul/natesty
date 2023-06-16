using Csv;

namespace PoliczSilnieTest
{

    [TestClass]
    public class Silnia_Test
    {

        [TestMethod]

        public void Silnia_SprawdzWynik()
        {
            List<int> num = new List<int>();
            List<int> wynik = new List<int>();

            var policzSilnie = new PoliczSilnie();
            var csv = File.ReadAllText("C:\\Users\\asial\\Desktop\\silnia.csv");

            foreach (var line in CsvReader.ReadFromText(csv))
            {
                // Header is handled, each line will contain the actual row data
                var numline = line["liczba"];
                var wynikline = line["silnia"];

                var dnumline = Convert.ToInt32(numline);
                var dwynikline = Convert.ToInt32(numline);

                num.Add(dnumline);
                wynik.Add(dwynikline);
            }

            for(int j = 0; j < num.Count; j++)
            {
                var testwynik = policzSilnie.Silnia(num[j]);
                Assert.AreEqual(testwynik, wynik[j]);
            }
            
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 6)]
        [DataRow(4, 24)]
        public void Silnia_SprawdzWynik(int num, int wynik)
        {
            // Arrange
            var policzSilnie = new PoliczSilnie();

            // Act
            var testwynik = policzSilnie.Silnia(num);

            //Assert
            Assert.AreEqual(testwynik, wynik);
        }

        [TestMethod]
        public void Silnia_ArgMniejszyOdZera_WyrzucaWyjatek()
        {
            // Arrange
            var policzSilnie = new PoliczSilnie();
            int num = -2;

            // Act
            policzSilnie.Silnia(num);
       
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => policzSilnie.Silnia(num));
           
        }
    }
}