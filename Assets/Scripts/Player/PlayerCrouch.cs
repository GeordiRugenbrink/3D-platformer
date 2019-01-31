using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField]
    private float crouchHeight = 0.5f;

    private void Update() {
        if (Input.GetAxis("Crouch") > 0.5f && PlayerMovement.playerGroundState == PlayerGroundState.GROUNDED) {
            Crouch();
        }
        else {
            ReturnToNormalSize();
        }
    }
    /// <summary>
    /// Changes the size of the player to make it look like it's crouching.
    /// </summary>
    private void Crouch() {
        transform.localScale = new Vector3(1, crouchHeight, 1);
        PlayerMovement.playerStanceState = PlayerStanceState.CROUCHING;
    }

    /// <summary>
    /// Returns the player to it's normal size after crouching.
    /// First it checks if it has enough room to return to it's normal size
    /// before it actually changes it's size.
    /// </summary>
    private void ReturnToNormalSize() {
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = Vector3.up;
        if (!Physics.Raycast(ray, out hit, 1)) {
            transform.localScale = Vector3.one;
            if (PlayerMovement.playerStanceState != PlayerStanceState.JUMPING) {
                PlayerMovement.playerStanceState = PlayerStanceState.NORMAL;
            }
        }
        else {
            Debug.Log("Not enough room to stand up!");
        }
    }
}
