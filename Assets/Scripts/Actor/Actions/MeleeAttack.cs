﻿using UnityEngine;
using System.Collections;

public class MeleeAttack : Action
{
    public InputActions.Actions attackAction;
    public float attackInterval;
    private float currentInterval;

    protected override void Execute(InputActions actions)
    {
        if(GetActionInvoke(attackAction, actions))
        {
            if (actions.target != null)
            {
                Attack(actions.target.GetComponent<Actor>(), actions.stats.strength);
            }
        }
    }

    void Attack(Actor target, float damage)
    {
        if (currentInterval > 0)
        {
            currentInterval -= Time.deltaTime;
        }
        else
        {
            target.RecieveDamage(transform, damage);
            currentInterval = attackInterval;
        }
    }

}
