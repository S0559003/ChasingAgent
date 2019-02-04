using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAcademy : Academy
{
    private AgentArea[] areas;

    /// <summary>
    /// Reset the academy
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
