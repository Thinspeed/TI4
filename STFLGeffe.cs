using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI4
{
	class STFLGeffe : Coder
	{
		ulong key;

		public STFLGeffe(ulong key)
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
			ulong choice = (key << 1) + ((key >> 27) & 1) ^ ((key >> 2) & 1);
			ulong firstEnter = (key << 1) + ((key >> 35) & 1) ^ ((key >> 10) & 1);
			ulong secondEnter = (key << 1) + ((key >> 25) & 1) ^ ((key >> 7) & 1) ^ ((key >> 6) & 1) ^ (key & 1);
			key = (choice & firstEnter) | ((ulong)~choice & secondEnter);
			return symbol;
		}

        public override string ToString()
        {
            return "STFL Geffe";
        }
    }
}
