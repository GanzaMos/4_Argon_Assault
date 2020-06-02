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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        transform.localPosition = new Vector3
            (
            Mathf.Clamp(transform.localPosition.x + xOffset, -xMaxOffset, xMaxOffset),
            Mathf.Clamp(transform.localPosition.y + yOffset, -yMaxOffset, yMaxOffset),
            transform.localPosition.z
            );

        
        

    }
}
