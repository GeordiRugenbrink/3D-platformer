using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 7f;

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
        if (Input.GetButtonDown("Jump")) {
            Jump(jumpForce);
        }

        if(rigidbody.velocity.y < 0) {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rigidbody.velocity.y > 0 && !Input.GetButton("Jump")) {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Jump(float jumpForce) {
        if (jumps > 0) {
            rigidbody.velocity = Vector3.up * jumpForce;
            jumps -= 1;
        }

        if(jumps <= 0) {
            return;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground") {
            jumps = maxJumps;
        }
    }
}
