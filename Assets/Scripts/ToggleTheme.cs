using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTheme : MonoBehaviour
{
	[SerializeField] private OptionsMenu _optionsMenu;
	private Toggle _thisToggle;
	[SerializeField] private bool _isDarkTheme;

	public Events.EventThemeChanged OnThemeChange;

	private void Start()
	{
		_thisToggle = GetComponent<Toggle>();
		_thisToggle.onValueChanged.AddListener(HandleThemeSelection);

		//Bubble the event up 
		OnThemeChange.AddListener(_optionsMenu.BubbleThemeChange);
	}


	// Theme - true is dark.

	void HandleThemeSelection(bool theme)
	{

		if (_thisToggle.isOn)
		{
			if (_isDarkTheme)
			{
				// Enable Dark Theme
				OnThemeChange.Invoke(true);
			}
			else
			{
				// Enable Light Theme
				OnThemeChange.Invoke(false);
			}
		}

	}
}
