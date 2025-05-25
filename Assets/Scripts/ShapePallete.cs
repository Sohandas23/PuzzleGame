using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShapePallete : MonoBehaviour,IPointerClickHandler
{
    public Utility.Shapes shape;

    public void OnPointerClick(PointerEventData eventData)
    {
        SetShape(shape);
    }
    private void SetShape(Utility.Shapes newShape)
    {
        shape = newShape;
        Utility.ShapeIndex = (int)newShape;
    }
}
