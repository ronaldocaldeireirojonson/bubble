using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipAnimation : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(2);
    }
}
