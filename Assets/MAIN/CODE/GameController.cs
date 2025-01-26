using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

[Serializable]
public class Puzzle
{
    public int[] keys;
    public UnityEvent onSolvedEvent;
    public bool isSolved = false;
}

[Serializable]
public class PuzzleKey
{
    public string name;
    public bool state;
}

public class GameController : MonoBehaviour
{
    public Puzzle[] puzzles;
    public PuzzleKey[] keys;

    void Awake()
    {
        UnityEngine.Object[] allObjects = Resources.FindObjectsOfTypeAll<UnityEngine.Object>();
        foreach (UnityEngine.Object obj in allObjects)
        {
            if ((obj.hideFlags & HideFlags.DontSave) != 0)
            {
                Debug.Log($"DontSave Asset: {obj.name}, Type: {obj.GetType()}");
            }
        }
    }

    public void SolveKey(int index)
    {
        keys[index].state = true;

        for(int i = 0; i < puzzles.Length; i++)
        {
            bool solved = true;
            Debug.Log("INDEX " + index);

            for(int j = 0; j < puzzles[i].keys.Length; j++)
            {
                if(puzzles[i].isSolved) continue;

                Debug.Log("J " + j);
                if(!keys[puzzles[i].keys[j]].state)
                {
                    solved = false;
                    break;
                }
            }

            if(solved)
            {
                puzzles[i].isSolved = true;
                puzzles[i].onSolvedEvent.Invoke();
            }    
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(3);
    }
}
