using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainMenu", 3f);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
