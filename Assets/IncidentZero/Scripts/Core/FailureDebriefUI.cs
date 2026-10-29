
using UnityEngine;

public class FailureDebriefUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IncidentStateMachine incident;
    [SerializeField] private GameObject debriefCanvas;

    private bool hasShownDebrief;

    private void Start()
    {
        if (incident == null || debriefCanvas == null)
        {
            Debug.LogError(
                "FailureDebriefUI: Assign all references.",
                this
            );

            enabled = false;
            return;
        }

        debriefCanvas.SetActive(false);
    }

    private void Update()
    {
        if (hasShownDebrief)
            return;

        if (incident.CurrentState ==
            IncidentStateMachine.IncidentState.Failed)
        {
            debriefCanvas.SetActive(true);
            hasShownDebrief = true;

            Debug.Log("Failure debrief displayed.");
        }
    }
}
