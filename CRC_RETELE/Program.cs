using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRC_RETELE
{
    public class Program
    {
      
       
        static void Main(string[] args)
        {

            Console.WriteLine("introdu lungimea mesajului");
            int lungimeMesaj = int.Parse(Console.ReadLine());
           string[] mesaj = new string[lungimeMesaj];
           
            Console.WriteLine("introdu mesajul");
            for (int i = 0; i < lungimeMesaj; i++)
            {
                mesaj[i]=Console.ReadLine();

            }
         

            Console.WriteLine("introdu lungimea generatorului " );
            int lungimeGenerator = int.Parse(Console.ReadLine());
            string[] generator = new string[lungimeGenerator];
          
            Console.WriteLine("introdu generator");
            for (int i = 0; i < lungimeGenerator; i++)
            {
                generator[i]=Console.ReadLine();
            }

            //Anexeaza 0-uri
            int nrZerouri = lungimeGenerator - 1; //pt ca daca are grad 5 merge de la 0 la 5 --> 6
            Console.WriteLine("Nr de zerouri anexate: "+ nrZerouri);
            string[] t = new string[lungimeMesaj + nrZerouri] ;
            for (int i = 0; i < lungimeMesaj + nrZerouri; i++)
            {
                if(i >= lungimeMesaj)
                {
                    t[i] = "0";
                }
                else
                {
                    t[i] += mesaj[i];
                }
                
            }
            string[] copieT = t;

            Console.WriteLine("Mesajul dupa ce i-au fost anexate zerouri: ");
            for (int i = 0; i < lungimeMesaj+nrZerouri; i++)
            {
                Console.Write(t[i]);
            }
            Console.WriteLine("\n");

            string[] rezultat;
            rezultat = Calculeazaxor(t, generator);
            Console.WriteLine( "****************");
            Console.WriteLine("REZULTATE INTERMEDIARE: ");
            while(rezultat.Length >= generator.Length)
            {

                rezultat = TaieZerouri(rezultat);
                Console.WriteLine("REZULTAT : ");
                foreach (var item in rezultat)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine("\n");
                if (generator.Length <= rezultat.Length)
                {
                    rezultat = Calculeazaxor(rezultat, generator);
                   
                }
                   
                
            }
            Console.WriteLine("****************");
            Console.WriteLine("REST : ");
           foreach (var item in rezultat)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
            //CALCULARE MESAJ FINAL
            string[] mesajFinal;
            mesajFinal = CalculeazaxorFinal(copieT, rezultat);
            Console.WriteLine("MESAJ FINAL ");
            foreach (var item in mesajFinal)
            {
                Console.Write($"{item} ");
            }
           

            //*****************************



            Console.ReadKey();
        }
        public static string[] Calculeazaxor(string[] a, string[] b)
        {
        
            List<string> resultList = new List<string>();

            int n = a.Length;

            for(int i = 0; i < b.Length; i++)
            {
                if ((a[i] == "1" && b[i] == "1") || (a[i] == "0" && b[i] == "0"))
                { resultList.Add("0"); }
                else if ((a[i] == "1" && b[i] == "0") || (a[i] == "0" && b[i] == "1"))
                { resultList.Add("1"); }
            }

            for (int i = b.Length; i < n; i++)
            {
                resultList.Add(a[i]);
            }
            return resultList.ToArray();

        }
        public static string[] CalculeazaxorFinal(string[] a, string[] b)
        {
            
            List<string> resultList = new List<string>();

            int n = a.Length;

            for (int i = 0; i < a.Length-b.Length; i++)
            {
                resultList.Add(a[i]);
            }
            for (int i = 0; i < b.Length; i++)
            {
                if ((a[a.Length-b.Length+i] == "1" && b[i] == "1") || (a[a.Length-b.Length+i] == "0" && b[i] == "0"))
                { resultList.Add("0"); }
                else if ((a[a.Length - b.Length + i] == "1" && b[i] == "0") || (a[a.Length - b.Length + i] == "0" && b[i] == "1"))
                { resultList.Add("1"); }
            }

         
            return resultList.ToArray();

        }

        public static string[] TaieZerouri(string[] rezultat)
        {
            int i = -1;
            int k = 0;
            string[] output;
            while(rezultat[i+1] == "0")
            {
                i++;
            }
            output = new string[rezultat.Length - i-1];
            for(int j = i+1; j< rezultat.Length; j++)
            {
                output[k] = rezultat[j];
                k++;
            }

            return output;
        }
    }
}
