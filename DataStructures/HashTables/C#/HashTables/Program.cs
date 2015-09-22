using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
	class Program
	{
		static void Main (string[] args)
		{

			DateTime start, end;
			int count = 10000000;

			start = DateTime.Now;
			HashMap<string, int> map = new HashMap<string, int> ();

			for (int i = 0; i < count; i++) {
				map [i + ""] = i;
			}

			end = DateTime.Now;
			Console.WriteLine ("Finished in {0} seconds", end-start);

			start = DateTime.Now;
			Dictionary<string, int> dict = new Dictionary<string, int> ();

			for (int i = 0; i < count; i++) {
				dict [i + ""] = i;
			}

			end = DateTime.Now;
			Console.WriteLine ("Finished in {0} seconds", end-start);
		}
	}
}
