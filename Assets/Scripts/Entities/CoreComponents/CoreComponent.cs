using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Entity entity;

    protected virtual void Awake()
    {
        entity = transform.parent.GetComponent<Entity>();

        if (entity is null) { Debug.LogError("The parent object of this core component is not an entity. Please attach a script to the gameobject that inherits from 'entity' class."); }
    }

}
