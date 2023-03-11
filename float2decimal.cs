using System;
namespace DecimalTest
{
	public class Program
    {
        public static void print_floatToDecimal(float original_Float, int num)
        {
			Decimal original_Decimal = Convert.ToDecimal(original_Float);
			
            Console.WriteLine("#test s21_floatToDecimal_{0}", num);
			Console.WriteLine(" // original_Float = {0};", original_Float);
            Console.WriteLine(" float srcFloat_C;\n s21_decimal result_C;");
			Console.WriteLine(" s21_decimal_set_default(&result_C);");
			
            int[] bits = decimal.GetBits(original_Decimal);
			
            Console.WriteLine(" srcFloat_C = {0}f;", original_Float);
            Console.WriteLine(" s21_from_float_to_decimal(srcFloat_C, &result_C);");
			Console.WriteLine(" test(result_C, {0}, {1}, {2}, {3});\n"
							, bits[0], bits[1], bits[2], bits[3]);
        }
        
		static float NextFloat(Random random)
		{
			var array = new byte[4];
			random.NextBytes(array);
			float randomFloat = BitConverter.ToSingle(array, 0);
			return randomFloat;
		}

        public static void Main(string[] args)
        {
			System.Random randomValue = new System.Random();
			
			
            for (int i = 1; i <= 10; i++)
            {
			  float floatVal = NextFloat(randomValue);
			  if(floatVal > 1.175494E-28 && floatVal < 3.402823e+28)
			  {
				  print_floatToDecimal(floatVal, i);
			  }
			  else i--;
            }
        }
    }
}
