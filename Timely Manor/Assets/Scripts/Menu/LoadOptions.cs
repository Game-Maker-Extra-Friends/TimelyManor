using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using StarterAssets;

public class LoadOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Load volume since volume option doesn't carry over scenes
    void Start()
    {
        Save save = Resources.Load<Save>("Saves/Save");
        Debug.Log(save.name);
        audioMixer.SetFloat("master_volume", save.masterVolume);
        audioMixer.SetFloat("sfx_volume", save.sfxVolume);
        audioMixer.SetFloat("music_volume", save.musicVolume);

        var action = FirstPersonController.instance.GetComponent<PlayerInput>().actions["Look"];

        var bindings = action.bindings;
        var sensivity = save.mouseSensitivity;
        var bindingPathStart = "<Pointer>";
        var scale = new Vector2(sensivity, sensivity);
        for (var i = 0; i < bindings.Count; i++)
        {
            if (bindings[i].isPartOfComposite || !bindings[i].path.StartsWith(bindingPathStart)) continue;
            //Override the binding of the playerinput and insert the new value (kinda dumb since you can't just change one thing)
            action.ApplyBindingOverride(i, new InputBinding { overrideProcessors = $"ScaleVector2(x={scale.x},y={scale.y}), InvertVector2(invertx=false,inverty=true)" });
            return;
        }
    }

}
