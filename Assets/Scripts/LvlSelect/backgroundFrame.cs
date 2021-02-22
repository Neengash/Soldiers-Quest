using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundFrame : MonoBehaviour
{
    ParallaxController parallax;

    void Start()
    {
        parallax = FindObjectOfType<ParallaxController>();

        parallax.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            parallax.transform.position.z
            );
    }
}
