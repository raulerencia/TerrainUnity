using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float gravity = -9.8f;
    public float jumpForce = 1f;
    float fallVelocity;
    public KeyCode jump;

    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        SetGravity();

        PlayerSkills();

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void SetGravity(){
    
        /*Vector3 gravityVector = new Vector3(0, -gravity, 0);
        controller.Move(gravityVector * Time.deltaTime);*/

        if (controller.isGrounded)
        {
            fallVelocity = gravity * Time.deltaTime;
            Vector3 gravityVector = new Vector3(0, fallVelocity, 0);
            controller.Move(gravityVector * Time.deltaTime);
        }else{
            fallVelocity -= gravity * Time.deltaTime;
            Vector3 gravityVector = new Vector3(0, fallVelocity, 0);
            controller.Move(gravityVector * Time.deltaTime);
        }

        Debug.Log(fallVelocity);

        SlideDown();

    }

    void PlayerSkills(){

        if (controller.isGrounded && Input.GetKeyDown(jump))
        {
            fallVelocity = jumpForce;
            Vector3 gravityVector = new Vector3(0, fallVelocity, 0);
            controller.Move(gravityVector * Time.deltaTime);
        }
    }

    public void SlideDown(){
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= controller.slopeLimit;

        if(isOnSlope){
            Vector3 slideVector = new Vector3(hitNormal.x * slideVelocity, -slopeForceDown, hitNormal.z * slideVelocity);
            controller.Move(slideVector * Time.deltaTime);
        }
    
    
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        hitNormal = hit.normal;

    }
}
