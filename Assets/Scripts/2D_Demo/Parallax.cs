using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material _material;
    float _distance;

    [Range(0f, 0.5f)]
    public float Speed = 0.2f;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _distance += Time.deltaTime * Speed;
        _material.SetTextureOffset("_MainTex", Vector2.right * _distance);
    }
}
