using UnityEngine;
using System;

public class Health : MonoBehaviour
{    
    #region Properties
	public float CurrentHealth
	{
		get
		{
			return _currentHealth;
		}
		set
		{
			_currentHealth = value;
			if (value < 0) 
			{ 
				_currentHealth = 0;
				Die();
			}

			if (value > _maxHealth)
				_currentHealth = _maxHealth;
		}
	}

	public event Action OnGetDamaged;
	public event Action OnGetHeal; 
	public event Action OnDie;


	#endregion

	#region Fields
	private float _currentHealth;
	[SerializeField] private float _maxHealth = 100;
	private bool _die = false;


	#endregion

	#region Unity Callbacks

	void Start()
    {
		CurrentHealth = _maxHealth;
    }

		

    
 //   void Update()
 //   {
	//	if (Input.GetKeyUp(KeyCode.Return)) 
	//		GetDamaged(20);

	//	if (Input.GetKeyUp(KeyCode.Space))
	//		Heal(50);
	//}
	#endregion

	#region Public Methods
	public void GetDamaged(float damage) 
	{
		if (!_die) 
		{ 
			CurrentHealth -= damage;

		//Damage Event Emiter
		OnGetDamaged?.Invoke();
		}
	}
	public void Heal(float life) 
	{
		if (!_die) 
		{ 
		CurrentHealth += life;
		//Heal Event Emiter
		OnGetHeal.Invoke();
		}
	}
	#endregion

	#region Private Methods

	private void Die() 
	{
		if (!_die)
		{
			_die = true;
		}
		//Die Event Emiter
		OnDie?.Invoke();
	}
	#endregion
   
}
