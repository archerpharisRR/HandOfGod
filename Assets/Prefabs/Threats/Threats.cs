using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Threats : MonoBehaviour
{
    internal static Action OnDestroyed;

    public abstract void Init();

}
