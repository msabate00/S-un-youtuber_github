using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour
{
    public float JumpSpeed = 10f;
    public float forwardSpeed = 10f;
    public float forwardRunSpeed = 16f;
    public bool IsAutoJump = false;

    private CharacterMotor walker;
    private float OrigJumpSpeed;
    private float OrigForwardSpeed;

    void Start()
    {
        walker = GetComponent<CharacterMotor>();
        OrigJumpSpeed = walker.jumping.baseHeight;
        OrigForwardSpeed = walker.movement.maxForwardSpeed;
    }

    IEnumerator OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag.Contains("Jumper"))
        {
            yield return new WaitForSeconds(0.15f);
            walker.jumping.baseHeight = JumpSpeed;
            walker.movement.maxForwardSpeed = (FPCStatus.isRunning) ? forwardRunSpeed : forwardSpeed;
            walker.inputJump = true;
            IsAutoJump = true;
        }
    }

    void Update()
    {
        if (IsAutoJump)
        {
            StartCoroutine(RestoreOrigJump());
        }
    }

    public virtual IEnumerator RestoreOrigJump()
    {
        yield return new WaitForSeconds(0.1f);

        if (walker.IsGrounded())
        {
            walker.jumping.baseHeight = OrigJumpSpeed;
            walker.movement.maxForwardSpeed = OrigForwardSpeed;
            IsAutoJump = false;
        }
    }



}