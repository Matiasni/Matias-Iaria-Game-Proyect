using UnityEngine;

public class SpawnEquipItem : MonoBehaviour
{
    public CharacterAnimationController SpawnItem(string itemId)
    {
        var loadedPrefab = Resources.Load<CharacterAnimationController>("Prefab/"+ itemId);
        var instantiatedPrefab = Instantiate(loadedPrefab, this.transform);

        return instantiatedPrefab;
    }
}