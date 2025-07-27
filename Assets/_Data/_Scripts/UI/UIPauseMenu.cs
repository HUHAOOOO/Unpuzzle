using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : CoreMonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    [SerializeField] private Button resumeBtn;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIManager();

        LoadResumeBtn();
    }

    protected virtual void LoadUIManager()
    {
        if (this.uiManager != null) return;
        uiManager = transform.parent.GetComponent<UIManager>();
        Debug.LogWarning(transform.name + ": LoadUIManager", gameObject);
    }
    protected virtual void LoadResumeBtn()
    {
        if (this.resumeBtn != null) return;
        resumeBtn = GetComponentInChildren<Button>();
        Debug.LogWarning(transform.name + ": LoadResumeBtn", gameObject);
    }
    protected override void Start()
    {
        resumeBtn.onClick.AddListener(() => { uiManager.Resume_PauseMenu(); });
        
    }
}
