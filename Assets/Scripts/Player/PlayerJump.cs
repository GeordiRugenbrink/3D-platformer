using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 7f;

    [SerializeField]
    private float crouchJumpForce = 12f;

    [SerializeField]
    private float fallMultiplier = 2.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;

    [SerializeField]
    private int maxJumps = 2;
    private int jumps;

    private new Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(PlayerMovement.playerStanceState == PlayerStanceState.CROUCHING &&
            Input.GetButtonDown("Jump") &&
            PlayerMovement.playerGroundState == PlayerGroundState.GROUNDED) {
            CrouchJump(crouchJumpForce);
        }else if (Input.GetButtonDown("Jump") && PlayerMovement.playerStanceState != PlayerStanceState.ATTACKING) {
            Jump(jumpForce);
        }

        if (rigidbody.velocity.y < 0) {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rigidbody.velocity.y > 0 && !Input.GetButton("Jump")) {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Jump(float jumpForce) {
        if (jumps > 0) {
            rigidbody.velocity = Vector3.up * jumpForce;
            PlayerMovement.playerGroundState = PlayerGroundState.AIRBORNE;
            PlayerMovement.playerStanceState = PlayerStanceState.JUMPING;
            jumps -= 1;
        }

        if(jumps <= 0) {
            return;
        }
    }
    /// <summary>
    /// When crouching and jumping at the same time the player will have an increased jumpforce
    /// so it gets one incredibly high jump. The player can't use double jump after this jump though.
    /// </summary>
    /// <param name="jumpForce">The amount of force applied to the player's y velocity.</param>
    private void CrouchJump(float jumpForce) {
        rigidbody.velocity = Vector3.up * jumpForce;
        PlayerMovement.playerGroundState = PlayerGroundState.AIRBORNE;
        PlayerMovement.playerStanceState = PlayerStanceState.JUMPING;
        jumps -= maxJumps;
    }

    /// <summary>
    /// Checks if the player has touched the ground.
    /// </summary>
    /// <param name="other">The other collision used to compare with the ground.</param>
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground") {
            jumps = maxJumps;
            PlayerMovement.playerGroundState = PlayerGroundState.GROUNDED;
            PlayerMovement.playerStanceState = PlayerStanceState.NORMAL;
        }
    }
}
