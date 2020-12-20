using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private UIManager _uiManager;

	[SerializeField] private Button _startButton;
	[SerializeField] private Button _optionsButton;
	[SerializeField] private Button _quitButton;

	private void Start()
	{
		_startButton.onClick.AddListener(HandleStartClicked);
		_optionsButton.onClick.AddListener(HandleOptionsClicked);
		_quitButton.onClick.AddListener(HandleQuitClicked);

		_uiManager.OnOptionsMenuActivated.AddListener(ToggleState);
	}

	void HandleStartClicked()
	{
		_uiManager.StartClick();
	}

	void HandleOptionsClicked()
	{
		_uiManager.ToggleOptionsMenu();
	}

	void HandleQuitClicked()
	{
		_uiManager.QuitClick();
	}

	void ToggleState(bool state)
	{
		gameObject.SetActive(!state);
	}
}
