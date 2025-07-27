using TMPro;
using UnityEngine;

public class CubeNumberCtrl : CoreMonoBehaviour
{
    [SerializeField] private CubeCtrl cubeCtrl;
    [SerializeField] private int numberInt = 1;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private Transform model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCubeCtrl();
        LoadNumberText();
        LoadModel();
    }
    protected virtual void LoadCubeCtrl()
    {
        if (this.cubeCtrl != null) return;
        cubeCtrl = GetComponentInChildren<CubeCtrl>();
        cubeCtrl.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadCubeCtrl", gameObject);
    }
    protected virtual void LoadNumberText()
    {
        if (this.numberText != null) return;
        numberText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadNumberText", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        model = transform.Find("Model").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    private void Update()
    {
        
        numberText.text = numberInt.ToString();

        if(numberInt == 0)
        {
            model.gameObject.SetActive(false);
            numberText.gameObject.SetActive(false);
            cubeCtrl.gameObject.SetActive(true);
        }
    }
}
