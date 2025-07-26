using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 10f;
    [SerializeField] protected float distance = 0f;
    //[SerializeField] protected Transform mainCam;
    [SerializeField] protected Vector3 corePoint = new Vector3(0,0,0);

    //protected override void LoadComponents()
    //{
    //    this.LoadCamera();
    //}

    //protected virtual void LoadCamera()
    //{
    //    if (this.mainCam != null) return;
    //    this.mainCam = GameObject.FindAnyObjectByType<Camera>().transform;
    //    Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    //}

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, corePoint);
        if (this.distance > this.disLimit) return true;
        return false;
    }
    public override void DespawnObject()
    {
        //LevelManager.Instance.CubeCount -= 1;
        CubeSpawner.Instance.Despawn(this.transform.parent.gameObject);
    }
}
