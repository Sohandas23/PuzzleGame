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

}
