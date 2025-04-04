using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class Cohesion_Behavior : Filtered_Flock_Behavior
{
    public override Vector2 CalculateMove(Flock_Agent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if(context.Count == 0)
        {
            return Vector2.zero;
        }

        //add all points together and average
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (_filter == null) ? context : _filter.Filter(agent, context);
        foreach (Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        //create offset from agent position
        cohesionMove -= (Vector2)agent.transform.position;
        return cohesionMove;
    }
}
