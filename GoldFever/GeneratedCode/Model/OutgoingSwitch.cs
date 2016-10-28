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

	public class OutgoingSwitch : Switch
	{
	    private Track _downTrack;
	    private Track _upTrack;

        public override Track DownTrack
        {
            get { return _downTrack; }
            set
            {
                if ((_downTrack = value) != null) _downTrack.Previous = this;
            }
        }

        public override Track UpTrack
        {
            get { return _upTrack; }
            set { if ((_upTrack = value) != null) _upTrack.Previous = this; }
        }

	    public override Track Next
        {
            get
            {
                return this.gateUp ? this.UpTrack : this.DownTrack;
            }
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
