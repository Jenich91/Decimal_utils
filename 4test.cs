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
		
        public static void print_test(decimal original_dec, string c_func, int num)
        {
			float result_original = Decimal.ToSingle(original_dec);
			int[] bits1 = decimal.GetBits(original_dec);
			
			Console.WriteLine("#test s21_{0}_{1}", c_func, num);
			Console.WriteLine("// original_decimal = {0}", original_dec);
			
			Console.WriteLine(" s21_decimal decimal_C = {{{{{0}, {1}, {2}, {3}}}, 0}};", unchecked((uint)bits1[0]), unchecked((uint)bits1[1]), unchecked((uint)bits1[2]), unchecked((uint)bits1[3]));
            Console.WriteLine(" float result_C = 0; \n {0}(decimal_C, &result_C);", c_func);
			
			Console.WriteLine(" ck_assert_float_eq(result_C, {0});\n", result_original);
		}
		
        public static void Main(string[] args)
        {
		Random randomValue = new Random();
			decimal dec1 = 0;
			
			for (int i = 1; i <= 100; i++)
			{
				dec1 = randomValue.NextDecimal();
				
				try
				{
					print_test(dec1, "s21_from_decimal_to_float", i);
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
