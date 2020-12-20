using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLanguage : MonoBehaviour
{
    [SerializeField] private OptionsMenu _optionsMenu;
    private Toggle _thisToggle;
    [SerializeField] private Language _language;

    public Events.EventLanguageChanged OnLanguageChange;

	private void Start()
	{
		_thisToggle = GetComponent<Toggle>();
		_thisToggle.onValueChanged.AddListener(HandleLanguageChange);

		//Bubble up the event
		OnLanguageChange.AddListener(_optionsMenu.BubbleLanguageChange);
	}

	void HandleLanguageChange(bool changed)
	{
		if (_thisToggle.isOn)
		{
			OnLanguageChange.Invoke(_language);
		}
	}
}
