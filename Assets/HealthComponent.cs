using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnHealthChanged(float newValue, float oldValue, float maxValue, GameObject Causer);
public delegate void OnNoHealthLeft(GameObject killer);

public class HealthComponent : MonoBehaviour
{
    public float HitPoints = 10;
    [SerializeField] float MaxHitPoints = 10;
    [SerializeField] LayerMask damagableLayerMask;

    public OnHealthChanged onHealthChanged;
    public OnNoHealthLeft noHealthLeft;

    public float GetHealth()
    {
        return HitPoints;
    }

    public void ChangeHealth(float changeAmount, GameObject Causer = null)
    {
        if (changeAmount < 0 && HitPoints == 0)
        {
            return;
        }
        float oldValue = HitPoints;
        HitPoints += changeAmount;
        HitPoints = Mathf.Clamp(HitPoints, 0f, MaxHitPoints);
        if (HitPoints == 0)
        {
            if (noHealthLeft != null)
            {
                noHealthLeft.Invoke(Causer);
            }
        }
        if (onHealthChanged != null)
        {
            onHealthChanged.Invoke(HitPoints, oldValue, MaxHitPoints, Causer);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        int otherLayer = other.gameObject.layer;
        int layerMaskData = damagableLayerMask.value;

        //bool touchedEnemy = Physics.CheckCapsule(transform.position)

        Debug.Log($"checking layer{1 << otherLayer} with {layerMaskData}");

        if ((layerMaskData&(1<<otherLayer))!=0)
        {
            Debug.Log("Can damage");
        }

    }

    public void BroadCastCurrentHealth()
    {
        onHealthChanged.Invoke(HitPoints, HitPoints, MaxHitPoints, gameObject);
    }
}