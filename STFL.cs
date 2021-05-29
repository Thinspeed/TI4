using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI4
{
	class STFL : Coder
	{
		ulong key;

		public STFL(ulong key)
        {
			this.key = key;
        }

		public string CodeMessage(string message)
        {
			StringBuilder result = new StringBuilder();
			ulong temp = key;
			for (int i = 0; i < message.Length; i++)
            {
				result.Append(CodeSymbol(message[i]));
            }

			key = temp;
			return result.ToString();
        }

		public char CodeSymbol(char symbol)
        {
			symbol = (char)(symbol ^ (char)key);
			key = (key << 1) + ((key >> 27) & 1) ^ ((key >> 2) & 1);
			return symbol;
        }

		public override string ToString()
		{
			return "STFL";
		}
	}
}
