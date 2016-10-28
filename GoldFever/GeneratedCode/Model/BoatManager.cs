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

	public class BoatManager : CollectionManager
	{

	    public Warehouse<Boat> BoatWarehouse
		{
			get;
			private set;
		}

		public List<Boat> Boats
		{
			get;
			private set;
		}

	    public int GameScore
	    {
	        get; 
            private set;
        }

		public override void MoveAllMoveableObjects()
		{
		    GameScore = 0;
            foreach (var boat in Boats)
            {
                boat.DoMove();
                GameScore = GameScore + boat.cargoLoad;
                if (boat.Location == null)
                {
                    GameScore = GameScore + 10;
                }
            }
		}

		public override void CreateNewMoveableObjects()
		{
		    if (Boats.Count == 0)
		    {
                var receivedBoat = BoatWarehouse.CreateNewMovableObject();
                Boats.Add(receivedBoat);
		    }
		    else
		    {
              foreach (var boat in Boats)
              {
                  if (!boat.isFull) return;
              }
               var receivedBoat = BoatWarehouse.CreateNewMovableObject();
               Boats.Add(receivedBoat);    
		    }	         
		}

	    public void InitManager(Warehouse<Boat> warehouse )
	    {
	        BoatWarehouse = warehouse;
            Boats  = new List<Boat>();
	    }
	}
}
