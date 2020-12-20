using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Utils/WordFile")]
public class DictonaryFile : ScriptableObject
{
    // Element 0 : English
    // Element 1 : Finnish
    [SerializeField] private string[] _word = new string[2];

    public string[] Word
	{
        get { return _word; }
	}
}
