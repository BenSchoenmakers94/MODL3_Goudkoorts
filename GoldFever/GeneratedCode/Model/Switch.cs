﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public abstract class Switch : Track
	{
		public bool gateUp
		{
			get;
			set;
		}

		public virtual Track DownTrack
		{
			get;
			set;
		}

		public virtual Track UpTrack
		{
			get;
			set;
		}
        public string Number { get; set; }

	    public void switchGate()
	    {
	        gateUp = !gateUp;
	    }

	}
}
