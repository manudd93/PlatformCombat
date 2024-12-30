using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Oggetto Istantaneo", menuName = "Oggetto Istantaneo")]
public class IDistantItem : ScriptableObject
{
    public int ID;
    public string Message;
    public int Duration;

    public string Description;
    public string Name;
    public int value;

    public int ChanceSpawn;

    public AudioClip SFXSound;

}