using UnityEngine;
using System;


namespace Inventory
{
	[Serializable]
	public class Other : Item, ISellable
	{
		#region Properties
		[field: SerializeField] public float Price { get; set; }
		#endregion

		#region Public Methods
		public float Sell()
		{
			Debug.Log("Has ganado " + Price + " dinero");
			return Price;
		}
		#endregion

	}
}









