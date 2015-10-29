using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class EmptyVoid : BaseTrack
{
	public override char ToChar(bool rawChar)
	{
		return ' ';
	}
}