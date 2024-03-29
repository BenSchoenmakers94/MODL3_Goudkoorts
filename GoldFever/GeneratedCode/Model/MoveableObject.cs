﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GoldFever.GeneratedCode.Model;

namespace Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public abstract class MoveableObject : IVisitable
	{
	    private Track _location;

	    public bool isFull
		{
			get;
			set;
		}

	    public Track Location
	    {
	        get { return _location; }
	        set
	        {
	            _location = value;
                if (_location != null) _location.MoveableObject = this;
	        }
	    }

	    public abstract void DoMove();

		public abstract void DistributeCargo();

	    public abstract void Accept(IVisitor visitor);
	}
}

