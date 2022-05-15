using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GroundItem<O> : MonoBehaviour, ISerializationCallbackReceiver
where O : ItemObject
{
    public O itemObject;

    public SoundType pickupSFX;

    public void OnBeforeSerialize()
    {
        ReRender();
    }
    public void OnAfterDeserialize()
    {
    }

    public void ReRender()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = itemObject.uiDisplay;
        EditorUtility.SetDirty(renderer);
    }

    public void PlaySFX()
    {
        Singleton.Main.AudioManager.Play(pickupSFX);
    }
}
