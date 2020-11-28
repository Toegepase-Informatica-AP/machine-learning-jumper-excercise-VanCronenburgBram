using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Player : Agent
{
    public float jumpHeight = 6f;

    private bool canJump = true;
    private Rigidbody body;
    private Environment environment;
    private int carsHit;

    public override void Initialize()
    {
        base.Initialize();
        body = GetComponent<Rigidbody>();
        environment = GetComponentInParent<Environment>();
    }

    private void JumpPlayer()
    {
        if (canJump)
        {
            body.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.VelocityChange);
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        Transform street = environment.transform.Find("Street");

        if (transform.position.y - street.position.y <= 1)
        {
            AddReward(0.001f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Street"))
            canJump = true;

        if (collision.gameObject.CompareTag("Car"))
        {
            AddReward(-1f);
            carsHit++;

            if (carsHit >= 5)
                EndEpisode();
            else
            {
                environment.ClearEnvironment();
                environment.SpawnObject();
            }
        }

        if (collision.gameObject.CompareTag("Reward"))
        {
            AddReward(1f);
            environment.ClearEnvironment();
            environment.SpawnObject();
        }
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(22f, 0.5f, 0f);

        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;

        environment.ClearEnvironment();
        environment.SpawnObject();

        carsHit = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            actionsOut[0] = 1;
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if (vectorAction[0] == 0)
        {
            return;
        }

        if (vectorAction[0] != 0)
        {
            JumpPlayer();
        }
    }
}
