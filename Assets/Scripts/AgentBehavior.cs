using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for the agents Player Brain. To controll the agent with manual keyboard input from user. 
/// This is usefull to test the agent and the environment prior running the training with neuronal network.
/// </summary>
public class AgentBehavior : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody AgentRb;

    /// <summary>
    /// Initialize agent.
    /// </summary>
    void Start()
    {
        AgentRb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Run on each Frame. Get user input, rotate and move the agent according to that input. 
    /// </summary>
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log("Horizontal: "+horizontal);
        Debug.Log("Vertical: " + horizontal);

        Vector3 movement = new Vector3(horizontal , 0, vertical);

        AgentRb.AddForce(movement * speed);
    }
}
