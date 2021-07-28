using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class ColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;

    public Player myPlayer;

    public void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    void Start()
    {
        uiImage.color = color;

    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
}