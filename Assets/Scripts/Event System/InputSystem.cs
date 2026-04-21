using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
	#region Properties
	public event Action OnKeyDamage;
	public event Action OnKeyHeal;
	public event Action OnKeyPoints;
	public event Action OnKeyAddLevel;

	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks




	void Update()
	{
		//Heal
		if (Input.GetKeyDown(KeyCode.H)) 
			OnKeyHeal?.Invoke();
		
			
		
		//Damage
		if (Input.GetKeyDown(KeyCode.D))
			OnKeyDamage?.Invoke();


		//Points
		if (Input.GetKeyDown(KeyCode.Space)) 
			OnKeyPoints?.Invoke();

		//Level Up
		if (Input.GetKeyDown(KeyCode.L)) 
			OnKeyAddLevel?.Invoke();

	}
	#endregion


}
