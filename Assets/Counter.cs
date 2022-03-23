using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Counter : MonoBehaviour
{
    TextMeshProUGUI tmpGUI;
    [SerializeField] float timer = 0;
    [SerializeField] float climbSpeed = 1f;

    private void Start()
    {
        tmpGUI = GetComponent<TextMeshProUGUI>();
        //tmpGUI.text = timer.ToString();
    }

    private void Update()
    {
        timer += climbSpeed * Time.deltaTime;
        tmpGUI.text = timer.ToString("F0");
    }

}
