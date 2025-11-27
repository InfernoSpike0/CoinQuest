using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Coin : MonoBehaviour
{
    public float spin = 120f;
    void Update()
    {
        transform.Rotate(0f, spin * Time.deltaTime, 0f, Space.World);
    }
}
