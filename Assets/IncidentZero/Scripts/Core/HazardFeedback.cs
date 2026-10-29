
using UnityEngine;

public class HazardFeedback : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IncidentStateMachine incident;
    [SerializeField] private Light alarmLight;
    [SerializeField] private GameObject alarmMessageCanvas;

    [Header("Audio")]
    [SerializeField] private AudioSource motorAudio;
    [SerializeField] private AudioSource alarmAudio;
    [SerializeField] private AudioSource inputErrorAudio;

    private bool previousMotorOn;
    private IncidentStateMachine.IncidentState previousState;

    private void Start()
    {
        if (incident == null || alarmLight == null ||
            alarmMessageCanvas == null || motorAudio == null ||
            alarmAudio == null || inputErrorAudio == null)
        {
            Debug.LogError(
                "HazardFeedback: Assign all references in the Inspector.",
                this
            );
            enabled = false;
            return;
        }

        alarmLight.enabled = false;
        alarmMessageCanvas.SetActive(false);
        alarmAudio.Stop();

        previousMotorOn = false;
        previousState = incident.CurrentState;
    }

    private void Update()
    {
        bool motorIsOn = incident.GetComponent<MotorValveSystem>().MotorOn;

        bool alarmIsActive =
            incident.CurrentState ==
            IncidentStateMachine.IncidentState.AlarmActive;

        // Visual warning feedback
        alarmLight.enabled = alarmIsActive;
        alarmMessageCanvas.SetActive(alarmIsActive);

        // Motor ON sound: play once when the motor turns on
        if (motorIsOn && !previousMotorOn)
        {
            motorAudio.Play();
        }

        // Stop the motor sound when the motor turns off
        if (!motorIsOn && previousMotorOn)
        {
            motorAudio.Stop();
        }

        previousMotorOn = motorIsOn;

        // Alarm loops only while the alarm state is active
        if (alarmIsActive && !alarmAudio.isPlaying)
        {
            alarmAudio.Play();
        }
        else if (!alarmIsActive && alarmAudio.isPlaying)
        {
            alarmAudio.Stop();
        }

        // Input error sound plays once when the incident fails
        if (incident.CurrentState ==
                IncidentStateMachine.IncidentState.Failed &&
            previousState !=
                IncidentStateMachine.IncidentState.Failed)
        {
            inputErrorAudio.PlayOneShot(inputErrorAudio.clip);
        }

        previousState = incident.CurrentState;
    }
}
