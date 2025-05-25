using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<ShapePallete> shapes;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateColor();
    }


    public void UpdateColor()
    {
        var selectedColor = Utility.GetColorFromIndex(Utility.ColorIndex);

        foreach (var shape in shapes)
        {
            shape.GetComponent<Image>().color = selectedColor;
        }
    }

    public void RemoveItem()
    {
        Debug.Log("Remove Item");
    }
    public void PlaceItem(Transform parent, Vector3 spawnPosition)
    {
        Debug.Log("Place Item");

        var shapeIndex = Utility.ShapeIndex;
        var colorIndex = Utility.ColorIndex;

        var selectedPrefab = shapes[shapeIndex];
        var selectedColor = Utility.GetColorFromIndex(colorIndex);

        var newShape = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, parent);
        var rectTransform = newShape.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(110, 110);
        }
        var shapeImage = newShape.GetComponent<Image>();
        if (shapeImage != null)
        {
            shapeImage.color = selectedColor;
        }
        else
        {
            var sr = newShape.GetComponent<Image>();
            if (sr != null)
                sr.color = selectedColor;
        }
    }


}
