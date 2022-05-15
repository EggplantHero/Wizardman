using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public UI ui;
    public GameObject heartPrefab;

    void Awake()
    {
    }


    void Start()
    {
        for (var i = 0; i < ui.player.combat.MaxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab.gameObject, new Vector3(32 * i, 0, 0), Quaternion.identity);
            heart.transform.SetParent(this.transform);
            heart.transform.localPosition = new Vector3(64 + i * 96, -64, 0);
            heart.GetComponent<Heart>().Setup(i, ui.player);
        }
    }
}
