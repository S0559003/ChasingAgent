using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAcademy : Academy
{
    /// <summary>
    /// Array to store all the areas belonging to academy
    /// </summary>
    private AgentArea[] areas;

    /// <summary>
    /// Find and reset all areas on belonging to this academy
    /// </summary>
    public override void AcademyReset()
    {
        if (areas == null)
        {
            areas = GameObject.FindObjectsOfType<AgentArea>();
        }

        foreach (AgentArea area in areas)
        {
          //  Debug.Log("Reset Area");
            area.ResetArea();
        }
    }
}
