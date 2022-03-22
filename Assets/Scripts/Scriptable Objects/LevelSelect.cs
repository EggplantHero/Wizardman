using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New LevelSelect", menuName = "ScriptableObjects/LevelSelect")]


public class LevelSelect : ScriptableObject
{
    public Category[] categories;

}

public class Category
{
    public string categoryName;
    int categoryIndex;
    public Level[] levels;
}
public class Level
{
    public string LevelName;
    int levelIndex;
}