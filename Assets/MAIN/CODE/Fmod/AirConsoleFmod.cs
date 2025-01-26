using NDream.AirConsole;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class AirConsoleFmod : MonoBehaviour
{

	public LoadBankAndScene loadBank;
	private void Awake()
	{
		// Register all the events I need
		//AirConsole.instance.onReady += OnAirConsoleReady;
		AirConsole.instance.onMessage += OnAirConsoleMessage;
		//AirConsole.instance.onPause += OnAirConsolePause;
		//AirConsole.instance.onResume += OnAirConsoleResume;

		/*
		// No device state can be set until AirConsole is ready, so I disable the buttons until then
		gameStateButtons = FindObjectsOfType<Button>();
		foreach (var t in gameStateButtons)
		{
			t.interactable = false;
		}
		*/
	}

	private void OnDestroy()
	{
		if (AirConsole.instance == null) return;

		// Unregister events
		//AirConsole.instance.onReady -= OnAirConsoleReady;
		AirConsole.instance.onMessage -= OnAirConsoleMessage;
		//AirConsole.instance.onPause -= OnAirConsolePause;
		//AirConsole.instance.onResume -= OnAirConsoleResume;
	}

	private void OnAirConsoleMessage(int deviceId, JToken message)
	{
		Debug.Log("Received message from device " + deviceId + ". content: " + message);

		if (message["element"] == null) return;

		//var action = message["action"].ToString();
		string element = (string)message["element"];


		if (element == "button")
		{
			Debug.LogError("OnAirConsoleMessage + button");

			loadBank.LoadBanks();
			//players[from].ButtonInput(element, pressed);
		}

		if (element == "btn_reset")
		{
			Debug.LogError("OnAirConsoleMessage + button");

			loadBank.LoadNextScene();
			//players[from].ButtonInput(element, pressed);
		}
	}
}
