using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float diagonalSpeedMultiplier = 0.75f;

    private Rigidbody rigidbody;

    [SerializeField]
    private float turnSmoothing = 15f;

    private float currentMovementSpeed;

    private new Camera camera;

    public static PlayerStanceState playerStanceState = PlayerStanceState.NORMAL;

    public static PlayerGroundState playerGroundState = PlayerGroundState.GROUNDED;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    private void FixedUpdate() {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.5f &&
            Mathf.Abs(Input.GetAxis("Vertical")) >= 0.5f) {
            currentMovementSpeed = movementSpeed * diagonalSpeedMultiplier;
        }
        else {
            currentMovementSpeed = movementSpeed;
        }
        Move();
    }

    private void Move() {
        Rotation(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Rotation(float horizontal, float vertical) {
        Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
        targetDirection = camera.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;

        rigidbody.MovePosition(rigidbody.position + Vector3.Normalize(targetDirection) * currentMovementSpeed * Time.fixedDeltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        Quaternion newRotation = Quaternion.Lerp(transform.localRotation, targetRotation, turnSmoothing * Time.deltaTime);

        if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f ||
            Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f) {
            transform.rotation = newRotation;
        }
    }
}

public enum PlayerStanceState {
    CROUCHING,
    ATTACKING,
    JUMPING,
    NORMAL
}

public enum PlayerGroundState {
    GROUNDED,
    AIRBORNE
}
