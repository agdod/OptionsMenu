using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeControl : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private AudioSource _audioSource;
    private Slider _slider;
    private float _volume;

	void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(HandleValueChanged);
    }

    void HandleValueChanged(float value)
	{
        _volume = value;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
        _audioSource.volume = 0.5f * _volume;
        _audioSource.Play();
    }
}
