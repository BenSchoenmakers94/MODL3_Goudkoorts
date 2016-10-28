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

	public class IncomingSwitch : Switch
	{
	    public override bool CanMoveHere(MoveableObject moveable)
	    {
	        return moveable.Location.Equals(gateUp ? UpTrack : DownTrack);
	    }

	    public override void Accept(IVisitor visitor)
	    {
            if (this.MoveableObject != null)
            {
                this.MoveableObject.Accept(visitor);
            }
            else
            {
                visitor.Visit(this);
            } 
	    }
	}
}

