using UnityEngine;

public class AinConsoleHelper : MonoBehaviour
{
    public GameObject[] airConsoleObjects;
    public GameObject[] otherObjects;

    public bool usingAirConsole;

    private void Awake()
    {
#if AIRCONSOLE
        usingAirConsole = true;
#endif


        foreach (var item in airConsoleObjects)
        {
            item.SetActive(usingAirConsole);
        }

        foreach (var item in otherObjects)
        {
            item.SetActive(!usingAirConsole);
        }
    }
}
