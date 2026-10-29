using UnityEngine;
using UnityEngine.InputSystem;
public class HandAnimation : MonoBehaviour
{
    public InputActionProperty TriggerValue;
    public InputActionProperty GripValue;
    public Animator HandAnimator;
    void Start()
    {
        
    }

    void Update()
    {
        float Trigger = TriggerValue.action.ReadValue<float>();
        float Grip = GripValue.action.ReadValue<float>();
        HandAnimator.SetFloat("Trigger", Trigger);
        HandAnimator.SetFloat("Grip", Grip);
    }
}
