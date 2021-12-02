using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuResolution : MonoBehaviour
{
    private static Text textComponent;
    private static Resolution[] resolutions;
    private static int resolutionIndex;
    void Awake()
    {
        resolutions = Screen.resolutions;
        resolutionIndex = 0;
        textComponent = GameObject.Find("VolumeMenu/Resolution").GetComponent<Text>();
        textComponent.text = ResToString(resolutions[resolutionIndex]);
       
    }

    public static void ShowNextResolution()
    {
        if (resolutionIndex < resolutions.Length - 1) 
        { 
            resolutionIndex++;
            textComponent.text = ResToString(resolutions[resolutionIndex]);
        }
        else 
            ShowFirstResolution();


    }

    public static void ShowPreviousResolution()
    {
        if (resolutionIndex > 0)
        {
            resolutionIndex--;
            textComponent.text = ResToString(resolutions[resolutionIndex]);
        }
        else 
            ShowLastResolution();

    }

    public static void ShowFirstResolution()
    {
        
        resolutionIndex = 0;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }

    public static void ShowLastResolution()
    {
        resolutionIndex = resolutions.Length - 1;
        textComponent.text = ResToString(resolutions[resolutionIndex]);
    }

    private static string ResToString(Resolution res)
    {
        return res.width + "x" + res.height + " " + res.refreshRate + "hz";
    }
 

}
