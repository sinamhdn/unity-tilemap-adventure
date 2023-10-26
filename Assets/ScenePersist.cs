using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (startingSceneIndex != currentSceneIndex)
        {
            Destroy(gameObject);
        }
    }

    // Making this class a singleton that destroys all other instances when a instance is created
    // there are also other methods to implement singleton pattern
    // default methods are private so you can remove private
    void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
