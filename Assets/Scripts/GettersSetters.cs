using UnityEngine;
using System;

public class GettersSetters : MonoBehaviour
{
	#region Properties
	public int Points { get; set; }
	public int LevelPoints
	{
		get
		{
			return _levelPoints;
		}
	}
	//Delegate shortcut
	//public int LevelPoints => _levelPoints;
	#endregion

	#region Fields
	[SerializeField] private int _levelPoints = 1000;
	#endregion

	#region Unity Callbacks

	void Start()
    {
        
    }

    
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion
   
}
