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

	public class Warehouse<Moveable> : IVisitable
		where Moveable : MoveableObject, new()
	{
		public Track Start
		{
			get;
			set;
		}

	    public Warehouse(Track startingTrack)
	    {
	        Start = startingTrack;
	    }

		public Moveable CreateNewMovableObject()
		{
           return new Moveable{Location = Start};
		}

	    public void Accept(IVisitor visitor)
	    {
	        visitor.Visit((dynamic) this);
	    }
	}
}

