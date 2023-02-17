using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Loop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        var bc = GetComponent<BoxCollider2D>();
        width = bc.size.x;
        bc.enabled = false;
    }

    void Update()
    {
        if (transform.position.x <= -width)
            transform.position += width * 2f * Vector3.right;
    }
}
