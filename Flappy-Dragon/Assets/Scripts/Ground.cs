using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float movingSpeed = 1;

    public void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();   
    }

    public void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(movingSpeed * Time.deltaTime, 0f);
    }
}
