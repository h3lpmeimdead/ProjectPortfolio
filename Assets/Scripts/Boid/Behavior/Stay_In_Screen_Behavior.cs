using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay in Radius")]
public class Stay_In_Screen_Behavior : Flock_Behavior
{
    public Vector2 _center;
    public float radius = 15f;

    public override Vector2 CalculateMove(Flock_Agent agent, List<Transform> context, Flock flock)
    {
        Vector2 centerOffset = _center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if(t < 0.9f)
        {
            return Vector2.zero;
        }

        return centerOffset * t * t;
    }
}
