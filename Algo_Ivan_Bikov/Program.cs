//Programata chete ot konzolata masiv ot chisla i izvejda ot sushtiq masiv samo chislata na fibonacci
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Ivan_Bikov
{
    class Program
    {
        static void Main()
        {

            int[] userNumbers;           //deklariram masiv za chislata vuvedeni ot potrebitelq
            int[] fibonacciNumbers;      //deklariram  masiv za chislata na fibonacci
            int userNumbersLenght = 0;   //goleminata na masiva za chislata vuvedeni ot potrebitelq
            int validatedNum = 0;        //promenliva v koqto se zapazvat validiraniq vhod ot konzolata

            Console.WriteLine("Please enter size of array:");
            while (!Int32.TryParse(Console.ReadLine(), out validatedNum) || validatedNum < 1)   //proverqzam dali vuvedeniq string ot potrebitelq e polojitelno cqlo chislo i go parsvam
            {
                Console.WriteLine("Please Enter a valid value!");
            }
            userNumbersLenght = validatedNum;

            userNumbers = new int[userNumbersLenght];   // zadavam golemina na masiva

            for (int i = 0; i < userNumbersLenght; i++)   //obhojdam masiva i vuvejdam stoinostite mu i gi validiram
            {
                Console.WriteLine("Please enter {0} element of array: ", i);
                while (!Int32.TryParse(Console.ReadLine(), out validatedNum) || validatedNum < 1)
                {
                    Console.WriteLine("Please Enter a valid value!");
                }
                userNumbers[i] = validatedNum;
            }


            fibonacciNumbers = FibonacciNumbers(userNumbers.Max()+1);      //izvikvam funkciqta koqto namira chislata na fibonacci, kato parametur podavam nai-golqmoto chislo(+1 za da raboti i za chisloto 1)
                                                                         // vuvedeno ot potrebitelq s cel da se izbegne izlishno generirane na chisla


            ReturnArray(CompareArrays(userNumbers, fibonacciNumbers));   //izvikvam funkciqta koqto izvejda elementite na masiv na ekrana i kato prametri
                                                                         //izvikvam funkciqta koqto sravnqva dva masiva i vrushta masiv v koito sa vsichki clisla na fibonacci, koito 
                                                                         //sa otkriti v masiva s chisla vuvedeni ot potrebitelq
                                                                         //kato parametri podavam masiva s chisla vuvedeni ot potrebitelq i masiva s chisla na fibonacci

            Console.ReadKey();

        }

        public static int[] FibonacciNumbers(int maxElement)            // chakam cqlo chislo koeto shte e gorna granica na masiva t.e funkciqta shte generira chisla na fibonacci
                                                                        // do tova chislo
        {
            int a = 0;
            int b = 1;

            List<int> list = new List<int>();                           //deklariram listvot celi chisla v koito zapazwam chisalta na fibonacci

            while (b < maxElement)
            {
                int c = a + b;
                a = b;
                b = c;
                list.Add(b);                                            //dobavqm chislata na fibonacci v lista
            }

            var fibonacciArray = list.ToArray();                        //suzdavam masiv  i v nego zapazvam elementite na lista

            return fibonacciArray;                                      //vrushtam masiv sus generiranite chisla na fibonacci
        }

        public static int[] CompareArrays(int[] userArray, int[] fibonacciArray)  //kato parametri chakam dva masiva, koito shte obhodq i shte vurna masiv, v koito 
                                                                                  //shte se pazqt vsichki chisla na fibonacci, koito sa otkriti 
                                                                                  //v masiva s chisla vyvedeni ot potrebitelq
        {
            List<int> list = new List<int>();

            foreach (var userNumber in userArray)
            {
                foreach (var fibonacciNumber in fibonacciArray)                 //obhojdam masivite i proveravam dali nqkoe ot chislata vuvedeni ot potrebitelq e
                {                                                               //chislo na fibonacci i go zapazvam v list
                    if (userNumber == fibonacciNumber)
                    {
                        list.Add(userNumber);
                    }
                }
            }

            var outputArray = list.ToArray();                                   //syzdavam masiv ot elementite na lista

            return outputArray;                                                 //vrushtam masiv s chislata na fibonacci otkriti v masiva s chila vuvedeni ot potrebitelq
        }

        public static void ReturnArray(int[] array)                             //funkciq koqto vizualizira elementite na masiv
        {
            if (array.Length > 0)                                               //proverqvam dali masiva ima stoinosti, ako ima gi izvejdam, ako nqma izvejdam -1
            {
                Console.WriteLine("[{0}]", string.Join(", ", array));
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}
