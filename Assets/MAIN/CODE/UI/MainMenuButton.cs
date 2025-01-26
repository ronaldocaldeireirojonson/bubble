using UnityEngine;
using UnityEngine.Events;

public class MainMenuButton : MonoBehaviour
{
    public UnityEvent OnSelected;

    public void Select()
    {
        OnSelected.Invoke();
    }
}
