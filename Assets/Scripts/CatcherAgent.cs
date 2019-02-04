using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class CatcherAgent : Agent{

    public GameObject goall;
    public float speed;

    private Rigidbody agentRigidbody;
    private RayPerception rayPerception;
    private AgentArea agentArea;
    bool goalFound = false;

    float distBeforAction = 0f;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
        agentRigidbody = GetComponent<Rigidbody>();
        rayPerception = GetComponent<RayPerception>();
        goall = GameObject.Find("Goal");
        agentArea = transform.parent.GetComponent<AgentArea>();
    }

    public override void AgentReset()
    {
        // Reset
        // agentArea.ResetArea();
        goall = GameObject.Find("Goal");
        agentRigidbody.velocity = Vector3.zero;
        agentArea.ResetArea();
    
    }

    public override void CollectObservations()
    {
        List<float> rayAngleList = new List<float>();
        float[] rayAngles = new float[150];

        int i = 0;

        do {

            rayAngleList.Add(i);
            i += 5;

        }while (i< 361);

        rayAngles = rayAngleList.ToArray();

        float rayDistance = 45f;
        string[] detectableObjects = { "goal", "wall" };
        AddVectorObs(rayPerception.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f));

        //Agents rotation
        AddVectorObs(agentRigidbody.rotation);

        // Agents velocity
        AddVectorObs(agentRigidbody.velocity);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Speed
        speed = 50 * vectorAction[2];

        if (speed < 0) {
            speed *= -1;
        }

        // ROTATION
        Vector3 rotateVector = transform.up * vectorAction[0];
        agentRigidbody.MoveRotation(Quaternion.Euler(agentRigidbody.rotation.eulerAngles + rotateVector * speed));

        // MOVEMENT
        Vector3 moveVector = transform.forward * vectorAction[1];
        agentRigidbody.AddForce(moveVector * speed, ForceMode.VelocityChange);

        // DETERMINE STATE

        if (GetCumulativeReward() <= -0.5f)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            AddReward(-0.15f);
            agentArea.UpdateScore(GetCumulativeReward());
            //    Debug.Log("COLIDED WITH WALL");
            agentRigidbody.velocity = Vector3.zero;
        }
        else if (collision.gameObject.CompareTag("goal"))
        {
            AddReward(1f);
            Debug.Log("Won! :D Reward: " + GetCumulativeReward());
            Done();
            //Indicate success with the ground material
            StartCoroutine(agentArea.SwapGroundMaterial(success: true));
        }
    }

}
