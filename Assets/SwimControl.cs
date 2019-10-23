using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SwimControl : MonoBehaviour
{
    public int swimForceMultiplier = 100;
    private SteamVR_Action_Pose poseAction;
    private Rigidbody rb;
    public bool logVelocity = false;

    // Start is called before the first frame update
    void Start()
    {
        poseAction = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var combined_velocity = poseAction[SteamVR_Input_Sources.LeftHand].velocity.magnitude + poseAction[SteamVR_Input_Sources.RightHand].velocity.magnitude;
        if (logVelocity)
        {
            Debug.Log("vel: " + combined_velocity);
        }
        rb.AddForce(Camera.main.transform.forward * combined_velocity * swimForceMultiplier);
    }
}
