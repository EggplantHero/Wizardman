using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject heartPrefab;

    public List<Heart> hearts;

    public void Initialize(int MaxHealth)
    {
        for (var i = 0; i < MaxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, new Vector3(32 * i, 0, 0), Quaternion.identity);
            heart.transform.SetParent(this.transform);
            heart.transform.localPosition = new Vector3(64 + i * 96, -64, 0);
            hearts.Add(heart.GetComponent<Heart>());
            // heart.GetComponent<Heart>().index = i;
        }
    }

    public void HandleDamage(int currentHealth)
    {
        foreach (Heart heart in hearts)
        {
            if (hearts.IndexOf(heart) < currentHealth)
            {
                heart.Fill();
            }
            else
            {
                heart.Empty();
            }
        }
    }
}
