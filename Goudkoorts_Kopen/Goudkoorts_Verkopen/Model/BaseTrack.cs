using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseTrack
{
	public Minecart Content { get; set; }
	public BaseTrack Next {	get; set; }
	public BaseTrack Previous { get; set; }

	public bool IsEmpty()
	{
		if (Content == null)
			return true;

		return false;
	}

	public virtual bool Place(Minecart mc)
	{
		if (IsEmpty())
		{
			Content = mc;
			Previous.Content = null;
			return true;
		}

		throw new JeMoederException();
	}

	public virtual Char ToChar(bool rawChar)
	{
		if (!rawChar && !IsEmpty())
			return Content.ToChar();

		return '#';
	}

}

