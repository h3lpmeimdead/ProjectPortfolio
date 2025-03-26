using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] private Flock_Agent _agentPrefab;
    List<Flock_Agent> _agents = new List<Flock_Agent>();
    [SerializeField] private Flock_Behavior _behavior;

    [Range(10, 500)]
    public int _startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float _driveFactor = 10f;
    [Range(1f, 100f)]
    public float _maxSpeed = 5f;
    [Range(1f, 10f)]
    public float _neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float _avoidanceRadiusMultiplier = 0.5f;

    float _squareMaxSpeed;
    float _squareNeighborRadius;
    float _squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return _squareAvoidanceRadius; } }
    // Start is called before the first frame update
    void Start()
    {
        _squareMaxSpeed = _maxSpeed * _maxSpeed;
        _squareNeighborRadius = _neighborRadius * _neighborRadius;
        _squareAvoidanceRadius = _squareNeighborRadius * _avoidanceRadiusMultiplier * _avoidanceRadiusMultiplier;

        for(int i = 0; i < _startingCount; i++)
        {
            Flock_Agent newAgent = Instantiate(_agentPrefab, Random.insideUnitCircle * _startingCount * AgentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent" + i;
            newAgent.Init(this);
            _agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Flock_Agent agent in _agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
            Vector2 move = _behavior.CalculateMove(agent, context, this);
            move *= _driveFactor;
            if (move.sqrMagnitude > _squareMaxSpeed)
            {
                move = move.normalized * _maxSpeed;
            }
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(Flock_Agent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, _neighborRadius);
        foreach(Collider2D c in contextColliders)
        {
            if(c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}