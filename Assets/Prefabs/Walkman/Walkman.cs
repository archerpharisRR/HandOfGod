using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walkman : MonoBehaviour
{
    [SerializeField] float health = 100;
    public float regenSpeed;
    [SerializeField] Slider slider;
    [SerializeField] Image healtImage;
    ParticleSystem explosion;
    Animator animator;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            Debug.Log("Health set by something else");
        }
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, 1000);
        slider.value = health;
        if (health < 1000)
        {
            health += regenSpeed * Time.deltaTime;
        }

        if (health <= 10)
        {
            Debug.Log("it should trigger");
            animator.SetTrigger("Die");
            healtImage.enabled = false;
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
        if(other.name == "Rock Type2 04(Clone)")
        {
            Meteor meteor = other.GetComponentInParent<Meteor>();
            MeshRenderer mr = other.GetComponent<MeshRenderer>();
            explosion = other.GetComponentInChildren<ParticleSystem>();
            float damageDone = meteor.DamageDealt();
            DealDamage(damageDone);
            explosion.Play();
            mr.enabled = false;
            Destroy(other.gameObject, 0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Clouds_Cumulus_G1(Clone)")
        {
            Cloud cloud = other.GetComponent<Cloud>();
            float damageDone = cloud.DamageDealt();
            DealDamage(damageDone);
        }
        
    }
}
