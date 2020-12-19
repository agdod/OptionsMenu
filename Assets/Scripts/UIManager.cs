using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum MenuState
{
	MAIN,
	OPTIONS
}

public class UIManager : MonoBehaviour
{
	[SerializeField] private MainMenu _mainMenu;
	[SerializeField] private OptionsMenu _optionsMenu;
	private bool _currentState; // bool for if options menu is active or not
	private MenuState _menuState;

	// Use to determine start theme
	[SerializeField] private bool _isDarkTheme;
	private float _fontColor;
	private float _fontSize;

	// Events subscriptions

	public Events.EventToggleOptions OnOptionsMenuActivated;
	public Events.EventFontSizeChanged OnFontSizeChanged;
	public Events.EventFontColourchange OnFontColourChanged;
	public Events.EventThemeChanged OnThemeChanged;

	// Font selection 
	/*
	 * Collect font size - pass to game manger
	 * collect font color pass to game manger
	 * collect volume  pass to game manager
	 * collet language pass to game manger
	 */

	public bool IsDarkTheme
	{
		get { return _isDarkTheme; }
	}

	private void Start()
	{
		_optionsMenu.StartUp();

		_optionsMenu.OnFontSizeChange.AddListener(HandleFontSizeChange);
		_optionsMenu.OnFontColourChange.AddListener(HandleFontColourChange);
		_optionsMenu.OnBubbleThemeChange.AddListener(HandleThemeChange);

		DefaultSetup();

		OnOptionsMenuActivated.Invoke(false);
	}

	void DefaultSetup()
	{
		Debug.Log("Calling  inital handlethemechange");
		HandleThemeChange(_isDarkTheme);
		Debug.Log("Initail theme called!");
	}

	void HandleFontColourChange(float fontColour)
	{
		_fontColor = fontColour;
		OnFontColourChanged.Invoke(fontColour);
	}

	void HandleFontSizeChange(float fontSize)
	{
		_fontSize = fontSize;
		OnFontSizeChanged.Invoke(fontSize);
	}

	void HandleThemeChange(bool theme)
	{
		_isDarkTheme = theme;
		OnThemeChanged.Invoke(theme);
	}

	public void StartClick()
	{
		Debug.Log("Start buttone clicked");
		//SceneManager.LoadScene("EmptyScene");
	}

	public void ToggleOptionsMenu()
	{
		Debug.Log("optiosn buttone clciked");
		OnOptionsMenuActivated.Invoke(true);
	}

	public void QuitClick()
	{
		Debug.Log("Quit button clicked");
		Application.Quit();
	}
}
