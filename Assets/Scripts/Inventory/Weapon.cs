using UnityEngine;
using System;

namespace Inventory
{
	[Serializable]
	public class Weapon : Item, IUsable
	{
		#region Properties
		[field: SerializeField] public float Damage { get; set; }

		#endregion

		


		#region Public Methods
		public void Attack()
		{
			Debug.Log("Do Attack...");
		}

		public void Use()
		{
			Attack();
		}

		#endregion

	

	}
}
