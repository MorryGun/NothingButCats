using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingController : MonoBehaviour
{
    [SerializeField] GameObject catPrefab;

    int minOffspringSize = 3;
    int maxOffspringSize = 6;

    int minSpawnPos = 0;
    int maxSpawnPos = 10;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void Breed(Cat cat1, Cat cat2)
    {
        int offspringSize = Random.Range(minOffspringSize, maxOffspringSize);

        if (gameManager.catCount + offspringSize < gameManager.maxCatCount)
        {
            for (int i = 0; i < offspringSize; i++)
            {
                Instantiate(catPrefab, GetSpawnPosition(), Quaternion.identity);
            }
        }
        else 
        {
            gameManager.GameOver();
        }

        Debug.Log($"Spawned {offspringSize} cats!");
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 pos;

        do
        {
            pos = new Vector2(Random.Range(minSpawnPos, maxSpawnPos), Random.Range(minSpawnPos, maxSpawnPos));

        } while (Physics2D.OverlapCapsule(pos, catPrefab.transform.localScale, CapsuleDirection2D.Vertical, 90) != null);

        return pos;
    }
}
