using UnityEngine;

public class CheckTriggerCube : CoreMonoBehaviour
{
    [SerializeField] protected GearCtrl gearCtrl;
    protected override void LoadComponents()
    {
        LoadGearCtrl();
    }

    protected virtual void LoadGearCtrl()
    {
        if (this.gearCtrl != null) return;
        gearCtrl = transform.parent.GetComponent<GearCtrl>();
        Debug.LogWarning(transform.name + ": LoadGearCtrl", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision : " + other.gameObject.name);
        CubeCtrl cubeCtrl = other.gameObject.transform.parent.GetComponent<CubeCtrl>();
        if (cubeCtrl != null)
        {
            Debug.Log("OnCollisionEnter : " + other.gameObject.transform.parent.name);
            CubeSpawner.Instance.Despawn(other.transform.parent.gameObject);
        }
    }
}
