using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid_Spawn_Manager : MonoBehaviour
{
    [SerializeField] private float _heightRange;
    [SerializeField] private float _widthRange;

    private void Start()
    {
        InitBoid();
    }

    void InitBoid()
    {
        for(int i = 0; i < Object_Pooling.Instance._amountToPool; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-_widthRange, _widthRange), Random.Range(-_heightRange, _heightRange));
            GameObject boid = Object_Pooling.Instance.GetPooledObject();
            if (boid != null)
            {
                boid.transform.position = spawnPos;
                boid.SetActive(true);
            }
        }
    }
}
