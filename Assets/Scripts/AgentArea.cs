using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using TMPro;

/// <summary>
/// Setting up Agents area/environment
/// </summary>

public class AgentArea : Area
{
    [Header("Agent Area Objects")]

    /// <summary>
    /// The cather agent
    /// </summary>
    public GameObject agent;

    /// <summary>
    /// Avoider agent
    /// </summary>
    public GameObject goal;

    /// <summary>
    /// Areas ground
    /// </summary>
    public GameObject ground;

    /// <summary>
    /// Material representing sucess
    /// </summary>
    public Material successMaterial;

    /// <summary>
    /// Material representing failure
    /// </summary>
    public Material failureMaterial;

    /// <summary>
    /// Visulazing catcher agents score in area
    /// </summary>
    public TextMeshPro scoreText;

    [HideInInspector]
    /// <summary>
    /// A range on which objects like the catcher or avoider agent will be spawned
    /// </summary>
    public float spawnRange;

    private Renderer groundRenderer;
    private Material groundMaterial;

    private int notGroundLayerMask;


    /// <summary>
    /// Initialize the area script
    /// </summary>
    private void Start()
    {
        // Get the ground renderer so we can change the material when a goal is scored
        groundRenderer = ground.GetComponent<Renderer>();

        // Store the starting material
        groundMaterial = groundRenderer.material;

        // Create a layer mask equating to "not ground"
        notGroundLayerMask = ~LayerMask.GetMask("ground");

        ResetArea();
    }

    /// <summary>
    /// Upadating the score text
    /// </summary>
    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString("0.00");
    }

    /// <summary>
    /// Resets the area
    /// </summary>
    /// <param name="agents"></param>
    public override void ResetArea()
    {
        ResetAgent();
        ResetGoal();
    }

    /// <summary>
    /// Swap ground material, wait time seconds, then swap back to the regular material.
    /// </summary>
    /// /// <param name="success">representing sucess or failure</param>
    public IEnumerator SwapGroundMaterial(bool success)
    {

        //Debug.Log(" Im Suces material: ");
        if (success)
        {
           // Debug.Log("Suces material: "+success);
            groundRenderer.material = successMaterial;
        }
        else
        {
         //   Debug.Log("Suces material: " + success);
            groundRenderer.material = failureMaterial;
        }

        yield return new WaitForSeconds(0.5f);
        groundRenderer.material = groundMaterial;
    }

    /// <summary>
    /// Reset the agents position
    /// </summary>
    private void ResetAgent()
    {
        spawnRange = ground.GetComponent<Collider>().bounds.size.x / 4;

        // Reset location and rotation
        RandomlyPlaceObject(agent, spawnRange, 10);
    }

    /// <summary>
    /// Resets avoider agents position
    /// </summary>
    private void ResetGoal()
    {
        spawnRange = transform.GetChild(1).GetComponent<Collider>().bounds.size.x / 4;
        // Reset location and rotation
        RandomlyPlaceObject(goal, spawnRange, 10);
    }

    /// <summary>
    /// Attempts to randomly place an object by checking a sphere around a potential location for collisions
    /// </summary>
    /// <param name="objectToPlace">The object to be randomly placed</param>
    /// <param name="range">The range in x and z to choose random points within.</param>
    /// <param name="maxAttempts">Number of times to attempt placement</param>
    private void RandomlyPlaceObject(GameObject objectToPlace, float range, float maxAttempts)
    {
        // Temporarily disable collision
        objectToPlace.GetComponent<Collider>().enabled = false;

        // Calculate test radius 10% larger than the collider extents
        float testRadius = GetColliderRadius(objectToPlace) * 2.5f;

        // Set a random rotation
        objectToPlace.transform.rotation = Quaternion.Euler(new Vector3(0f, UnityEngine.Random.Range(0f, 360f), 0f));

        // Make several attempts at randomly placing the object
        int attempt = 1;
        while (attempt <= maxAttempts)
        {
            
            Vector3 randomLocalPosition = new Vector3(UnityEngine.Random.Range(transform.GetChild(1).GetComponent<Collider>().transform.position.x + 0.6f, (transform.GetChild(1).GetComponent<Collider>().transform.position.x + transform.GetChild(1).GetComponent<Collider>().bounds.size.x / 4) - 0.6f), 1f, UnityEngine.Random.Range(transform.GetChild(1).GetComponent<Collider>().transform.position.z + 0.6f, (transform.GetChild(1).GetComponent<Collider>().transform.position.z + transform.GetChild(1).GetComponent<Collider>().bounds.size.z / 4) - 0.6f));
            randomLocalPosition.Scale(transform.localScale);

            if (!Physics.CheckSphere(transform.position + randomLocalPosition, testRadius, notGroundLayerMask))
            {
                objectToPlace.transform.position = randomLocalPosition;
                break;
            }
            else if (attempt == maxAttempts)
            {
                break;
            }

            attempt++;
          //  Debug.Log("Attempt: "+attempt);
        }

        // Enable collision
        objectToPlace.GetComponent<Collider>().enabled = true;
    }

    /// <summary>
    /// Gets a local space radius that draws a circle on the X-Z plane around the boundary of the collider
    /// </summary>
    /// <param name="obj">The game object to test</param>
    /// <returns>The local space radius around the collider</returns>
    private static float GetColliderRadius(GameObject obj)
    {
        Collider col = obj.GetComponent<Collider>();

        Vector3 boundsSize = Vector3.zero;
        if (col.GetType() == typeof(MeshCollider))
        {
            boundsSize = ((MeshCollider)col).sharedMesh.bounds.size;
        }
        else if (col.GetType() == typeof(BoxCollider))
        {
            boundsSize = col.bounds.size;
        }

        boundsSize.Scale(obj.transform.localScale);
        return Mathf.Max(boundsSize.x, boundsSize.z) / 2f;
    }
}