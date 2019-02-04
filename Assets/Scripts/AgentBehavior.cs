using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehavior : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody AgentRb;

    // Start is called before the first frame update
    void Start()
    {
        AgentRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
