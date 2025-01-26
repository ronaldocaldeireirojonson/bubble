using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AirConsoleUIController : MonoBehaviour
{
	[Header("References")]
	public MainMenuManager mainMenuManager;

    private void OnEnable()
    {
		AirConsole.instance.onMessage += OnMessage;
	}

    private void OnDisable()
    {
		AirConsole.instance.onMessage -= OnMessage;
	}


	void OnMessage(int from, JToken data)
	{
		if (data["element"] == null || data["data"] == null)
			return;

		string element = (string)data["element"];
		string key = (string)data["data"]["key"];
		bool pressed = (bool)data["data"]["pressed"];


		if (element == "button" || element == "btn_reset")
		{
			mainMenuManager.ConfirmButton();
		}
		else if (element == "dpad" && pressed)
		{
            if (key == "left")
            {
				mainMenuManager.MoveToLeft();
			}
			else if(key == "right")
            {
				mainMenuManager.MoveToRight();
			}
		}

	}
}
