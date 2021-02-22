using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyStateI 
{
    void HeroInSight();
    void HeroOutOfSight();
    void HeroInRange();
    void HeroOutOfRange();
}
