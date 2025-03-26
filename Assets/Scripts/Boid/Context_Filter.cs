using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Context_Filter : ScriptableObject
{
    public abstract List<Transform> Filter (Flock_Agent agent, List<Transform> original);
}
