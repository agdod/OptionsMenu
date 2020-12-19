
using UnityEngine.Events;

public class Events
{
    [System.Serializable]
    public class EventToggleOptions : UnityEvent<bool> { } // True if OptionsMenu is active
    [System.Serializable]
    public class EventFontSizeChanged : UnityEvent<float> { } // Font size is whole number float 
    [System.Serializable]
    public class EventFontColourchange : UnityEvent<float> { }// Font colour represnted as (HSV) float value 0 - 1.
    [System.Serializable]
    public class EventThemeChanged : UnityEvent<bool> { } // Theme is represetned by bool where Dark Theme is true.
}
    
