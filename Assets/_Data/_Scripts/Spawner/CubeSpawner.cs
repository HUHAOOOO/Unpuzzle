using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : Spawner
{
    private static CubeSpawner instance;
    public static CubeSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (CubeSpawner.instance != null) Debug.LogError("Only 1 CubeSpawner  allow to exist");
        CubeSpawner.instance = this;
    }
}
