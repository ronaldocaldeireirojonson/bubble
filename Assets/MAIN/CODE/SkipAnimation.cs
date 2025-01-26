using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipAnimation : MonoBehaviour
{
    public int sceneToLoad = 2;
    void OnEnable()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
