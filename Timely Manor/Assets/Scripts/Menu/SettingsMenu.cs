using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
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

        if (ES3.KeyExists("Resolution", "Options/GraphicOptions.es3"))
        {
            currentResolutionIndex = ES3.Load<int>("Resolution", "Options/GraphicOptions.es3");
        }

        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();



        // Load option changes
        if (ES3.KeyExists("FullScreen", "Options/GraphicOptions.es3"))
        {
            bool fs = ES3.Load<bool>("FullScreen", "Options/GraphicOptions.es3");
            SetFullScreen(fs);
            fullScreenToggle.isOn = fs;
        }

        // Audio Saves
        if (ES3.KeyExists("MasterVolume", "Options/AudioOptions.es3"))
        {
            float volume = ES3.Load<float>("MasterVolume", "Options/AudioOptions.es3");
            masterVolume.value = volume;
            SetMasterVolume(volume);
        }
        if (ES3.KeyExists("SFXVolume", "Options/AudioOptions.es3"))
        {
            float volume = ES3.Load<float>("SFXVolume", "Options/AudioOptions.es3");
            sfxVolume.value = volume;
            SetSFXVolume(volume);
        }
        if (ES3.KeyExists("MusicVolume", "Options/AudioOptions.es3"))
        {
            float volume = ES3.Load<float>("MusicVolume", "Options/AudioOptions.es3");
            musicVolume.value = volume;
            SetMusicVolume(volume);
        }

        // Mouse Sen
        if (ES3.KeyExists("Sensitivity", "Options/ControlOptions.es3"))
        {
            float sen = ES3.Load<float>("Sensitivity", "Options/ControlOptions.es3");
            mouseSensitivity.value = sen;
            SetMouseSensivityFloat(sen);
        }

        // Graphic Options
        if (ES3.KeyExists("GraphicQuality", "Options/GraphicOptions.es3"))
        {
            int qualityIndex = ES3.Load<int>("GraphicQuality", "Options/GraphicOptions.es3");
            graphicQuality.value = qualityIndex;
            SetQuality(qualityIndex);
        }
        

    }

    //Set volume for each type
    public void SetMasterVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("master_volume", volume);
        ES3.Save("MasterVolume", volume, "Options/AudioOptions.es3");
    }

    public void SetSFXVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("sfx_volume", volume);
        ES3.Save("SFXVolume", volume, "Options/AudioOptions.es3");
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("music_volume", volume);
        ES3.Save("MusicVolume", volume, "Options/AudioOptions.es3");
    }


    //Set the quality according to the quality option.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        ES3.Save("GraphicQuality", qualityIndex, "Options/GraphicOptions.es3");
    }

    //Fullscreen option
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        ES3.Save("FullScreen", isFullscreen, "Options/GraphicOptions.es3");
    }

    //Set the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        ES3.Save("Resolution", resolutionIndex, "Options/GraphicOptions.es3");
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
        ES3.Save("Sensitivity", sensivity, "Options/ControlOptions.es3");
    }
}
