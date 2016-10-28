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

	public class CartManager : CollectionManager
	{
		public List<Warehouse<Cart>> CartWarehouses
		{
			get;
			private set;
		}

		public List<Cart> Carts
		{
			get;
			private set;
		}

	    public bool CollisionDetected
	    {
	        get; set;
        }

	    public CartManager()
	    {
	        CollisionDetected = false;
	    }

		public override void MoveAllMoveableObjects()
		{
		    foreach (var cart in Carts)
            {
                cart.DoMove();
                if (cart.hasCollided)
                {
                    CollisionDetected = cart.hasCollided;
                    return;
                }
            }

		    foreach (var cartToRemove in Carts.Where(cart => cart.Location == null).ToList())
		    {
		        Carts.Remove(cartToRemove);
		    }
		}

		public override void CreateNewMoveableObjects()
		{
            var randomInteger = new Random().Next(1, (CartWarehouses.Count + 1));
            var counter = 1;
            foreach (var cartWarehouse in CartWarehouses)
            {
                if (counter == randomInteger)
                {
                    Carts.Add(cartWarehouse.CreateNewMovableObject());
                    break;
                }
                counter++;
            }
		}

	    public void InitManager(Warehouse<Cart>[] cartWarehouses )
	    {
            CartWarehouses = new List<Warehouse<Cart>>();
            Carts = new List<Cart>();

            for (var i = 0; i < cartWarehouses.Length; i++)
            {
                var newCartWarehouse = cartWarehouses[i];
                CartWarehouses.Add(newCartWarehouse);
            }
	    }
	}
}
