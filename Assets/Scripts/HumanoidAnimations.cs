using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimations : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void TriggerlandingAnimation(){
        animator.SetTrigger("Land");
    }

    public void ResetTriggerlandingAnimation(){
        animator.ResetTrigger("Land");
    }

    public void TriggerJumpAnimation(){
        animator.SetTrigger("Jump");
    }

    public void SetMovementFloat(float value){
        animator.SetFloat("Move", value);
    }

    public void TriggerFallAnimation(){
        animator.SetTrigger("Fall");
    }

    public float SetCorrectAnimation(float desiredRotationAngle, int angleThreshold, int inputVerticalDirection){
        float currentAnimationSpeed = animator.GetFloat("Move");
        if(desiredRotationAngle > angleThreshold || desiredRotationAngle < -angleThreshold){
            if(Mathf.Abs(currentAnimationSpeed) < 0.2f){
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, -0.2f, 0.2f);
            }
            SetMovementFloat(currentAnimationSpeed);
        } else {
            if(currentAnimationSpeed < 1){
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
            }
            SetMovementFloat(Mathf.Clamp(currentAnimationSpeed, -1, 1));
        }
        return Mathf.Abs(currentAnimationSpeed);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
