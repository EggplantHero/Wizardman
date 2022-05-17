using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelSelectScreen : MonoBehaviour
{
    public LevelSelectData levelSelectData;
    public GameObject levelSelectButtonPrefab;

    void Start()
    {
        Transform Grid = this.transform.Find("Grid");

        foreach (var (category, i) in levelSelectData.categories.Select((value, index) => (value, index)))
        {
            foreach (var (level, j) in category.levels.Select((value, index) => (value, index)))
            {
                Transform button = Instantiate(levelSelectButtonPrefab, Vector3.zero, Quaternion.identity).transform;
                button.SetParent(Grid);
                button.localScale = Vector3.one;
                button.GetComponentInChildren<Text>().text = $"{i + 1}-{j + 1}";
                button.GetComponent<LevelSelectButton>().LevelName = level.levelName;
            }
        }
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
}
