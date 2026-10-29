
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public void RestartScene()
    {
        int currentSceneIndex =
            SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex < 0)
        {
            Debug.LogError(
                "Current scene is not included in the build scene list."
            );
            return;
        }

        SceneManager.LoadScene(currentSceneIndex);
    }
}
