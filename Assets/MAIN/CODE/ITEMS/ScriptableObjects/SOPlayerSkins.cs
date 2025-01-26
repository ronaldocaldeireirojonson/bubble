using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSkins : ScriptableObject
{
    public PlayerSkin[] playerSkins;

    public int SkinsCount
    {
        get => playerSkins.Length;
    }
}

[System.Serializable]
public class PlayerSkin
{
    public string name;
    public Material material;
    public Texture portrait;

}
