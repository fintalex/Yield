using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldExample
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach (int i in Power(2,8))
			{
				Console.WriteLine("{0} ", i);
			}

			foreach (int r in GetRandomList())
			{
				Console.WriteLine("{0} ", r);
			}

			var theGalaxies = new Galaxies();
			foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
			{
				Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
			}
		}

		public static IEnumerable<int> Power(int number, int exponent)
		{
			int result = 1;

			for (int i = 0; i < exponent; i++)
			{
				result = result * number;
				yield return result;
			}
		}

		public static IEnumerable<int> GetRandomList()
		{
			Random rnd = new Random();
			for (int i = 0; i < 10; i++)
			{
				yield return rnd.Next();
			}

		}

		
		public class Galaxies
		{

			public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
			{
				get
				{
					yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
					yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
					yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
					yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
				}
			}

		}

		public class Galaxy
		{
			public String Name { get; set; }
			public int MegaLightYears { get; set; }
		}
	}
}
