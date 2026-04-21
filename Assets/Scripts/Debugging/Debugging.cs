using UnityEngine;
using System;

public class Debugging : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields

	[Header("Gizmo Line")]
	[SerializeField] private Vector3 _initialGizmoLine;
	[SerializeField] private Vector3 _finalGizmoLine;
	[Header("Vision Area")]
	private int _cont = 0;
	[SerializeField]private float _visionLength = 10;
	[Header("Detection Area")]
	[SerializeField] private float _visionArea = 10;
	[SerializeField] private float _audioArea = 30;

	#endregion

	#region Unity Callbacks

	void Start()
    {
		Debug.Log("Mensaje");
		Debug.LogWarning("Mensaje tipo warning!!");
		Debug.LogError("Mensaje tipo Error!!");
    }

	

    
    void Update()
    {
		_cont++;
		if (_cont % 100 == 0)
		{
			Debug.Log("Cantidad: " + _cont);
		}
	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion

	#region Gizmos
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawLine(_initialGizmoLine, _finalGizmoLine);
		Gizmos.DrawWireSphere(Vector3.zero, _visionArea);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Vector3.zero, _visionLength *  (Vector3.forward + Vector3.right));
		Gizmos.DrawLine(Vector3.zero, _visionLength * (Vector3.forward + Vector3.left));
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(Vector3.zero, _audioArea);
	}


	#endregion

}
