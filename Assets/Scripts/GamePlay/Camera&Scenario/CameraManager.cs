using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    ParallaxController parallax;
    Camera mainCamera;
    float speed;

    const float STOP = 0;

    public const int LEFT = -1;
    public const int RIGHT = 1;

    void Start()
    {
        parallax = FindObjectOfType<ParallaxController>();
        mainCamera = FindObjectOfType<Camera>();

        parallax.transform.position = new Vector3(
            mainCamera.transform.position.x,
            mainCamera.transform.position.y,
            parallax.transform.position.z);

        parallax.SetSpeed(0f);
    }

    void FixedUpdate()
    {
        if (speed != STOP)
        {
            mainCamera.transform.position = new Vector3(
                mainCamera.transform.position.x + speed * Time.deltaTime,
                mainCamera.transform.position.y,
                mainCamera.transform.position.z);

            parallax.transform.position = new Vector3(
                parallax.transform.position.x + speed * Time.deltaTime,
                parallax.transform.position.y,
                parallax.transform.position.z);

            parallax.SetSpeed(speed * Time.deltaTime);
        } 
    }

    // expects to recieve a constant LEFT or RIGHT as param
    public void HeroInLimit(int limit)
    {
        speed = limit * HeroGameController.BASE_SPEED;       
    }

    public void HeroOutLimit()
    {
        speed = STOP;
        parallax.SetSpeed(STOP);
    }

}
