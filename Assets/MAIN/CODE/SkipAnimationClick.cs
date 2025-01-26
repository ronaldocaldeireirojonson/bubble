using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipAnimationClick : MonoBehaviour
{
    void Update()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
