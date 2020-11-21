using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Player : Agent
{
    private Rigidbody body;
    private Environment environment;
    private int carsDodged = 0;

    public override void Initialize()
    {
        base.Initialize();
        body = GetComponent<Rigidbody>();
        environment = GetComponentInParent<Environment>();
    }

    public override void OnEpisodeBegin()
    {
        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;

        environment.ClearEnvironment();
        environment.SpawnCar();

        carsDodged = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if (transform.localPosition.y > 1)
        {
            AddReward(1f);
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;
        actionsOut[1] = 0f;
        actionsOut[2] = 0f;

        if (Input.GetKey(KeyCode.Space)) // Jumping
        {
            actionsOut[2] = 1f;
        }
    }

    void OnCollisionEnter()
    {
        AddReward(-1f);
        EndEpisode();
    }
}
