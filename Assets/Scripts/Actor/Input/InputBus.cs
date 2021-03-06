﻿using UnityEngine;
using System.Collections;

public class InputBus : MonoBehaviour 
{
    public delegate void UpdateAction(InputActions actions);
    public UpdateAction Action;
}

 public class InputActions
{
    public Vector3 primaryDirection;
    public Vector3 secondaryDirection;

    public enum Actions
    {
        PrimaryDirection,
        PrimaryAction,
        SecondaryAction,
        SecondaryDirection,
        TertiaryAction
    }

    public bool primaryAction;
    public bool secondaryAction;
    public bool tertiaryAction;

    public ActorStats stats;

    public Transform target;
}