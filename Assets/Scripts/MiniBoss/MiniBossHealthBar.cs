using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBossHealthBar : MonoBehaviour
{
	public Transform characterParent;

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

	private void LateUpdate()
	{
		GetComponent<RectTransform>().localScale = new Vector3(characterParent.right.x, 1, 1);
	}
}
