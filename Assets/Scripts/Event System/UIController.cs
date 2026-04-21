using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{


	#region Fields
	[SerializeField] private Slider _slider;
	[SerializeField] private TextMeshProUGUI _pointsText;
	[SerializeField] private TextMeshProUGUI _levelText;
	#endregion



	#region Public Methods
	public void UpdateSliderLife(float currentLife) 
	{
		_slider.value = currentLife;
	}
	public void UpdatePoints(int currentPoints)
	{
		_pointsText.text = currentPoints.ToString();
	}
	public void UpdateLevel(int currentLevel) 
	{
		_levelText.text = currentLevel.ToString();
	}

	#endregion



}
