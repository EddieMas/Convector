using System;

namespace Convector
{
    class Program
    {
        static void Main(string[] args)
        {
            double USD_v_GRN = 33.20;
            double GRN_v_USD = 33.64;
            double EUR_v_GRN = 36.14;
            double GRN_v_EUR = 35.92;
            double USD_v_EUR = 1.13;

            double osechka = 0;
            string vibor_pomeniat_chto;
            string vibor_pomeniat_nachto;
            string cycleCondition = "";

            Console.WriteLine("Convektor valut\n");
            Console.Write("Vvedite kolichestvo griven: ");
            double GRN = Convert.ToDouble(Console.ReadLine());
            Console.Write("Vvedite kolichestvo dolarov: ");
            double USD = Convert.ToDouble(Console.ReadLine());
            Console.Write("Vvedite kolichestvo evro: ");
            double EUR = Convert.ToDouble(Console.ReadLine());

            while (cycleCondition != "exit")
            {
                Console.Clear();

                Console.SetCursorPosition(13, 0);
                Console.WriteLine("Tekuchij kurs valut:\n");
                Console.WriteLine($"Prodat dolari: {USD_v_GRN} griven, " + $"Kupit dolari: {GRN_v_USD} griven\n" + $"Prodat euro: {EUR_v_GRN} griven, " + $"Kupit euro: {GRN_v_EUR} griven\n");
                Console.SetCursorPosition(13, 4);
                Console.WriteLine($"Obmeniat euro/dolari: {USD_v_EUR}\n");
                Console.WriteLine($"U vas ect {GRN} griven, {USD} dolari, {EUR} euro\n");
                Console.Write("Vvedite kakuiu valutu hotite pomeniat 1 - griveni, 2 - dolari, 3 - euro: ");
                vibor_pomeniat_chto = Console.ReadLine();

                if (vibor_pomeniat_chto == "1")
                    osechka = GRN;
                else if (vibor_pomeniat_chto == "2")
                    osechka = USD;
                else if (vibor_pomeniat_chto == "3")
                    osechka = EUR;
                else
                    continue;

                Console.Write("Vvedite sumu kotoruiu hotite pominat: ");
                double changeSum = Convert.ToDouble(Console.ReadLine());

                if (changeSum > osechka || changeSum == 0)
                    continue;

                Console.Write("Vvedite kakuiu valutu hotite poluchit 1 - griveni, 2 - dolari, 3 - euro: ");
                vibor_pomeniat_nachto = Console.ReadLine();

                if (vibor_pomeniat_nachto == "1")
                {
                    if (vibor_pomeniat_chto == "2")
                    {
                        GRN += changeSum * USD_v_GRN;
                        USD -= changeSum;
                    }
                    else if (vibor_pomeniat_chto == "3")
                    {
                        GRN += changeSum * EUR_v_GRN;
                        EUR -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (vibor_pomeniat_nachto == "2")
                {
                    if (vibor_pomeniat_chto == "1")
                    {
                        USD += changeSum / GRN_v_USD;
                        GRN -= changeSum;
                    }
                    else if (vibor_pomeniat_chto == "3")
                    {
                        USD += changeSum * USD_v_EUR;
                        EUR -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (vibor_pomeniat_nachto == "3")
                {
                    if (vibor_pomeniat_chto == "1")
                    {
                        EUR += changeSum / GRN_v_EUR;
                        GRN -= changeSum;
                    }
                    else if (vibor_pomeniat_chto == "2")
                    {
                        EUR += changeSum / USD_v_EUR;
                        USD -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Obmen proizachol uspeshno.\n" +
                    $"U vas {GRN} griveni, {USD} dolari, {EUR} euro\n");
                Console.WriteLine("Dla prodoljenia najmite Enter, dla vihoda vveditr exit i najmite Enter");

                cycleCondition = Console.ReadLine();
            }
        }
    }
}