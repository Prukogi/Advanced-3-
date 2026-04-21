using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Points _points;
	[SerializeField] private Health _playerHealth;
	[SerializeField] private UIController _ui;
	[SerializeField] private SoundController _sound;
	[SerializeField] private InputSystem _input;

	#endregion

	#region Unity Callbacks
	
	void Start()
    {
		//Event Listener
		_playerHealth.OnGetDamaged += OnGetDamage;
		_playerHealth.OnGetHeal += OnGetHeal;
		_playerHealth.OnDie += OnDie;
		_points.OnGetPoints += OnAddPoints;
		_points.OnLevelUp += OnAddLevel;

		//Input Listener
		_input.OnKeyHeal += () => _playerHealth.Heal(10);
		_input.OnKeyDamage += () => _playerHealth.GetDamaged(20);
		_input.OnKeyPoints += () => _points.AddPoints(100);
		_input.OnKeyAddLevel += () => _points.LevelUp(1);
	}

	



	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	private void OnGetDamage()
	{
		_sound.PlayDamageSound();
		_ui.UpdateSliderLife(_playerHealth.CurrentHealth);
	}

	private void OnGetHeal()
	{
		_ui.UpdateSliderLife(_playerHealth.CurrentHealth);
	}
	private void OnAddPoints()
	{
		_ui.UpdatePoints(_points.CurrentPoints);

	}

	private void OnAddLevel() 
	{
		
		_ui.UpdateLevel(_points.CurrentLevel);
	}
	private void OnDie()
	{
		_sound.PlayDieSound();
		Destroy(_playerHealth.gameObject);
	}



	#endregion

}
