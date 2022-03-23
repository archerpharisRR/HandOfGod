using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] Walkman walkman;
    [SerializeField] GameObject gameOverUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(walkman.Health < 10)
        {
            Debug.Log("Walkman is dead.");
            walkman.regenSpeed = 0;
            Invoke("EnableGameOverUI", 2f);
            
        }


    }

    void EnableGameOverUI()
    {
        gameOverUI.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }
}
