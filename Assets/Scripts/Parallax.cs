﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float relativeMove = 0.3f;

    void Update()
    {
        transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y * relativeMove);
    }
}
