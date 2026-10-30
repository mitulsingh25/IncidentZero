# Incident Zero

A Unity XR industrial safety training prototype focused on incident prevention, hazard awareness, and decision-making under pressure.

## Demo Video

**YouTube Demo:** [Watch Incident Zero](https://youtu.be/K8JWkWq5Ct0)

> **Screenshots:** Add screenshots of the control room, active alarm state, and failure debrief to a `Screenshots/` folder, then embed them here to give visitors a quick look at the experience.

## What It Is

Incident Zero is a graybox-first industrial safety training prototype built in Unity. The player takes the role of a new trainee operating a shared water supply system inside a factory control room.

One motor supplies three departments, each controlled by its own valve. The intended procedure is to open Department 2's valve before starting the motor, or open it in time if the motor is already running.

If the motor runs while all three valves are closed, pressure builds. An alarm activates, a warning tells the trainee to open a valve, and the incident fails if the hazard is ignored.

After failure, a debrief explains what happened, highlights the missed cue **"OPEN A VALVE!"**, and presents the better procedure. The player can restart the incident by reloading the scene.

The project prioritizes functional mechanics, clear feedback, and a complete playable incident over environmental art and visual realism.

## What This Demonstrates

- **Unity and C#:** Implementing gameplay systems and coordinating components.
- **Finite state machines:** Managing incident phases, transitions, and terminal outcomes.
- **Interaction systems:** Connecting motor and valve controls to shared system state.
- **Hazard logic:** Simulating pressure escalation using simple, testable rules rather than fluid simulation.
- **State-driven feedback:** Connecting incident states to warning lights, on-screen messages, and audio.
- **XR-oriented UI:** Presenting contextual information within the control room.
- **Failure handling:** Showing a debrief and restarting the scenario through scene reload.
- **Iterative prototyping:** Building and testing core functionality in a graybox environment before presentation polish.

## Requirements & How to Run

### Requirements

- Unity **6.0**
- XR Interaction Toolkit and the project dependencies configured in the Unity project
- A compatible VR headset and XR runtime for VR testing
- A desktop setup may be used if desktop interaction is supported by the current project configuration

### Run Locally

1. Clone or download this repository.
2. Open Unity Hub.
3. Select **Add project from disk** and choose the cloned `IncidentZero` folder.
4. Open the project using **6.0**.
5. Open the main scene: **IncidentZero**.
6. Ensure the required XR runtime and input configuration are available for your target setup.
7. Press **Play** to run the scenario in the Unity Editor.

If you build a standalone version, ensure the main scene is included in the build scene list and configure the appropriate XR settings for the target platform.

## Controls

Controls depend on the active input configuration. The primary interactions are:

| Action | Purpose |
|---|---|
| Motor ON | Start the water motor |
| Motor OFF | Stop the water motor |
| Department 1 Valve | Open or close Department 1's valve |
| Department 2 Valve | Open or close Department 2's valve |
| Department 3 Valve | Open or close Department 3's valve |
| Interact with UI | Use the restart button after the incident ends |

The motor and valves control the incident logic. The warning light, alarm siren, and on-screen message communicate the active hazard.

## Folder Structure

The project uses a standard Unity project layout. Key scripts and assets are organized within `Assets/`.

```text
IncidentZero/
├── Assets/
│   ├── Scenes/
│   ├── Scripts/
│   ├── Audio/
│   └── ...
├── Packages/
├── ProjectSettings/
└── README.md
```

Folder names may differ depending on the final repository structure.

## Implemented vs. Planned

### Implemented

- Single control-room scenario
- One water motor with ON/OFF controls
- Three department valves
- Shared motor and valve state
- Pressure escalation when the motor runs with all valves closed
- Alarm state with warning light, siren, and on-screen cue
- Failure outcome when the pressure deadline expires
- Containment outcome when a valve is opened in time
- Failure debrief with missed cue and recommended procedure
- Restart flow using scene reload
- Motor, alarm, and input-error audio feedback

### Planned / Future Improvements

- More detailed industrial environment and visual polish
- Improved VR UI placement and readability
- Additional scenarios using reusable incident logic
- More comprehensive action logging and decision analysis
- Performance profiling and optimization based on measured results

These are potential extensions, not claims about features currently implemented.

## Tech Stack

- **Engine:** Unity — 6.0
- **Language:** C#
- **XR:** XR Interaction Toolkit
- **Interaction:** Unity XR interaction components and UI
- **Gameplay Architecture:** Finite state machine and component-based systems
- **Audio:** Unity AudioSource
- **Version Control:** Git and GitHub

## Author

**Mitul Singh**

- **GitHub:** [github.com/mitulsingh25](https://github.com/mitulsingh25)
- **LinkedIn:** [linkedin.com/in/mitul-singh-441178345](https://www.linkedin.com/in/mitul-singh-441178345/)
- **X:** [@mitulsingh25](https://x.com/mitulsingh25)

---

Incident Zero is a portfolio project exploring interactive safety training through clear system behavior, hazard feedback, and consequence-driven learning.
