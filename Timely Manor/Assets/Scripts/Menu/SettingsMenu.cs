using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private Save save;

    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropDown;

    Resolution[] resolutions;

    public InputActionAsset _input;

    [SerializeField]
    private Toggle fullScreenToggle;

    [SerializeField]
    private Slider masterVolume;
    [SerializeField]
    private Slider sfxVolume;
    [SerializeField]
    private Slider musicVolume;

    [SerializeField]
    private Slider mouseSensitivity;

    [SerializeField]
    private TMP_Dropdown graphicQuality;
    //[SerializeField]
    //private TMP_Dropdown resolution;

    public void Start()
    {
        save = Resources.Load<Save>("Saves/Save");

        //set the array to screen resolutions
        resolutions = Screen.resolutions;

        //Clear the dropdown just in case
        resolutionDropDown.ClearOptions();

        //the option to display
        List<string> options = new List<string>();
        //Format the list of string
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                save.resolutionIndex = i;
            }
        }
        
        //Add option and values + refresh the value so it's displayed to the player.
        resolutionDropDown.AddOptions(options);

        resolutionDropDown.value = save.resolutionIndex;
        resolutionDropDown.RefreshShownValue();



        // Load option changes
        SetFullScreen(save.fullscreen);
        fullScreenToggle.isOn = save.fullscreen;

        // Audio Saves
        masterVolume.value = save.masterVolume;
        SetMasterVolume(save.masterVolume);

        sfxVolume.value = save.sfxVolume;
        SetSFXVolume(save.sfxVolume);

        musicVolume.value = save.musicVolume;
        SetMusicVolume(save.musicVolume);

        // Mouse Sensitivity
        mouseSensitivity.value = save.mouseSensitivity;
        SetMouseSensivityFloat(save.mouseSensitivity);

        // Graphic Options
        graphicQuality.value = save.graphicQuality;
        SetQuality(save.graphicQuality);
        

    }

    //Set volume for each type
    public void SetMasterVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("master_volume", volume);
        save.masterVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("sfx_volume", volume);
        save.sfxVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("music_volume", volume);
        save.musicVolume = volume;
    }


    //Set the quality according to the quality option.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        save.graphicQuality = qualityIndex;
    }

    //Fullscreen option
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        save.fullscreen = isFullscreen;
    }

    //Set the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        save.resolutionIndex = resolutionIndex;
        Debug.Log("res changed");
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
        Debug.Log("Mouse Sen changed");
        save.mouseSensitivity = sensivity;
    }
}
