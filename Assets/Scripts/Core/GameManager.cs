using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int maxCatCount = 100;
    public bool isGameOver;
    public int catCount;

    [SerializeField] TextMeshProUGUI catCounter;

    private void Awake()
    {
        catCount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        catCount = GameObject.FindGameObjectsWithTag("Cat").Length;
        catCounter.text = $"Cat Count: {catCount}";
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
