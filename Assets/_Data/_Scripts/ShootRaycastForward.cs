using UnityEngine;

public class ShootRaycastForward : CoreMonoBehaviour
{
    [SerializeField] protected CubeCtrl cubeCtrl;
    [SerializeField] protected float rayDistance = 0.2f;
    [SerializeField] protected Transform ShootPoint;

    protected override void LoadComponents()
    {
        LoadCubeCtrl();
        LoadShootPoint();
    }
    protected override void ResetValue()
    {
        ShootPoint.localPosition = new Vector3(0, -0.3f, 0.5f);
    }
    protected virtual void LoadCubeCtrl()
    {
        if (this.cubeCtrl != null) return;
        cubeCtrl = transform.parent.GetComponent<CubeCtrl>();
        Debug.LogWarning(transform.name + ": LoadCubeCtrl", gameObject);
    }
    protected virtual void LoadShootPoint()
    {
        if (this.ShootPoint != null) return;
        ShootPoint = transform.Find("ShootPoint").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadShootPoint", gameObject);
    }
    void Update()
    {
        RayCheckToStop();
        //// An chuot trai
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ShootRay();
        //}

    }

    public void ShootRay()
    {
        Ray ray = new Ray(ShootPoint.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            //Debug.Log("Hit: " + hit.collider.gameObject.transform.parent.name, gameObject);
            cubeCtrl.MoveForward.IsCanMove = false;
        }
        else
        {
            //Debug.Log("No hit > can MoveForward", gameObject);
            cubeCtrl.MoveForward.IsCanMove = true;
        }
        Debug.DrawRay(ShootPoint.position, transform.forward * rayDistance, Color.red, 5f);
    }


    private void RayCheckToStop()
    {
        Debug.DrawRay(ShootPoint.position, transform.forward * rayDistance, Color.red, 1f);
        // no move > no need to check  
        if (cubeCtrl.MoveForward.IsCanMove == false) return;

        Ray ray = new Ray(ShootPoint.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            //Debug.Log("STOP | Hit: " + hit.collider.gameObject.transform.parent.name, gameObject);
            cubeCtrl.MoveForward.IsCanMove = false;
        }
        else
        {
            //Debug.Log("No hit > still can MoveForward", gameObject);
        }
    }
}
