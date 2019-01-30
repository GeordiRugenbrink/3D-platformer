using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField]
    private float crouchHeight = 0.5f;

    private void Update() {
        if (Input.GetAxis("Crouch") > 0.5f) {
            Crouch();
        }
        else {
            ReturnToNormalSize();
        }
    }

    private void Crouch() {
        transform.localScale = new Vector3(1, crouchHeight, 1);
    }

    private void ReturnToNormalSize() {
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = Vector3.up;
        if (!Physics.Raycast(ray, out hit, 1)) {
            transform.localScale = Vector3.one;
        }
        else {
            Debug.Log("Not enough room to stand up!");
        }
    }
}
