using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayStatic
{
    static Walkman walkerMan;
    static Player player;
    static Earth earth;

    public static Walkman GetWalkMan()
    {
        if(walkerMan == null)
        {
            walkerMan = GameObject.FindObjectOfType<Walkman>();
        }
        return walkerMan;
    }

    public static Player GetPlayer()
    {
        if (walkerMan == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }
        return player;
    }

    public static Transform GetWalkmanTransform()
    {
        if (GetWalkMan())
        {
            return GetWalkMan().transform;
        }
        return null;
    }

    public static Earth GetEarth()
    {
        if(earth == null)
        {
            earth = GameObject.FindObjectOfType<Earth>();
        }
        return earth;
    }
}
