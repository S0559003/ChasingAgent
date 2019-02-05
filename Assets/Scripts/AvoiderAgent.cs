using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

/// <summary>
/// Representing a concrete instance of an Agent. An Avoider Agent.
/// Avoider is an Agent trying to avoid certain objects. 
/// </summary>
public class AvoiderAgent : Agent
{
    public GameObject goall;
    public float speed;

    private Rigidbody agentRigidbody;
    private RayPerception rayPerception;
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
        // Reset
        goall = GameObject.Find("Goal");
        agentRigidbody.velocity = Vector3.zero;
        agentArea.ResetArea();
    }

    /// <summary>
    /// Collect all observations from the agents area to use for making decission.
    /// </summary>
    public override void CollectObservations()
    {
        List<float> rayAngleList = new List<float>();
        float[] rayAngles = new float[150];

        int i = 0;

        do
        {
            if (i > 105 || i < 75)
            {
                i += 15;
            }
            else if (i > 125 || i < 55)
            {
                i += 20;
            }
            else
            {    // 90 +- 15°  
                i += 5;
            }
            rayAngleList.Add(i);
        } while (i < 185);

        rayAngleList.Add(90);
        rayAngleList.Add(355);
        rayAngleList.Add(270);
        rayAngles = rayAngleList.ToArray();

        float rayDistance = 45f;
        string[] detectableObjects = { "catcher", "wall" };
        AddVectorObs(rayPerception.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f));

        //Agents rotation
        AddVectorObs(agentRigidbody.rotation);

        // Agents velocity
        AddVectorObs(agentRigidbody.velocity);
    }

    /// <summary>
    /// Apply vector action. The agent receives decisions represented in a vector with floating point numbers.
    /// </summary>
    /// <param name="vectorAction">Vector containing float values from -1 to 1. Representing actions the agent will perform.</param>
    /// <param name="textAction"></param>
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Speed
        speed = 30 * vectorAction[2];

        if (speed < 0)
        {
            speed *= -1;
        }

        // ROTATION
        Vector3 rotateVector = transform.up * vectorAction[0];
        agentRigidbody.MoveRotation(Quaternion.Euler(agentRigidbody.rotation.eulerAngles + rotateVector * speed));

        // MOVEMENT
        Vector3 moveVector = transform.forward * vectorAction[1];
        agentRigidbody.AddForce(moveVector * speed, ForceMode.VelocityChange);

        // DETERMINE STATE

        if (GetCumulativeReward() < -1.5f)
        {
            // Reward is too negative, give up
           // Done();
            // Indicate failure with the ground material
           // StartCoroutine(agentArea.SwapGroundMaterial(success: false));
        }
        else
        {
            // Encourage movement with a tiny time penalty and update the score text display
            AddReward(+.001f);
           // agentArea.UpdateScore(GetCumulativeReward());
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
            AddReward(-0.10f);
           // agentArea.UpdateScore(GetCumulativeReward());
            //    Debug.Log("COLIDED WITH WALL");
            agentRigidbody.velocity = Vector3.zero;
        }
        else if (collision.gameObject.CompareTag("catcher"))
        {
            AddReward(-1f);
           // Debug.Log("Loosed! :( Reward: " + GetCumulativeReward());
           // Done();
            //Indicate success with the ground material
        //    StartCoroutine(agentArea.SwapGroundMaterial(success: false));
        }
    }

}
