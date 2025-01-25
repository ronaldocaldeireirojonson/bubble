using UnityEngine;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using Unity.Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
	public GameObject playerPrefab;

	public Dictionary<int, AirConsoleInput> players = new Dictionary<int, AirConsoleInput>();

	public CinemachineTargetGroup targetGroup;
	public Transform targetBubble;

	const float radious = 0.5f;
	const float width = 1f;

	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onReady += OnReady;
		AirConsole.instance.onConnect += OnConnect;
	}

	void OnReady(string code)
	{
		//Since people might be coming to the game from the AirConsole store once the game is live, 
		//I have to check for already connected devices here and cannot rely only on the OnConnect event 
		List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
		foreach (int deviceID in connectedDevices)
		{
			AddNewPlayer(deviceID);
		}
	}

	[ContextMenu("TestSpawn")]
	void TestSpawn()
    {
		AddNewPlayer(10);

	}

	private void AddNewPlayer(int deviceID)
	{
		if (players.ContainsKey(deviceID))
		{
			return;
		}

		//Instantiate player prefab, store device id + player script in a dictionary
		GameObject newPlayer = Instantiate(playerPrefab, transform.position, transform.rotation) as GameObject;
		players.Add(deviceID, newPlayer.GetComponent<AirConsoleInput>());

		targetGroup.AddMember(newPlayer.transform, radious, width);
	}

	void OnConnect(int device)
	{
		AddNewPlayer(device);
	}

	void OnMessage(int from, JToken data)
	{
		//Debug.Log("Device: " + from);
		//Debug.Log("message: " + data);
		/*
		//When I get a message, I check if it's from any of the devices stored in my device Id dictionary
		if (players.ContainsKey(from) && data["action"] != null)
		{
			//I forward the command to the relevant player script, assigned by device ID
			players[from].ButtonInput(data["action"].ToString());
		}*/

		if (data["element"] == null || data["data"] == null)
			return;

		string element = (string)data["element"];
		string key = (string)data["data"]["key"];
		bool pressed = (bool)data["data"]["pressed"];

		//When I get a message, I check if it's from any of the devices stored in my device Id dictionary
		if (players.ContainsKey(from))
		{
			if (element == "button")
			{
				players[from].ButtonInput(element, pressed);
			} else if (element == "dpad" && key!= null)
            {
				players[from].ButtonInput(key, pressed);
			}
		}
	}
}
