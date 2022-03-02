using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSIndependent : MonoBehaviour
{
    [SerializeField] GameObject car;
    Collider touchedCollider;
    float speed = 2f;
    bool touched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Switcher"))
        {
            Debug.Log("I touched a switcher");
            car = other.transform.parent.gameObject;

            if (car.transform.position.x != other.transform.localPosition.x)
            {
                //car.transform.Translate(other.transform.localPosition.x, 0 , 0);
                touchedCollider = other;
                touched = true;
            }
            else
            {
                touched = false;
            }


        }
    }


    

    private void Update()
    {
        if (touched && car.transform.position.x >= -2.75 && car.transform.position.x <= 2.75)
        {
            Vector3 move = new Vector3(touchedCollider.transform.localPosition.x, 0, 0);

            car.transform.Translate(move * speed * Time.deltaTime);
        }




  
    }
}
