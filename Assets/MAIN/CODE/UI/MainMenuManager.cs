using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] Buttons;
    List<Animator> ButtonsAnimators;
    private int index = 0;

    private void Start()
    {
        ButtonsAnimators = new List<Animator>();
        foreach(var b in Buttons)
        {
            ButtonsAnimators.Add(b.GetComponent<Animator>());
        }

        for(int i = 0; i < ButtonsAnimators.Count; i++)
        {
            if(i == 0)
            {
                ButtonsAnimators[0].Play("Idle");
            }
            else
            {
                ButtonsAnimators[i].Play("Hide");
            }
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveToRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveToLeft();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space");
            Buttons[index].GetComponent<MainMenuButton>().Select();
        }
    }

    public void MoveToLeft()
{
if(index > 0){
	ButtonsAnimators[index].Play("HideToRight");
            ButtonsAnimators[index - 1].Play("ShowFromLeft");
            index--;
}
}

public void MoveToRight()
{
if(index < Buttons.Length - 1){
	ButtonsAnimators[index].Play("HideToLeft");
            ButtonsAnimators[index + 1].Play("ShowFromRight");
            index++;
}
}

    public void OpenLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("Game is exiting...");
    }
}
