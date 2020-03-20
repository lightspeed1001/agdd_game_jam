using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ITriggerable : MonoBehaviour
{
    public abstract void Trigger();
}
