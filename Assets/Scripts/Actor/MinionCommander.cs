﻿using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MinionManager))]
public class MinionCommander : Action 
{
    public InputActions.Actions moveToLocationAction;
    public InputActions.Actions returnHomeAction;

    public GameObject waypoint;
    private Transform currentWaypoint;

    private MinionManager manager;
    private CommandCursor cursor;

    void Start()
    {
        manager = GetComponent<MinionManager>();
        cursor = CommandCursor.instance;
    }

    protected override void Execute(InputActions actions)
    {
        if (GetActionInvoke(moveToLocationAction, actions))
        {
            if (manager.followingMinions.Count > 0)
            {
                Minion skel = manager.followingMinions[0];
                skel.RecieveTarget(cursor.transform);
                manager.followingMinions.Remove(skel);
            }
            cursor.animator.SetTrigger("leftClick");
        }

        if (GetActionInvoke(returnHomeAction, actions))
        {
            for (int i = 0; i < manager.activeMinions.Count; i++)
            {
                manager.activeMinions[i].RecieveTarget(transform);
            }
            manager.followingMinions = new List<Minion>();
            for(int i = 0; i < manager.activeMinions.Count; i++)
            {
                manager.followingMinions.Add(manager.activeMinions[i]);
            }
            cursor.animator.SetTrigger("rightClick");
        }
    }
}

public class WaypointQueue
{
    private List<Transform> waypoints = new List<Transform>();
    private List<Minion> referenceList;

    public Transform this[int index]
    {
        get
        {
            return waypoints[index];
        }
    }

    public WaypointQueue(List<Minion> list)
    {
        referenceList = list;
    }

    public void Add(Transform transform)
    {
        waypoints.Add(transform);

        if (waypoints.Count > referenceList.Count)
        {
            waypoints.RemoveAt(0);
            Object.Destroy(waypoints[0].gameObject);
        }
    }

    public void Remove(Transform transform)
    {
        waypoints.Remove(transform);
    }
}
