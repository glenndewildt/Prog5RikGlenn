using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DivergingSwitch : Switch
{
	public bool IsUp = true;
	public BaseTrack Inactive { get; set; }

	public override bool Place(Minecart mc)
	{
		if (IsEmpty())
		{
			Content = mc;
			Previous.Content = null;
			return true;
		}

		return false;
	}

	public override Char ToChar(bool rawChar)
	{
		if (!rawChar && !IsEmpty())
			return Content.ToChar();

		if (IsUp)
			return '╝';

		return '╗';
	}

	public override void SwitchSwitch()
	{
		if (!IsEmpty())
			return;

		if (!IsUp)
			IsUp = true;
		else
			IsUp = false;

		BaseTrack tempTrack = Inactive;
		Inactive = Next;
		Next = tempTrack;
	}

}

