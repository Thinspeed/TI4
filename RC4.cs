using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI4
{
    class RC4 : Coder
    {
		int[] table = new int[256];
		int key = 0;

		public RC4(int[] key)
		{
			for (int i = 0; i < table.Length; i++)
            {
				table[i] = i;
            }

			int j = 0;
			for (int i = 0; i < table.Length; i++)
			{
				j = (j + table[i] + key[i % key.Length]) % table.Length;
				int temp = table[j];
				table[j] = table[i];
				table[i] = temp;
			}
		}

		public string CodeMessage(string message)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
			{
				result.Append(CodeSymbol(message[i]));
			}

			key = 0;
			return result.ToString();
		}

		public char CodeSymbol(char symbol)
		{
			symbol = (char)(symbol ^ (char)table[key % table.Length]);
			key++;
			return symbol;
		}

		public override string ToString()
		{
			return "RC4";
		}
	}
}
