using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform Destination;


    void OnTriggerEnter2D(Collider2D col)
    {
        Entity entity = col.gameObject.GetComponentInParent<Entity>();
        if (entity != null)
        {
            entity.transform.position = Destination.position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
    }
}
