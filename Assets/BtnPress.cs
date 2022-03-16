using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPress : MonoBehaviour
{
    int clicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        clicked += 1;
        Debug.Log("clicked " + clicked + " times");
        
    }
}
