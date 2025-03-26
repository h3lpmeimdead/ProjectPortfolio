using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class Same_Flock_Filter : Context_Filter
{
    public override List<Transform> Filter(Flock_Agent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach(Transform item in original)
        {
            Flock_Agent itemAgent = item.GetComponent< Flock_Agent>();
            if(itemAgent != null && itemAgent._AgentFlock == agent._AgentFlock)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
