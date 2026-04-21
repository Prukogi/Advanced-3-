using UnityEngine;
using System;

public class Points : MonoBehaviour
{    
    #region Properties
	public int CurrentPoints { get; set; }
	public int CurrentLevel { get; set; }


	public event Action OnGetPoints;
	public event Action OnLevelUp;
	#endregion

	

	#region Unity Callbacks

	void Start()
    {
		CurrentLevel = 0;
		CurrentPoints = 0;
    }
	#endregion

	//private void Update()
	//{
	//	if (Input.GetKeyUp(KeyCode.Escape))
	//		AddPoints(200);
	//}


	#region Public Methods
	public void AddPoints(int pointsToAdd) 
	{
		CurrentPoints += pointsToAdd;
		OnGetPoints?.Invoke();
	}

	public void LevelUp(int levelToAdd) 
	{
		CurrentLevel += levelToAdd;
		OnLevelUp?.Invoke();
	}
		

	#endregion

	#region Private Methods
	#endregion
   
}
