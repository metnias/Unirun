using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Scroll : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        if (GameManager.IsGameover()) return;
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
