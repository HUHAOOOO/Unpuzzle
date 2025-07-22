using UnityEngine;

public class TriggerCube : CoreMonoBehaviour , IInteractable
{
    [SerializeField] protected CubeCtrl cubeCtrl;

    public void OnInteract()
    {
        Debug.Log("Object was interacted with!");
        cubeCtrl.ShootRaycastForward.ShootRay();
    }

    protected override void LoadComponents()
    {
        LoadCubeCtrl();
    }

    protected virtual void LoadCubeCtrl()
    {
        if (this.cubeCtrl != null) return;
        cubeCtrl = transform.parent.GetComponent<CubeCtrl>();
        Debug.LogWarning(transform.name + ": LoadCubeCtrl", gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.GetComponent<CubeCtrl>())
        {
            cubeCtrl.MoveForward.IsCanMove = false;
        }
    }
}
