using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walkman : MonoBehaviour
{
    public float health = 100;
    [SerializeField] float regenSpeed;
    [SerializeField] Slider slider;
    ParticleSystem explosion;


    private void Start()
    {

    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, 100);
        slider.value = health;
        if (health < 100)
        {
            health += regenSpeed * Time.deltaTime;
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Car_01")
        {
            Car car = other.GetComponentInParent<Car>();
            MeshRenderer mr = other.GetComponent<MeshRenderer>();
            explosion = other.GetComponentInChildren<ParticleSystem>();
            float damageDone = car.DamageDealt();
            DealDamage(damageDone);
            explosion.Play();
            mr.enabled = false;
            Destroy(other.gameObject, 0.5f);

        }
    }
}
