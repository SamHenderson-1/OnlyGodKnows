using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class OptionsMenuController : MonoBehaviour
{
    public Slider brightnessSlider;
    public TMP_Dropdown resolutionDropdown;
    public Image brightnessOverlay;
    public UnityEngine.Rendering.PostProcessing.PostProcessVolume postProcessVolume;

    private List<Resolution> resolutions;

    void Start()
    {
        resolutions = new List<Resolution>();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        HashSet<string> uniqueResolutions = new HashSet<string>();

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            Resolution resolution = Screen.resolutions[i];
            string option = resolution.width + "x" + resolution.height;

            // Only add the resolution to the list if it's unique
            if (uniqueResolutions.Add(option))
            {
                resolutions.Add(resolution);
                options.Add(option);

                if (resolution.width == Screen.currentResolution.width &&
                    resolution.height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = resolutions.Count - 1;
                }
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SetResolution(currentResolutionIndex);

        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        SetBrightness(brightnessSlider.value);
    }

    public void SetBrightness(float brightness)
    {
        PlayerPrefs.SetFloat("Brightness", brightness);
        UnityEngine.Rendering.PostProcessing.ColorGrading colorGrading;
        if (postProcessVolume.profile.TryGetSettings(out colorGrading))
        {
            colorGrading.postExposure.value = Mathf.Lerp(-2f, 2f, brightness);
        }
    }




    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
