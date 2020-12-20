using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivateTheme : MonoBehaviour
{
	// Listener for onthemechanged event
	// adjsut backgroud to represent corresponding theme

	public enum Zone
	{
		MAIN,
		SUB,
	}
	[SerializeField] UIManager _uiManager;
	[SerializeField] private Zone _zone;
	[SerializeField] private Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();
		if (_image == null)
		{
			Debug.LogError("No image componet found.");
		}

		_uiManager.OnThemeChanged.AddListener(ChangeTheme);
		Debug.Log(this.gameObject + " Listener added for image background via awake callback");
	}

	// *** If theme is true then theme is Dark *** //

	void ChangeTheme(bool theme)
	{
		Debug.Log(this.gameObject + " of type " + _zone + " Is Dark theme " + theme);
		switch (_zone)
		{
			case Zone.MAIN:
				ChangeThemeMainBackground(theme);
				break;
			case Zone.SUB:
				ChangeThemeSubBackground(theme);
				break;
			default:
				break;
		}
	}

	void ChangeThemeMainBackground(bool theme)
	{
		Color themeColor;
		if (theme)
		{
			themeColor = Color.HSVToRGB(0, 0, 0.35f);
		}
		else
		{
			themeColor = Color.HSVToRGB(0, 0, 1);
		}

		themeColor.a = 1;
		if (_image != null)
		{
			_image.color = themeColor;
		}

	}

	void ChangeThemeSubBackground(bool theme)
	{
		Color themeColor;
		if (theme)
		{
			themeColor = Color.HSVToRGB(0, 0, 0.2f);
			themeColor.a = 1;
		}
		else
		{
			themeColor = Color.HSVToRGB(0, 0, 0.8f);
			themeColor.a = 0.65f;
		}
		if (_image != null)
		{
			_image.color = themeColor;
		}
	}
}
