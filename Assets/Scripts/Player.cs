using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class Player : NetworkBehaviour
{
    [Networked]
    public byte myByte { get; set; }

    private NetworkCharacterController _cc;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            _cc.Move(5 * data.direction * Runner.DeltaTime);
        }
    }
}
