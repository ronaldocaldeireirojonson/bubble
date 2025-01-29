using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // The name of the main menu scene you want to load
    public string mainMenuSceneName = "Menu";

    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        // Check for any button press (or mouse click)
        if (Input.anyKeyDown)
        {
            //LoadMainMenu();
        }
    }

    // Function to load the main menu scene
    public void LoadMainMenu()
    {
        StartCoroutine(LoadMenu(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadMenu (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}