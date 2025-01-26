using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


using FMODUnity;
using FMOD.Studio;

public class LoadBankAndScene : MonoBehaviour
{
    [SerializeField]
    public string sceneName;

    [FMODUnity.BankRef]
    public List<string> banks;

    public Button ClickToLoadButton, ChangeSceneButton;
    public TMP_Text LoadingBanksText;

    EventInstance coolAudioEventInstance;

    private void Awake()
    {
        LoadingBanksText.gameObject.SetActive(false);
        ChangeSceneButton.interactable = false;
    }

    public void LoadBanks()
    {
        Debug.LogError(" Start Load Banks");

        foreach (string b in banks)
        {
            FMODUnity.RuntimeManager.LoadBank(b, true);
            Debug.Log("Loaded bank " + b);
        }
        /*
            For Chrome / Safari browsers / WebGL.  Reset audio on response to user interaction (LoadBanks is called from a button press), to allow audio to be heard.
        */
        FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
        FMODUnity.RuntimeManager.CoreSystem.mixerResume();

        LoadingBanksText.gameObject.SetActive(true);
        StartCoroutine(CheckBanksLoaded());
    }

    IEnumerator CheckBanksLoaded()
    {
        while (!FMODUnity.RuntimeManager.HaveAllBanksLoaded)
        {
            yield return null;
        }

        LoadingBanksText.text = "Banks Loaded";
        LoadingBanksText.color = Color.green;
        ChangeSceneButton.interactable = true;

        Debug.LogError(" End Load Banks");

        LoadNextScene(); // delete this
    }

    public void LoadNextScene()
    {
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        string coolAudioReferenceString = "event:/musics/menu_music";

        coolAudioEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

         coolAudioEventInstance = RuntimeManager.CreateInstance(coolAudioReferenceString);
        coolAudioEventInstance.start();
    }
}
