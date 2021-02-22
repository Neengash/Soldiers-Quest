using UnityEngine;

public class LimitTrigger : MonoBehaviour
{
    [SerializeField] int limitSide; // -1 for left, 1 for right
    CameraManager scenario;

    void Start()
    {
        scenario = FindObjectOfType<CameraManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO)
        {
            scenario.HeroInLimit(limitSide);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO)
        {
            scenario.HeroOutLimit();
        }
    }
}
