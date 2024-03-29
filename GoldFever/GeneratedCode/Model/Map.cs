﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using GoldFever.GeneratedCode.Model;

namespace Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Map
	{
	    private List<NoCollisionTrack> noCollisionTracks;
	    private List<Track> boatRoute;
	    private int x;
	    private int y;

        public IVisitable[,] Objects
        {
            get;
            private set;
        }
	   	  
		public List<Warehouse<Cart>> CartWarehouses
		{
			get;
			private set;
		}

        public Warehouse<Boat> BoatWarehouse
        {
            get;
            private set;
        }

		public List<Switch> Switch
		{
			get;
			private set;
		}

	    public Dock Dock
	    {
	        get; 
            private set;
        }

	    public Map()
	    {
	        Objects = new IVisitable[9,12];
	    }

	    private void InitWarehouses()
	    {
            //Initialise properties
            CartWarehouses = new List<Warehouse<Cart>>();

            //Creating starting tracks for warehouses
            var boatStart = new Track();
            var cartAStart = new Track();
            var cartBStart = new Track();
            var cartCStart = new Track();

            //Add tracks to corresponding warehouses
            BoatWarehouse = new Warehouse<Boat>(boatStart);
            CartWarehouses.Add(new Warehouse<Cart>(cartAStart));
            CartWarehouses.Add(new Warehouse<Cart>(cartBStart));
            CartWarehouses.Add(new Warehouse<Cart>(cartCStart));

            //Map warehouses to Objects array to use in presentation layer
	        Objects[0, 0] = BoatWarehouse;
            Objects[3, 0] = CartWarehouses.First();
            Objects[5, 0] = CartWarehouses[1];
            Objects[7, 0] = CartWarehouses[2];
	    }

	    private void InitNoCollisionTracks()
	    {
	        x = 8;
	        y = 8;
            
            noCollisionTracks = new List<NoCollisionTrack>();
            var trackToAdd = new NoCollisionTrack();

            noCollisionTracks.Add(trackToAdd);
	        Objects[y, x] = trackToAdd;

	        for (int i = 0; i < 7; i++)
	        {
	            x--;

                trackToAdd = new NoCollisionTrack();
	            noCollisionTracks[i].Next = trackToAdd;

                noCollisionTracks.Add(trackToAdd);
	            Objects[y, x] = trackToAdd;
	        }
	    }

        private void InitBoatRoute(Track dockTrack)
        {
            x = 1;
            y = 0;

            boatRoute = new List<Track>();
            var trackToAdd = BoatWarehouse.Start;
            Objects[y, x] = trackToAdd;
            boatRoute.Add(trackToAdd);

            for (int i = 0; i < 10; i++)
            {
                x++;
                if (i == 7)
                {
                    var dockToAdd = new Dock();
                    dockToAdd.Docktrack = dockTrack;
                    boatRoute[i].Next = dockToAdd;

                    boatRoute.Add(dockToAdd);
                    Dock = dockToAdd;
                    Objects[y, x] = dockToAdd;
                }
                else
                {
                    trackToAdd = new Track();
                    boatRoute[i].Next = trackToAdd;

                    boatRoute.Add(trackToAdd);
                    Objects[y, x] = trackToAdd;
                }

            }
        }
        private void InitSwitches()
        {
            Switch = new List<Switch>();
            Switch.Add(new IncomingSwitch { Number = "1" });
            Switch.Add(new OutgoingSwitch { Number = "2" });
            Switch.Add(new IncomingSwitch { Number = "3" });
            Switch.Add(new IncomingSwitch { Number = "4" });
            Switch.Add(new OutgoingSwitch { Number = "5" });

            Objects[4, 3] = Switch[0];
            Objects[4, 5] = Switch[1];
            Objects[4, 9] = Switch[2];
            Objects[6, 6] = Switch[3];
            Objects[6, 8] = Switch[4];
        }

	    private Track LinkTracksTo(Track trackToLinkTo, int NrOfConsecutiveTracksToAdd)
	    {
	        var previousTrack = trackToLinkTo;
	        Track trackToLink;
            for (int i = 0; i < NrOfConsecutiveTracksToAdd; i++)
	        {
	            trackToLink = new Track();
	            previousTrack.Next = trackToLink;
	            previousTrack = previousTrack.Next;
	        }
	        return previousTrack;
	    }

	    private void LinkTracksToIncomingSwitch(Track upTrack, Track downTrack, Switch switchToLinkTo)
	    {
	        switchToLinkTo.UpTrack = upTrack;
	        switchToLinkTo.DownTrack = downTrack;

	        upTrack.Next = switchToLinkTo;
	        downTrack.Next = switchToLinkTo;

	        switchToLinkTo.Next = new Track();
	    }

        private void LinkTrackToOutgoingSwitch(Track trackToLink, Switch switchToLinkTo)
        {
            trackToLink.Next = switchToLinkTo;

            switchToLinkTo.UpTrack = new Track();
            
            switchToLinkTo.DownTrack = new Track();
        }

	    private void mapToObjects(int y, int x, int nrOfObjectsToMap, Track startingTrackToMap, string direction)
	    {
	        this.x = x;
	        this.y = y;

	        for (int i = 0; i < nrOfObjectsToMap; i++)
	        {
	            if (this.x == 11)
	            {
                    if (this.y == 2 || this.y == 3) startingTrackToMap.IsVertical = true;
                    if (this.y == 1 || this.y == 4 || this.y == 7 || this.y == 8) startingTrackToMap.IsCorner = true;
	            }


	            Objects[this.y, this.x] = startingTrackToMap;
                if (startingTrackToMap != null) startingTrackToMap = startingTrackToMap.Next;
	         

                switch (direction)
                {
                    case "east":
                        this.x++;
                        break;
                    case "west":
                        this.x--;
                        break;
                    case "north":
                        this.y--;
                        break;
                    case "south":
                        this.y++;
                        break;                  
                }
	        }
	    }

	    private void MapTracks()
	    {
            //set warehouse starting tracks as variables
	        var oldATrack = CartWarehouses[0].Start;
	        var oldBTrack = CartWarehouses[1].Start;
	        var oldCTrack = CartWarehouses[2].Start;

            //From warehouse starting tracks, add multiple normal tracks
            var currentATrack = LinkTracksTo(oldATrack, 2);
            var currentBTrack = LinkTracksTo(oldBTrack, 2);
            var currentCTrack = LinkTracksTo(oldCTrack, 5);
            //MAP TO OBJECTS ARRAY
            mapToObjects(3, 1, 3, oldATrack, "east");
            mapToObjects(5, 1, 3, oldBTrack, "east");
            mapToObjects(7, 1, 6, oldCTrack, "east");

            //renew old variables as current
	        oldATrack = currentATrack;
            oldBTrack = currentBTrack;
            oldCTrack = currentCTrack;


            //Link paths A & B to the 1st merging switch
            LinkTracksToIncomingSwitch(currentATrack, currentBTrack, Switch[0]);
            currentATrack = Switch[0].Next;
            currentBTrack = currentATrack;
            //MAP NEXT TRACK TO OBJECTS
            mapToObjects(4, 4, 1, currentATrack, "east");


            //Separate AB, set A as upper and B as lower track
            LinkTrackToOutgoingSwitch(currentATrack, Switch[1]);
            currentATrack = Switch[1].UpTrack;
            currentBTrack = Switch[1].DownTrack;

            //renew old variables as current
            oldATrack = currentATrack;
            oldBTrack = currentBTrack;

            //Add 5 normal tracks to path A
            currentATrack = LinkTracksTo(currentATrack, 4);
            //MAP TO OBJECTS ARRAY
            mapToObjects(3, 5, 5, oldATrack, "east");

            //Add 1 normal track to path B
            currentBTrack = LinkTracksTo(currentBTrack, 1);
            //MAP TO OBJECTS ARRAY
            mapToObjects(5, 5, 2, oldBTrack, "east");


            //Link paths B & C to the 4th switch
            LinkTracksToIncomingSwitch(currentBTrack, currentCTrack, Switch[3]);
            currentBTrack = Switch[3].Next;
            currentCTrack = currentBTrack;
            //MAP 4RD SWITCH AND NEXT TRACK AND 5TH SWITCH TO OBJECTS
            mapToObjects(6, 7, 1, currentBTrack, "east");


            //Separate BC, set B as upper and C as lower
            LinkTrackToOutgoingSwitch(currentBTrack, Switch[4]);
            currentBTrack = Switch[4].UpTrack;
            currentCTrack = Switch[4].DownTrack;

            //Add 1 normal track to path B
            oldBTrack = LinkTracksTo(currentBTrack, 1);

            //renew old variables as current
	        oldCTrack = currentCTrack;
            //MAP TO OBJECTS ARRAY
            mapToObjects(5, 8, 2, currentBTrack, "east");

            //Merge AB in 2nd merging switch
            LinkTracksToIncomingSwitch(currentATrack, oldBTrack, Switch[2]);
            currentATrack = Switch[2].Next;
            currentBTrack = currentATrack;
            //MAP 3RD SWITCH AND NEXT TRACK 
	        oldATrack = currentATrack;

            //Add 6 normal tracks to path AB, create a dockTrack and initialise the BoatRoute creator
            currentATrack = LinkTracksTo(currentATrack, 6);
            InitBoatRoute(currentATrack);
            //MAP TO OBJECTS ARRAY
            mapToObjects(4, 10, 2, oldATrack, "east");
            oldATrack = oldATrack.Next.Next;
            mapToObjects(3, 11, 2, oldATrack, "north");
	        

            //End path AB by adding 9 more normal tracks
            currentATrack = LinkTracksTo(currentATrack, 9);
            //MAP TO OBJECTS ARRAY
            currentBTrack = currentBTrack.Next.Next.Next.Next;
            mapToObjects(1, 11, 11, currentBTrack, "west");

            //End path C by adding 6 normal tracks and links the last track to the noCollision tracks
            currentCTrack = LinkTracksTo(currentCTrack, 6);
            currentCTrack.Next = noCollisionTracks[0];
            //MAP TO OBJECTS ARRAY
            mapToObjects(7, 8, 4, oldCTrack, "east");
	        oldCTrack = oldCTrack.Next.Next.Next;
            mapToObjects(7, 11, 2, oldCTrack, "south");
	        oldCTrack = oldCTrack.Next.Next;
            mapToObjects(8, 10, 2, oldCTrack, "west");
	    }

		public void GenerateMap()
		{
            InitWarehouses();
            InitNoCollisionTracks();
            InitSwitches();
            MapTracks();
		}

	}
}

