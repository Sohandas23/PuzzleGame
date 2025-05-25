using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<ShapePallete> shapes;
    public int indexForGameOver = 0;
    public GameObject gameOverPanel;

    public event Action OnGameOver;

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
    public void RestartGame()
    {
         var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // for Editor only
#endif
    }

   

    private void HandleGameOver()
    {
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over Panel Activated");
    }

    private void OnDestroy()
    {
        OnGameOver -= HandleGameOver;
    }

    public void IncreaseIndex()
    {
        indexForGameOver++;

        if (indexForGameOver < 17) return;
        Debug.Log("Game Over Triggered");
        OnGameOver?.Invoke();
    }

    private void Start()
    {
        UpdateColor();
        OnGameOver += HandleGameOver;
    }


    public void UpdateColor()
    {
        var selectedColor = Utility.GetColorFromIndex(Utility.ColorIndex);

        foreach (var shape in shapes)
        {
            shape.GetComponent<Image>().color = selectedColor;
        }
    }

    public void RemoveItem(Transform parent, Vector3 spawnPosition)
    {
        Debug.Log("Remove Item");

        var shapeIndex = Utility.ShapeIndex;
        var colorIndex = Utility.ColorIndex;

        var selectedPrefab = shapes[shapeIndex];
        var selectedColor = Utility.GetColorFromIndex(colorIndex);

        var newShape = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, parent.parent);
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
        var jumpHeight = 20f;
        var fallDistance = 1000f; 
        var jumpUpDuration = 0.5f;
        var fallDownDuration = 1.2f;

        var seq = DOTween.Sequence();
        seq.Append(rectTransform.DOLocalMoveY(rectTransform.localPosition.y + jumpHeight, jumpUpDuration).SetEase(Ease.OutQuad));
        seq.Append(
            DOTween.To(() => rectTransform.localPosition, y => rectTransform.localPosition = y,
                    new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y - fallDistance, rectTransform.localPosition.z),
                    fallDownDuration)
                .SetEase(Ease.InQuad)
        );
        rectTransform.DOLocalRotate(new Vector3(0, 0, 360f), fallDownDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutSine)
            .SetDelay(jumpUpDuration);

        seq.OnComplete(() => Destroy(newShape.gameObject));
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
