using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("ms^-1")] [SerializeField] float xSpeed = 150f;
    [Tooltip("ms^-1")] [SerializeField] float ySpeed = 150f;
    [SerializeField] float xMaxOffset = 30f;
    [SerializeField] float yMaxOffset = 15f;

    [SerializeField] float pitchOffset = 10f;
    [SerializeField] float yawOffset = 10f;

    [SerializeField] float pitchOffsetMoment = 10f;
    [SerializeField] float yawOffsetMoment = 30f;
    [SerializeField] float rollOffsetMoment = 30f;



    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

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
