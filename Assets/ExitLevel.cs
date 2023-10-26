using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float levelExitSlowMotionFactor = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        int numberOfScenesInBuildSettings = SceneManager.sceneCountInBuildSettings;
        Time.timeScale = levelExitSlowMotionFactor;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentSceneIndex + 1) % numberOfScenesInBuildSettings);
    }
}
