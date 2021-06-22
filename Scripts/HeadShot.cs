using System;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public event Action OnHitHead = delegate { };

    public void HitInHead()
    {
        OnHitHead();
    }
}
