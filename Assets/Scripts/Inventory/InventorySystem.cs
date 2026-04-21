using UnityEngine;
using System.Collections.Generic;


namespace Inventory
{
	public class InventorySystem : MonoBehaviour
	{
		#region Properties
		public List<Item> Items { get => _items;}


		#endregion

		#region Fields
		

		[Header("Object Definition")]
		[SerializeField] private Weapon[] _weapons;
		[SerializeField] private Food[] _foods;
		[SerializeField] private Other[] _others;
		[Header("Item Pool")]
		[SerializeField] private List<Item> _items = new List<Item>();
		
		#endregion

		#region Unity Callbacks
		
		void Awake()
		{
			InitializeItems();
		}
		#endregion

		#region Public Methods
		public void SellItem(Item item) 
		{
			if (item is ISellable sellable)
				sellable.Sell();
		}


		public bool UseItem(Item item)
		{
			

			if (item is IUsable usable)
			{
				usable.Use();
				return item is IConsumable;
			}
			return false;
		}
		#endregion

		#region Private Methods
		private void InitializeItems()
		{
			//Weapons
			for (int i = 0; i < _weapons.Length; i++)
				_items.Add(_weapons[i]);

			//Food
			for (int i = 0; i < _foods.Length; i++)
				_items.Add(_foods[i]);

			//Other
			for (int i = 0; i < _others.Length; i++)
				_items.Add(_others[i]);
		}
		#endregion
	}
}



