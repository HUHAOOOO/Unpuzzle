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

    public override void Despawn(GameObject obj)
    {
        base.Despawn(obj);

        LevelManager.Instance.CubeCount -= 1;
        GameManager.Instance.MonkeyCount += 1;
    }
    public void DespawnCube_Gear(GameObject obj)
    {
        base.Despawn(obj);
    }
}
