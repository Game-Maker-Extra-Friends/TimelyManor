using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class LoadOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    public InputActionAsset _input;

    // Load volume since volume option doesn't carry over scenes
    void Start()
    {
        Save save = Resources.Load<Save>("Saves/Save");
        Debug.Log(save.name);
        audioMixer.SetFloat("master_volume", save.masterVolume);
        audioMixer.SetFloat("sfx_volume", save.sfxVolume);
        audioMixer.SetFloat("music_volume", save.musicVolume);

        SetMouseSensivityFloat(save.mouseSensitivity);
    }

    public void SetMouseSensivity(InputAction action, string bindingPathStart, float sensivity)
    {
        var bindings = action.bindings;
        var scale = new Vector2(sensivity, sensivity);
        for (var i = 0; i < bindings.Count; i++)
        {
            if (bindings[i].isPartOfComposite || !bindings[i].path.StartsWith(bindingPathStart)) continue;
            //Override the binding of the playerinput and insert the new value (kinda dumb since you can't just change one thing)
            action.ApplyBindingOverride(i, new InputBinding { overrideProcessors = $"ScaleVector2(x={scale.x},y={scale.y}), InvertVector2(invertx=false,inverty=true)" });
            return;
        }
    }

    public void SetMouseSensivityFloat(float sensivity)
    {
        var action = _input.FindAction("Look");
        SetMouseSensivity(action, "<Pointer>", sensivity);
    }

}
