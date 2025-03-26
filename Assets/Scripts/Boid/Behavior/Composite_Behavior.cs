using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class Composite_Behavior : Flock_Behavior
{
    public Flock_Behavior[] _behaviors;
    public float[] _weights;
    public override Vector2 CalculateMove(Flock_Agent agent, List<Transform> context, Flock flock)
    {
        //handle data mismatch
        if(_weights.Length != _behaviors.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero;
        }

        //setup move
        Vector2 move = Vector2.zero;

        //iterate through behaviors
        for(int i = 0; i < _behaviors.Length; i++)
        {
            Vector2 partialMove = _behaviors[i].CalculateMove(agent, context, flock) * _weights[i];

            if(partialMove != Vector2.zero)
            {
                if(partialMove.sqrMagnitude > _weights[i] * _weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= _weights[i];
                }

                move += partialMove;
            }
        }

        return move;
    }
}
