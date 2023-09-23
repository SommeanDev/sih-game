using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJump1 : MonoBehaviour
{
    public void Start()
    {
        transform.LeanMoveLocal(new Vector2(0,-100), 1).setEaseOutQuart().setLoopPingPong();
    }
}
