using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJump : MonoBehaviour
{
    public void Start()
    {
        transform.LeanMoveLocal(new Vector2(-210,-100), 1).setEaseOutQuart().setLoopPingPong();
    }
}
