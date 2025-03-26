using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Flock_Agent : MonoBehaviour
{
    Flock _agentFlock;
    public Flock _AgentFlock {  get { return _agentFlock; } }

    Collider2D _agentCollider;
    public Collider2D AgentCollider { get { return _agentCollider; } }
    // Start is called before the first frame update
    void Start()
    {
        _agentCollider = GetComponent<Collider2D>();
    }

    public void Init(Flock flock)
    {
        _agentFlock = flock;
    }

    public void Move(Vector2 _velocity)
    {
        transform.up = _velocity;
        transform.position += (Vector3)_velocity * Time.deltaTime;
    }
}
