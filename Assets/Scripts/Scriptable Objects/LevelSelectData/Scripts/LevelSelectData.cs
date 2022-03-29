using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New LevelSelectData", menuName = "ScriptableObjects/LevelSelectData")]


public class LevelSelectData : ScriptableObject
{
    public Category[] categories;

}


[System.Serializable]
public class Category
{
    public string name;
    public Level[] levels;
}

[System.Serializable]
public class Level
{
    public string levelName;
}