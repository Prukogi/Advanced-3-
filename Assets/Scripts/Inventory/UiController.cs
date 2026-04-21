using Inventory;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory
{

	public class UiController : MonoBehaviour
	{
		#region Properties
		#endregion

		#region Fields
		[Header("UI Reffs")]
		[SerializeField] private ItemButtom _prefabButton;
		[SerializeField] private Transform _inventoryPanel;
		[SerializeField] private Button _useButton;
		[SerializeField] private Button _sellButton;

		[SerializeField] private InventorySystem _inventorySystem;

		[Header("Item Seleced")]
		[SerializeField] private ItemButtom _currentItemSelected;
		#endregion

		#region Unity Callbacks

		void Start()
		{
			InitializeUI();

			_useButton.onClick.AddListener(UseSelectedItem);
			_sellButton.onClick.AddListener(SellSelectedItem);
		}




		#endregion

		#region Public Methods

		public void AddItem(ItemButtom buttonItemToAdd)
		{
			ItemButtom newButtonItem = Instantiate(buttonItemToAdd, _inventoryPanel);
			newButtonItem.CurrentItem = buttonItemToAdd.CurrentItem;
			newButtonItem.OnClick += () => SelecItem(newButtonItem);
		}

		public void SelecItem(ItemButtom currentItem)
		{
			_currentItemSelected = currentItem;
			//If Sellable
			if (_currentItemSelected.CurrentItem is ISellable)
				_sellButton.gameObject.SetActive(true);
			else
				_sellButton.gameObject.SetActive(false);

			//If Usable
			if (_currentItemSelected.CurrentItem is IUsable)
				_useButton.gameObject.SetActive(true);
			else
				_useButton.gameObject.SetActive(false);
		}

		#endregion

		#region Private Methods
		private void InitializeUI()
		{
			for (int i = 0; i < _inventorySystem.Items.Count; i++)
			{
				ItemButtom newButton = Instantiate(_prefabButton, _prefabButton.transform.parent);
				newButton.CurrentItem = _inventorySystem.Items[i];
				newButton.OnClick += () => AddItem(newButton);
			}
			_prefabButton.gameObject.SetActive(false);
		}

		private void UseSelectedItem()
		{
			if (_currentItemSelected == null) return;

			bool shouldConsume = _inventorySystem.UseItem(_currentItemSelected.CurrentItem);

			if (shouldConsume)
				Consume(_currentItemSelected);
		}

		private void SellSelectedItem()
		{
			if (_currentItemSelected == null) return;

			_inventorySystem.SellItem(_currentItemSelected.CurrentItem);
			Consume(_currentItemSelected);
		}

		private void Consume(ItemButtom currentItemSelected)
		{
			if (currentItemSelected == null) return;

			Destroy(currentItemSelected.gameObject);

			if (currentItemSelected == _currentItemSelected)
				_currentItemSelected = null;

			_sellButton.gameObject.SetActive(false);
			_useButton.gameObject.SetActive(false);
		}

		#endregion

	}
}