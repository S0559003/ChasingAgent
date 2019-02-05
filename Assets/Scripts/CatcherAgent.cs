using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

/// <summary>
/// Representing a concrete instance of an Agent. A Catcher Agent.
/// CatcherAgent is an Agent trying to catch other objects. 
/// </summary>
public class CatcherAgent : Agent{

    /// <summary>
    /// This is a GameObject representing the goal this Agent is catching
    /// </summary>
    public GameObject goall;

    /// <summary>
    /// Speed parameter of the Agent
    /// </summary>
    public float speed;

    /// <summary>
    /// Agents RigidBody to apply physics on this agent.
    /// </summary>
    private Rigidbody agentRigidbody;

    /// <summary>
    /// Container for holding vector observations from the agents sorrounding.
    /// </summary>
    private RayPerception rayPerception;

    /// <summary>
    /// The Area the Agent is collecting observation and taking action
    /// </summary>
    private AgentArea agentArea;

    /// <summary>
    /// Initialize the agent eg. initialize agents attributes with objects found on the scene. 
    /// This method should be called one time before the training starts.
    /// </summary>
    public override void InitializeAgent()
    {
        base.InitializeAgent();
        agentRigidbody = GetComponent<Rigidbody>();
        rayPerception = GetComponent<RayPerception>();
        goall = GameObject.Find("Goal");
        agentArea = transform.parent.GetComponent<AgentArea>();
    }

    /// <summary>
    /// Reset when done. 
    /// eg. reset agents attributes, agents area etc. Is run everytime the agent is 
    /// done with his job. Including the first run.
    /// </summary>
    public override void AgentReset()
    {
        goall = GameObject.Find("Goal");
        agentRigidbody.velocity = Vector3.zero;
        agentArea.ResetArea();
    }

    /// <summary>
    /// Collect all observations from the agents area to use for making decission.
    /// </summary>
    public override void CollectObservations()
    {
        // LIST OF VECTORS SENT FROM THE AGENT TO HIS SORROUNDING
        List<float> rayAngleList = new List<float>();
        float[] rayAngles = new float[360];

        int i = 0;

        do {

            rayAngleList.Add(i);
            i += 5;

        }while (i< 361);

        rayAngles = rayAngleList.ToArray();

        float rayDistance = 45f;

        // Array describing objects the agent is able to detect
        string[] detectableObjects = { "goal", "wall" };
        AddVectorObs(rayPerception.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f));

        //AGENTS CURRENT ROTATION
        AddVectorObs(agentRigidbody.rotation);

        // AGENTS CURRENT VELOCITY
        AddVectorObs(agentRigidbody.velocity);
    }

    /// <summary>
    /// Apply vector action. The agent receives decisions represented in a vector with floating point numbers.
    /// </summary>
    /// <param name="vectorAction">Vector containing float values from -1 to 1. Representing actions the agent will perform.</param>
    /// <param name="textAction"></param>
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // SPEED
        speed = 50 * vectorAction[2];

        // ROTATION
        Vector3 rotateVector = transform.up * vectorAction[0];
        agentRigidbody.MoveRotation(Quaternion.Euler(agentRigidbody.rotation.eulerAngles + rotateVector * speed));

        // MOVEMENT
        Vector3 moveVector = transform.forward * vectorAction[1];
        agentRigidbody.AddForce(moveVector * speed, ForceMode.VelocityChange);

        // DETERMINE STATE

        if (GetCumulativeReward() <= -1f)
        {
            // Reward is too negative, give up
            Done();
            // Indicate failure with the ground material
            StartCoroutine(agentArea.SwapGroundMaterial(success: false));
        }else
        {
            // Encourage movement with a tiny time penalty and update the score text display
            AddReward(-.001f);
            agentArea.UpdateScore(GetCumulativeReward());
        }
    }

    /// <summary>
    /// Check if agents gigidbody collided with other objects in the scene and react on it
    /// </summary>
    /// <param name="collision">Collision object to store and process the type of object the agent collided.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            AddReward(-0.15f);
            agentArea.UpdateScore(GetCumulativeReward());
            agentRigidbody.velocity = Vector3.zero;
        }
        else if (collision.gameObject.CompareTag("goal"))
        {
            AddReward(1f);
            // WON! :D
            Done();
            StartCoroutine(agentArea.SwapGroundMaterial(success: true));
        }
    }

}
