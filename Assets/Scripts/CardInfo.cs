using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new card", menuName = "Character")]
public class CardInfo : ScriptableObject
{
    public Sprite img;
    public string name;
    public string dial;
    public int ID;
}
