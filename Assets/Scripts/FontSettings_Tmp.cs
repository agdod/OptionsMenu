using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Works with TextMeshPro */

public enum FontType
{
	HEADER,
	TEXT,
	SUB
}

public class FontSettings_Tmp : MonoBehaviour
{
	[SerializeField] private UIManager _uiManager;
	
	[SerializeField] private float _fontSize;
	[SerializeField] private float _fontColour = 0;
	[SerializeField] private FontType _fontType;
	//[SerializeField] private List<T> _fontLanaguage

	// Buttons have color and font size adjustment disabled

	[SerializeField] private bool _adjustSize;
	[SerializeField] private bool _adjustColor;
	[SerializeField] private bool _adjustLanguage;

	[SerializeField] private TMP_Text _fontText;

	// Scale various Texts (header, sub etc) based on regular text sized
	[SerializeField] private float _headerScaler = 1.15f;
	[SerializeField] private float _subScaler = 0.77f;

	// Add listener for  UIMAnager chnaging font size, font color, text language.
	// Register listenr with corresponding function (OnFontSizeChange ...etc)

	private void Start()
	{
		_fontText = GetComponent<TMP_Text>();		
		if ( _fontText == null)
		{
			Debug.LogError("No TextMeshPro Componet found.");
		}
		
		_uiManager.OnFontSizeChanged.AddListener(OnFontSizeChange);
		_uiManager.OnFontColourChanged.AddListener(OnFontColourChange);
		_uiManager.OnThemeChanged.AddListener(OnThemeChange);
		Debug.Log(this.gameObject + " FontSettings Listeners added");
	}

	void OnThemeChange(bool theme)
	{
		Debug.Log(this.gameObject + " theme is set to Dark ? " + theme);
		// Check if theme amd Font color are same 

		Color themeColor;

		// if Dark theme..
		if (theme && _fontColour == 0 || theme && !_adjustColor)
		{
			themeColor = Color.HSVToRGB(0, 0, 1);
			themeColor.a = 1;
			_fontText.color = themeColor;
		}
		// if Light Theme...
		else if (!theme && _fontColour == 0 || !theme && !_adjustColor)
		{
			themeColor = Color.HSVToRGB(0, 0, 0.2f);
			themeColor.a = 1;
			_fontText.color = themeColor;
		}
	}

	void OnFontSizeChange(float fontSize)
	{
		
		// Check can adjust font size, or if current font size is same as 'new' font size
		if (!_adjustSize || _fontSize == fontSize)
		{
			return;
		}

		switch (_fontType)
		{
			case FontType.HEADER:
				_fontText.fontSize = fontSize * _headerScaler;
				break;
			case FontType.TEXT:
				_fontText.fontSize = fontSize;
				_fontSize = fontSize;
				break;
			case FontType.SUB:
				_fontText.fontSize = fontSize * _subScaler;
				break;
			default:
				break;
		}
	}

	void OnFontColourChange(float fontColour)
	{
		Debug.Log("OnFontColorChange called " + fontColour);
		// Check can adjust color, or if current font color is same as 'new' font colour
		if (!_adjustColor || _fontColour == fontColour)
		{
			return;
		}

		Color newColor;

		if (fontColour == 0)
		{
			// Adjust font color according to theme
			// Get current theme from UIManager.
			bool theme = _uiManager.IsDarkTheme;
			_fontColour = fontColour;
			OnThemeChange(theme);

			//newColor = Color.HSVToRGB(fontColour, 0f, 1f);
			//newColor.a = 1;
			//_fontText.color = newColor;			
		} 
		else
		{
			newColor = Color.HSVToRGB(fontColour, 1f, 1f);
			newColor.a = 1;
			_fontText.color = newColor;
			_fontColour = fontColour;
		}
	}

	void OnLanguageChange()
	{
		if (!_adjustLanguage)
		{
			return;
		}
	}
}
