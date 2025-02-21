using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    public GameObject pillarPrefab;
    public float minHeight = -1f;
    public float maxHeight = 1.5f;
    public float repeatRate = 1.5f;

    public void Start()
    {
        InvokeRepeating(nameof(Spawn), repeatRate, repeatRate);
    }

    public void Spawn()
    {
        GameObject pillar = Instantiate (pillarPrefab, transform.position, Quaternion.identity);
        pillar.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
