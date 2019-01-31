using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Collider aerialAttackCollider = null;
    [SerializeField]
    private Collider groundAttackCollider = null;

    private void Update() {
        if(Input.GetButtonDown("Attack") &&
            PlayerMovement.playerGroundState == PlayerGroundState.GROUNDED &&
            PlayerMovement.playerStanceState == PlayerStanceState.NORMAL) {
            Attack(groundAttackCollider);
        } else if(Input.GetButtonDown("Attack") &&
            PlayerMovement.playerGroundState == PlayerGroundState.AIRBORNE &&
            PlayerMovement.playerStanceState == PlayerStanceState.JUMPING) {
            Attack(aerialAttackCollider);
        }
    }

    /// <summary>
    /// Attacks everything that's inside the collider.
    /// </summary>
    /// <param name="collider">The collider that needs to look if it hit something hittable.</param>
    private void Attack(Collider collider) {
        var cols = Physics.OverlapSphere(collider.bounds.center,
            collider.bounds.extents.x,
            LayerMask.GetMask("Hittable"));

        foreach (Collider c in cols) {
            //TODO: Deal damage to the Health script of the collider hit.
        }
    }
}
