﻿using UnityEngine;
using System.Collections.Generic;

public class Necromancer : Actor 
{
    private PlayerActions input;
    public static Necromancer instance;

    protected override void InitializeOnAwake()
    {
        base.InitializeOnAwake();
        
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        input = PlayerActions.BindAll();
    }

    void Update()
    {
        UpdateInput();
    }

    void UpdateInput()
    {
        actions.primaryDirection = input.Move.Value;
        actions.secondaryDirection = Input.mousePosition;

        actions.primaryAction = input.RaiseSkeleton.WasPressed;
        actions.secondaryAction = input.Command.WasPressed;
        actions.tertiaryAction = input.CallSkeletons.WasPressed;
        bus.Action(actions);
        UpdateAnimation(actions);
    }
}
