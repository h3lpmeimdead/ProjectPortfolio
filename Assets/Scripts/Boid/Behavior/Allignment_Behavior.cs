using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Allignment")]
public class Allignment_Behavior : Filtered_Flock_Behavior
{
    public override Vector2 CalculateMove(Flock_Agent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, maintain current allignment
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        //add all points together and average
        Vector2 allignmentMove = Vector2.zero;
        List<Transform> filteredContext = (_filter == null) ? context : _filter.Filter(agent, context);
        foreach (Transform item in context)
        {
            allignmentMove += (Vector2)item.transform.up;
        }
        allignmentMove /= context.Count;
        return allignmentMove;
    }
}
