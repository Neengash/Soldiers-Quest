using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] float speed = 0;

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float x = meshRenderer.material.mainTextureOffset.x;
        meshRenderer.material.mainTextureOffset = new Vector2(x + Time.deltaTime * speed, 0);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
