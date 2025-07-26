using TMPro;
using UnityEngine;

public class UIMainGame : CoreMonoBehaviour
{
    [SerializeField] private UIMainGameBottomUI uiMainGameBottomUI;
    [SerializeField] private UIMainGameTopUI uiMainGameTopUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIMainGameBottomUI();
        LoadUIMainGameTopUI();
    }

    protected virtual void LoadUIMainGameBottomUI()
    {
        if (this.uiMainGameBottomUI != null) return;
        uiMainGameBottomUI = GetComponentInChildren<UIMainGameBottomUI>();
        Debug.LogWarning(transform.name + ": LoadUIMainGameBottomUI", gameObject);
    }    
    protected virtual void LoadUIMainGameTopUI()
    {
        if (this.uiMainGameTopUI != null) return;
        uiMainGameTopUI = GetComponentInChildren<UIMainGameTopUI>();
        Debug.LogWarning(transform.name + ": LoadUIMainGameTopUI", gameObject);
    }

    protected override void Start()
    {
        LevelManager.Instance.OnNextLevel += LevelManager_OnNextLevel;
        uiMainGameBottomUI.LevelText.text = "Level " + LevelManager.Instance.CurrentLevel.ToString(); ;
    }
    private void LevelManager_OnNextLevel(object sender, System.EventArgs e)
    {
        UpdateLevelText();
    }
    private void UpdateLevelText()
    {
        uiMainGameBottomUI.LevelText.text = "Level " + LevelManager.Instance.CurrentLevel.ToString();
    }
}
