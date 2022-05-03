using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropDown;

    Resolution[] resolutions;

    public InputActionAsset _input;
    

    public void Start()
    {
        

        //set the array to screen resolutions
        resolutions = Screen.resolutions;

        //Clear the dropdown just in case
        resolutionDropDown.ClearOptions();

        //the option to display
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        //Format the list of string
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        //Add option and values + refresh the value so it's displayed to the player.
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    //Set volume for each type
    public void SetMasterVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("master_volume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("sfx_volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("music_volume", volume);
    }


    //Set the quality according to the quality option.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Fullscreen option
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //Set the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }

    //Set mouse sensitivity
    public void SetMouseSensivity(InputAction action, string bindingPathStart, float sensivity )
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

    //This is for the slider to use
    public void SetMouseSensivityFloat(float sensivity)
    {
        var action = _input.FindAction("Look");
        SetMouseSensivity(action, "<Pointer>", sensivity);
    }
}
