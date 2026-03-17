using System.Threading.Tasks;

namespace _03_17
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            ServerConnection connection = new ServerConnection("http://127.0.0.1:3000");
            Geckos all = await connection.GetGeckos();
            
           all.geckos.ForEach(x => Console.WriteLine(x));
            bool success = await connection.DeleteGecko();
            bool result = await connection.CreateGecko("fali gecko");
            Console.WriteLine(success);
            Console.WriteLine(String.Join('\n', all.geckos));
            Console.WriteLine("______________________________");
            Console.WriteLine("gekko szam",+ all.geckos.Count());
            Console.WriteLine("______________________________");
            Console.WriteLine("leghosszabb karakter",+all.geckos.Max(a => a.Length));
            Console.WriteLine("______________________________________");
            Console.WriteLine( all.geckos.Find(a => a.Length == all.geckos.Max(a => a.Length)));
            Console.WriteLine("______________________________________");

        }
    }
}
