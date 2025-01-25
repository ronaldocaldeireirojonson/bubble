using UnityEngine;
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

    public void SolveKey(int index)
    {
        keys[index].state = true;

        for(int i = 0; i < puzzles.Length; i++)
        {
            bool solved = true;

            for(int j = 0; j < puzzles[i].keys.Length; j++)
            {
                if(puzzles[i].isSolved) continue;

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

}
