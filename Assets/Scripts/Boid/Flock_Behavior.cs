using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Flock_Behavior : ScriptableObject
{
    public abstract Vector2 CalculateMove(Flock_Agent agent, List<Transform> context, Flock flock);
}
