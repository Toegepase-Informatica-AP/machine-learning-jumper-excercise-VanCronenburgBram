using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Player : Agent
{
    public float jumpHeight = 0.01f;

    private bool canJump = true;
    private Rigidbody body;
    private Environment environment;
    private int carsHit = 0;

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
        if (Input.GetKey(KeyCode.Space))
            JumpPlayer();

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
            /*environment.ClearEnvironment();
            environment.SpawnCar();
            carsHit++;

            if (carsHit >= 5)
                EndEpisode();*/
            EndEpisode();
        }
    }

    public override void OnEpisodeBegin()
    {
        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;

        environment.ClearEnvironment();
        environment.SpawnCar();

        //carsHit = 0;

        if (environment.GetComponentInChildren<Player>() == null)
        {
            environment.SpawnPlayer();
        }
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
        if (Input.GetKey(KeyCode.Space))
        {
            JumpPlayer();
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if (vectorAction[0] == 1f)
        {
            JumpPlayer();
        }
    }
}
