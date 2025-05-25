using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShapePallete : MonoBehaviour,IPointerClickHandler
{
    public Utility.Shapes shape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
