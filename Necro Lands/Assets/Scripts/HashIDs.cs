using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

    public int speedFloat;
    public int shootState;
    public int shootingBool;
    public int deadBool;
    public int dyingState;
    public int attackBool;

	void Awake()
    {
        speedFloat = Animator.StringToHash("Speed");
        shootState = Animator.StringToHash("Shooting.Shoot");
        shootingBool = Animator.StringToHash("Shooting");
        deadBool = Animator.StringToHash("Dead");
        dyingState = Animator.StringToHash("Base Layer.Dying");
        attackBool = Animator.StringToHash("Attack");
    }
}
