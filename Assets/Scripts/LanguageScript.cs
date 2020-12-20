using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageScript : MonoBehaviour
{
	[SerializeField] private UIManager _uiManager;
	[SerializeField] private DictonaryFile _dictonary;
	private TMP_Text _text;

	private void Awake()
	{
		_uiManager.OnLanguageChanged.AddListener(SelectLanguage);
	}

	private void Start()
	{
		_text = GetComponent<TMP_Text>();
	}

	void SelectLanguage(Language lang)
	{
		// Cast the lang to enum to int value
		// display the corresponding word from the dictionart file in the text.text area.
		int postion = (int)lang;
		_text.text = _dictonary.Word[postion];
	}
}
