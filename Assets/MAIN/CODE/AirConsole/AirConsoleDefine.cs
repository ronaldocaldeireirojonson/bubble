using UnityEngine;

public class AirConsoleDefine : MonoBehaviour
{
    [SerializeField] bool usesAirConsole;


    private void Awake()
    {
#if AIRCONSOLE
    
        gameObject.SetActive(usesAirConsole);
#else
        gameObject.SetActive(!usesAirConsole);
#endif
    }
}
