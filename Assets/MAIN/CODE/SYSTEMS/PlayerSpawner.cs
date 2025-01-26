using UnityEngine;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using Unity.Cinemachine;
using System;

public class PlayerSpawner : MonoBehaviour
{

	[Header("Settings")]
	public SOPlayerSkins playerSkins;


	[Header("References")]

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

    private void OnDestroy()
    {
		AirConsole.instance.onMessage -= OnMessage;
		AirConsole.instance.onReady -= OnReady;
		AirConsole.instance.onConnect -= OnConnect;
	}

    private void Start()
    {
		PrepareTargetGroup();
		SpawnConnectedPlayers();
	}

    private void SpawnConnectedPlayers()
    {
		Debug.LogError("SpawnConnectedPlayers");
		//Since people might be coming to the game from the AirConsole store once the game is live, 
		//I have to check for already connected devices here and cannot rely only on the OnConnect event 
		List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
		foreach (int deviceID in connectedDevices)
		{

			Debug.LogError("SpawnConnectedPlayers " + deviceID);
			AddNewPlayer(deviceID);
		}
	}

    void PrepareTargetGroup()
    {
        for (int i = targetGroup.Targets.Count-1; i >=0 ; i--)
        {
            CinemachineTargetGroup.Target item = targetGroup.Targets[i];

			if(item != null)
	            targetGroup.RemoveMember(item.Object);
		}

		targetGroup.AddMember(targetBubble, radious, width);

	}

	void OnReady(string code)
	{

		SpawnConnectedPlayers();
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

		int id = deviceID % playerSkins.SkinsCount;

		newPlayer.GetComponent<SkinApplier>().ApplyMaterial(playerSkins.playerSkins[id].material);

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
			if (element == "button" || element == "btn_reset")
			{
				players[from].ButtonInput(element, pressed);
			} else if (element == "dpad" && key!= null)
            {
				players[from].ButtonInput(key, pressed);
			}
		}
	}
}
