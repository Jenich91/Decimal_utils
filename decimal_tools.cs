using System;

namespace DecimalTest
{
	public static class Program
    {
		public static int NextInt32(this Random rng)
		{
			 int firstBits = rng.Next(0, 1 << 4) << 28;
			 int lastBits = rng.Next(0, 1 << 28);
			 return firstBits | lastBits;
		}

		public static decimal NextDecimal(this Random rng)
		{
			 byte scale = (byte) rng.Next(29);
			 bool sign = rng.Next(2) == 1;
			 return new decimal(rng.NextInt32(),
								rng.NextInt32(),
								rng.NextInt32(),
								sign,
								scale);
		}
		
        public static void print_test(decimal original_dec, string c_func, int num) {
			int[] bits1 = decimal.GetBits(original_dec);
			
			Console.WriteLine("#test {0}_{1}", c_func, num);
			Console.WriteLine("// original_decimal = {0}\n", original_dec);
			
			Console.WriteLine(" s21_decimal original_decimal = {{{{{0}, {1}, {2}, {3}}}, 0}};", bits1[0], bits1[1], bits1[2], bits1[3]);
            Console.WriteLine(" s21_decimal result_C = {0}(original_decimal);", c_func);
			
			Decimal result_original = Decimal.Floor(original_dec);
            int[] bitsResult = decimal.GetBits(result_original);
			Console.WriteLine(" test(result_C, {0}, {1}, {2}, {3});\n", unchecked((uint)bitsResult[0]), unchecked((uint)bitsResult[1]), unchecked((uint)bitsResult[2]), unchecked((uint)bitsResult[3]));
			Console.WriteLine("// original_result(int32) = {0}, {1}, {2}, {3}));\n", bitsResult[0], bitsResult[1], bitsResult[2], bitsResult[3]);
			Console.WriteLine("// original_result = {0}",  result_original);
		}
		
        public static void Main(string[] args) {
		  Random randomValue = new Random();
			decimal dec1 = 0;
			
			for (int i = 1; i <= 100; i++)
			{
				dec1 = randomValue.NextDecimal();
				
				try
				{
					print_test(dec1, "s21_floor", i);
				}
				catch (System.OverflowException exc)
				{
					i--;
					//Console.WriteLine(exc);
				}
			}
        }
    }
}
