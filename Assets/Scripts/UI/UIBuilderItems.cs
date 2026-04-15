using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuilderItems : MonoBehaviour
{
    public Image img;
    public Image imgBought;

    public void TurnOn()
    {
        img.color = SetOpacity(1f);
        imgBought.enabled = true;
    }
    public void TurnOff()
    {
        img.color = SetOpacity(0.5f);
        imgBought.enabled = false;
    }
    public Color SetOpacity(float t)
    {
        Color color = img.color;
        color.a = t;
        return color;
    }
}
