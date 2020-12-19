using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

	[SerializeField] private Button _okButton;
	[SerializeField] private Button _cancelButton;

	[SerializeField] private Slider _fontSizeSlider;
	[SerializeField] private Slider _fontColourSlider;
	[SerializeField] private Image _sliderBackground; 

	private float _currentFontSize;
	private float _newFontSize;
	private float _currentcolour;
	private float _newColour;
	private bool _isDarkTheme; // Current theme
	private bool _newTheme;

	// Events

	public Events.EventFontSizeChanged OnFontSizeChange;
	public Events.EventFontColourchange OnFontColourChange;
	public Events.EventThemeChanged OnBubbleThemeChange;

	private void Start()
	{
		// When OptionsMenu is activated calls on UIManager to rebraodcast theme
		_uiManager.OnThemeChanged.Invoke(_isDarkTheme);
	}

	public void StartUp()
	{
		// PreSetup called from UIManager.
		_uiManager.OnOptionsMenuActivated.AddListener(ToggleState);
		_uiManager.OnThemeChanged.AddListener(InitalSetup); // Listens for inital setup of theme
		_okButton.onClick.AddListener(HandleOkClick);
		_cancelButton.onClick.AddListener(HandleCancelClick);

		_fontSizeSlider.onValueChanged.AddListener(HandleFontSizeRequest);
		_fontColourSlider.onValueChanged.AddListener(HandleFontColorSlider);	
	}

	void InitalSetup(bool status)
	{
		// Setup theme to inital Status as broadcast by UIManager
		_isDarkTheme = status;
		_uiManager.OnThemeChanged.RemoveListener(InitalSetup);
	}

	void HandleFontSizeRequest(float fontSize)
	{
		_newFontSize = fontSize;
	}

	void HandleFontColorSlider(float fontColour)
	{
		_newColour = fontColour;

		if (fontColour == 0)
		{
			_sliderBackground.color = Color.HSVToRGB(fontColour, 0f, 1f);
		}
		else
		{
			_sliderBackground.color = Color.HSVToRGB(fontColour, 1f, 1f);
		}
		Debug.Log("font color slider handled");
	}

	void HandleOkClick()
	{
		if (_currentFontSize != _newFontSize)
		{
			_currentFontSize = _newFontSize;
			OnFontSizeChange.Invoke(_newFontSize);
		}
		if (_currentcolour != _newColour)
		{
			_currentcolour = _newColour;
			OnFontColourChange.Invoke(_newColour);
		}
		if (_isDarkTheme != _newTheme)
		{
			_isDarkTheme = _newTheme;
			OnBubbleThemeChange.Invoke(_isDarkTheme);
		}
	}

	void HandleCancelClick()
	{
		_uiManager.OnOptionsMenuActivated.Invoke(false);
	}

	public void BubbleThemeChange(bool theme)
	{
		_newTheme = theme;
		Debug.Log("bubbling theme change up");
	}

	public void ToggleState(bool state)
	{
		Debug.Log("Toggling options menu : " + state);
		gameObject.SetActive(state);
	}
}
