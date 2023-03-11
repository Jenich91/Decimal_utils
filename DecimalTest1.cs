// Конвертер из инта в децимал
using System;

namespace DecimalTest
{
	public class Program
    {
        public static void print_int_to_decimal(int original_int, int num)
        {
			Decimal original_Decimal = Convert.ToDecimal(original_int);
			
            Console.WriteLine("#test s21_int_to_decimal_{0}", num);
			Console.WriteLine(" // original_int = {0};", original_int);
            Console.WriteLine(" s21_decimal result_C;");
			
            int[] bits = decimal.GetBits(original_Decimal);
			
            Console.WriteLine(" int srcInt_C = {0};", original_int);
            Console.WriteLine(" s21_from_int_to_decimal(srcInt_C, &result_C);");
			Console.WriteLine(" test(result_C, {0}, {1}, {2}, {3});\n"
							, bits[0], bits[1], bits[2], bits[3]);
        }

        public static void Main(string[] args)
        {
			Random randomValue = new Random();
	
			
            for (int i = 1; i <= 100; i++)
            {
			  int randomNumber = randomValue.Next();
			  print_int_to_decimal(randomNumber, i);
            }
        }
    }
}
