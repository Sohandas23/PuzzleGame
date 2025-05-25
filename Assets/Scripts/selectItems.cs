using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectItems : MonoBehaviour, IPointerClickHandler
{
    public Utility.Shapes shape;
    public Utility.Colors color;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelectItems();
    }

    private void OnSelectItems()
    {
        Debug.Log($"utility shape index: {Utility.ShapeIndex} and color index: {Utility.ColorIndex}");
        if ((int)shape == Utility.ShapeIndex && (int)color == Utility.ColorIndex)
        {
            GameManager.Instance.PlaceItem(transform,transform.position);
        }
        else
        {
            GameManager.Instance.RemoveItem();
        }
    }
}