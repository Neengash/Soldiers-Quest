using UnityEngine;

public class FeetTrigger : MonoBehaviour
{
    HeroGameController hero;
    [SerializeField] int currentFloors;

    void Start()
    {
        hero = FindObjectOfType<HeroGameController>();
        currentFloors = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.FLOOR) {
            hero.EnterFloor();
            currentFloors++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.FLOOR) {
            currentFloors--;
            if (currentFloors  == 0) {
                hero.LeaveFloor();
            }
        }
    }
}
