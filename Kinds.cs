using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋_v2
{
	class Kinds
	{
		public enum Kind { none, black, white};

		public Kind kind = Kind.none;

		public int number = 0;  // 编号

		// constructor function
		public Kinds(Kind kindin)
		{
			kind = kindin;
		}

		/// <summary>
		/// 把kind设为相反颜色
		/// </summary>
		public void setOppositeKind()
		{
			if (kind == Kind.white)
				kind = Kind.black;
			else if (kind == Kind.black)
				kind = Kind.white;
			else if (kind == Kind.none)
				return;
		}
	}
}
