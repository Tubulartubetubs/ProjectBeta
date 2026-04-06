using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject dropPrefab;
        public float dropChance; // Chance to drop (0-100)
    }

    public List<Drops> dropsList;

    private void OnDestroy()
    {
        float randomNumber = UnityEngine.Random.Range(0f, 100f);
        List<Drops> possibleDrops = new List<Drops>(dropsList);

        foreach (Drops rate in dropsList)
        {
            if (randomNumber <= rate.dropChance)
            {
                possibleDrops.Add(rate);
            }
        }
        if(possibleDrops.Count > 0)
        {
            Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.dropPrefab, transform.position, Quaternion.identity);
        }
    }
}
