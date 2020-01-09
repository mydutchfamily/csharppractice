using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_Conditions
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Dictionary weather");
            Console.WriteLine("Программа может перевести 10 слов с русского на английский");
            Console.WriteLine("Словарный запас: туман, солнечно, пасмурно, дождь");//fog, sunny, Mainly cloudy, rain
            Console.WriteLine("Словарный запас: ветер, снег, град, антициклон, тучи");// wind, snow, hail, anticyclone, clouds

            while (true)
            {

                Console.Write("Попробуй набрать одно из слов:");
                string rusword = Console.ReadLine();
                string engword = "Word unknown";
                switch (rusword)
                {
                    case "туман":
                        {
                            engword = "fog";
                            break;
                        }
                    case "солнечно":
                        {
                            engword = "sunny";
                            break;
                        }
                    case "пасмурно":
                        {
                            engword = "Mainly cloudy";
                            break;
                        }
                    case "дождь":
                        {
                            engword = "rain";
                            break;
                        }
                    case "ветер":
                        {
                            engword = "wind";
                            break;
                        }
                    case "снег":
                        {
                            engword = "snow";
                            break;
                        }
                    case "град":
                        {
                            engword = "hail";
                            break;
                        }
                    case "антициклон":
                        {
                            engword = "anticyclone";
                            break;
                        }
                    case "тучи":
                        {
                            engword = "clouds";
                            break;
                        }
                }

                Console.WriteLine("слово {0}, перевод {1}", rusword, engword);
                Console.Write("Продолжить? д/н");
                if ("н" == Console.ReadLine())
                {
                    break;
                }

            }
        }
    }
}
