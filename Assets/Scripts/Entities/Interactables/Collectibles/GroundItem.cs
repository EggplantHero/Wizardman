using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GroundItem<O> : MonoBehaviour, ISerializationCallbackReceiver
where O : ItemObject
{
    public O itemObject;
    protected AudioManager audioManager;
    public SoundType pickupSFX;

    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

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
        audioManager.Play(pickupSFX, audioManager.sfx_interactables_track);
    }
}
