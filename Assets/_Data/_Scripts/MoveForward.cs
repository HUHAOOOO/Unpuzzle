using UnityEngine;

public class MoveForward : CoreMonoBehaviour
{
    public float speed = 10f;
    [SerializeField] protected CubeCtrl cubeCtrl;
    [SerializeField] protected bool isCanMove = false;
    public bool IsCanMove
    {
        get => isCanMove;
        set => isCanMove = value;
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


    protected override void OnDisable()
    {
        isCanMove = false;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    isCanMove = true;
        //}

        if (isCanMove)
        {
            Move();
        }

    }
    void Move()
    {
        // forward Z
        cubeCtrl.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (cubeCtrl.transform.parent.GetComponent<CubeNumberCtrl>() != null)
            cubeCtrl.transform.parent?.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
