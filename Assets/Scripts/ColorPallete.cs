using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorPallete : MonoBehaviour,IPointerClickHandler
{
    public Utility.Colors color;

    public void OnPointerClick(PointerEventData eventData)
    {
        SetColor(color);
    }

    private void SetColor(Utility.Colors newColor)
    {
        color = newColor;
        Utility.ColorIndex = (int)newColor;
        GameManager.Instance.UpdateColor();
    }
}
