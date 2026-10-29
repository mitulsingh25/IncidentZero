using UnityEngine;

public class MotorValveSystem : MonoBehaviour
{
    public bool MotorOn { get; private set; } = false;
    public bool Department1 { get; private set; } = false;
    public bool Department2 { get; private set; } = false;
    public bool Department3 { get; private set; } = false;
  
    
    public void SetMotorOn()
    {
        MotorOn = true;
        Debug.Log("Motor is now: ON!");
    }
    public void SetMotorOff()
    {
        MotorOn = false;
        Debug.Log("Motor is now: OFF!");
    }
    public void ToggleValve(int ValveIndex)
    {
        switch (ValveIndex)
        {
            case 0:
                Department1 = !Department1;
                Debug.Log("Department 1 is now: " + Department1);
                break;
            case 1:
                Department2 = !Department2;
                Debug.Log("Department 2 is now: " + Department2);
                break;
            case 2:
                Department3 = !Department3;
                Debug.Log("Department 3 is now: " + Department3);
                break;
        }

    }
}
