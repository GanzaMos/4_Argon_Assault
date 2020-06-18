using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementAndRotation : MonoBehaviour
{
    [Header("Offset speed")]
    [Tooltip("ms^-1")] [SerializeField] float xSpeed = 150f;
    [Tooltip("ms^-1")] [SerializeField] float ySpeed = 150f;


    [Header("Limits available screen to movement")]
    [SerializeField] float xMaxOffset = 30f;
    [SerializeField] float yMaxOffset = 15f;

    [Header("Something about moving offset")]
    [SerializeField] float pitchOffset = 10f;
    [SerializeField] float yawOffset = 10f;

    [Header("Offset when moving")]
    [SerializeField] float pitchOffsetMoment = 10f;
    [SerializeField] float yawOffsetMoment = 30f;
    [SerializeField] float rollOffsetMoment = 30f;



    float xThrow, yThrow;
    bool controlEnable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlEnable == true)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void OnPlayerDeath() //called by string referance. Don't rename!
    {
        controlEnable = false;
        print("Movement frozen");
    }

    private void ProcessRotation()
    {
        float pitch = pitchOffset  / yMaxOffset * transform.localPosition.y + -yThrow * pitchOffsetMoment;
        float yaw = -yawOffset / xMaxOffset * transform.localPosition.x + xThrow * yawOffsetMoment; ;
        float roll = CrossPlatformInputManager.GetAxis("Horizontal") * -rollOffsetMoment + transform.localRotation.z;
        transform.localRotation = Quaternion.Euler(
            pitch,
            yaw, 
            roll
            );
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        transform.localPosition = new Vector3
            (
            Mathf.Clamp(transform.localPosition.x + xOffset, -xMaxOffset, xMaxOffset),
            Mathf.Clamp(transform.localPosition.y + yOffset, -yMaxOffset, yMaxOffset),
            transform.localPosition.z
            );
    }

}
