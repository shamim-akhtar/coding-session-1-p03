using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMovement : MonoBehaviour
{
  [SerializeField]
  CharacterController mCharacterController;

  [SerializeField]
  Animator mAnimator;

  public float mWalkSpeed = 1.0f;
  public float mRotationSpeed = 50.0f;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    HandleInputs();
    float hInput = Input.GetAxis("Horizontal");
    float vInput = Input.GetAxis("Vertical");

    float speed = mWalkSpeed;
    if (Input.GetKey(KeyCode.LeftShift))
    {
      speed = mWalkSpeed * 2.0f;
    }
    if (mAnimator == null) return;
    
    // In the following section we set the rotation of the 
    // player from the vertical input.
    // we also attenuate the input by factoring in the
    // delta time and the rotation speed.
    transform.Rotate(
      0.0f, 
      hInput * mRotationSpeed * Time.deltaTime, 
      0.0f);

    // In this section we set the new forward 
    // after the player is rotated.
    Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
    forward.y = 0.0f;

    // now we call the character controller's move method.
    mCharacterController.Move(forward * vInput * speed * Time.deltaTime);
    mAnimator.SetFloat("PosX", 0);

    // we change the speed of the movement by setting the
    // PosZ parameter in our animator.
    mAnimator.SetFloat("PosZ", vInput * speed / (2.0f * mWalkSpeed));
  }

  private void HandleInputs()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
      mAnimator.SetTrigger("JumpParameter");
    }
    if(Input.GetKeyDown(KeyCode.X))
    {
      mAnimator.SetBool("Attack1Parameter", true);
    }
    if(Input.GetKeyUp(KeyCode.X))
    {
      mAnimator.SetBool("Attack1Parameter", false);
    }
    if (Input.GetKeyDown(KeyCode.R))
    {
      mAnimator.SetTrigger("Reload");
    }
    if (Input.GetKeyDown(KeyCode.G))
    {
      mAnimator.SetTrigger("Reload");
      Debug.Log("Error. PLease remove");
    }
  }

  private void Jump()
  {

  }

  private void Attack()
  {

  }

  private void Reload()
  {

  }
}
