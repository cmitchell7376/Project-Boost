using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip sucessSound;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning){return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This object is Friendly.");
                break;
            case "Finish":
                SucessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void SucessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(sucessSound);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadLevel", delayInSeconds);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayInSeconds);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentSceneIndex + 1;

        if(nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }

        SceneManager.LoadScene(nextLevel);

    }
}
