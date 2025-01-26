using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipAnimationClick : MonoBehaviour
{
    public int loadScene = 2;
    void Update()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            SceneManager.LoadScene(loadScene);
        }
    }
}
