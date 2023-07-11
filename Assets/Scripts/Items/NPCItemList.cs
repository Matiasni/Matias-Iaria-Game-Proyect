using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCList", menuName = "ScriptableObjects/NPCItemList", order = 1)]
public class NPCItemList : ScriptableObject
{
    public List<Item> ItemsToSell = new List<Item>();
}