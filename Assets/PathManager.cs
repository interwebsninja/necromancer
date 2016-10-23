﻿using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
public class PathManager : MonoBehaviour
{
    private GraphNode previousNode;

    private Transform target;

    public CalculatedPath currentPath;

    private Seeker seeker;

    void Awake()
    {
        seeker = GetComponent<Seeker>();
        currentPath = new CalculatedPath();
    }

    void Update()
    {
        GraphNode node = AstarPath.active.GetNearest(target.position).node;

        if(node != previousNode)
        {
            CalculatePath(target);
            previousNode = node;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        CalculatePath(target);
    }

    public void CalculatePath(Transform target)
    {
        Path newPath = seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            currentPath.path = p;
            currentPath.newPath = true;

        }
        else
        {
            Debug.LogError(p.errorLog);
        }
    }
}

public class CalculatedPath
{
    public Path path;
    public bool newPath;

}
