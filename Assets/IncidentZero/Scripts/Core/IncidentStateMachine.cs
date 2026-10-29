
using UnityEngine;

public class IncidentStateMachine : MonoBehaviour
{
    public enum IncidentState
    {
        Idle,
        MotorOn_NoValve,
        AlarmActive,
        Contained,
        Failed,
        Debrief
    }

    [Header("References")]
    [SerializeField] private MotorValveSystem controls;

    [Header("Timing")]
    [SerializeField] private float totalDeadline = 10f;
    [SerializeField] private float pressureBuildTime = 2f;

    public IncidentState CurrentState { get; private set; }
        = IncidentState.Idle;

    public float TimeRemaining { get; private set; }
    public bool TaskCompleted { get; private set; }

    private float elapsedTime;

    private void Start()
    {
        if (controls == null)
        {
            Debug.LogError(
                "Assign MotorValveSystem in the Inspector.",
                this
            );

            enabled = false;
            return;
        }

        TimeRemaining = totalDeadline;
        Debug.Log("Incident state: " + CurrentState);
    }

    private void Update()
    {
        // Finished incidents cannot change state accidentally.
        if (CurrentState == IncidentState.Contained ||
            CurrentState == IncidentState.Failed ||
            CurrentState == IncidentState.Debrief)
        {
            return;
        }

        // Cancel an active incident if the motor is switched off.
        if (CurrentState != IncidentState.Idle && !controls.MotorOn)
        {
            elapsedTime = 0f;
            TimeRemaining = totalDeadline;
            TaskCompleted = false;

            ChangeState(IncidentState.Idle);
            return;
        }

        bool anyValveOpen =
            controls.Department1 ||
            controls.Department2 ||
            controls.Department3;

        // Begin the incident only when the motor runs with every valve closed.
        if (CurrentState == IncidentState.Idle)
        {
            if (!controls.MotorOn || anyValveOpen)
                return;

            elapsedTime = 0f;
            TimeRemaining = totalDeadline;
            TaskCompleted = false;

            ChangeState(IncidentState.MotorOn_NoValve);
        }

        
        // Advance the timer BEFORE checking the thresholds.
        elapsedTime += Time.deltaTime;
        TimeRemaining = Mathf.Max(0f, totalDeadline - elapsedTime);

        // NEW: Enter AlarmActive after the pressure-build time.
        // This check must happen before the timeout check.
        if (elapsedTime >= pressureBuildTime &&
            CurrentState == IncidentState.MotorOn_NoValve)
        {
            ChangeState(IncidentState.AlarmActive);
        }

        // Timeout: fail if the total deadline has expired.
        if (elapsedTime >= totalDeadline)
        {
            ChangeState(IncidentState.Failed);
            Debug.Log("Outcome: FAILURE - Pressure deadline expired.");
            return;
        }

        // Any open valve contains pressure, but only Dept 2 completes the task.
        if (anyValveOpen)
        {
            TaskCompleted = controls.Department2;

            ChangeState(IncidentState.Contained);

            Debug.Log(TaskCompleted
                ? "Outcome: CONTAINED - Correct department."
                : "Outcome: PRESSURE CONTAINED - Wrong department.");

            return;
        }
    }

    private void ChangeState(IncidentState newState)
    {
        if (CurrentState == newState)
            return;

        CurrentState = newState;
        Debug.Log("Incident state: " + CurrentState);
    }
}
