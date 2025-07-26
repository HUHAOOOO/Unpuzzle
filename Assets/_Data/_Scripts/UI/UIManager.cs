using UnityEngine;

public class UIManager : CoreMonoBehaviour
{
    [SerializeField] protected UIMainGame uiMainGame;
    [SerializeField] protected UIWinLevel uiWinLevel;
    [SerializeField] protected UIFailedLevel uiFailedLevel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIMainGame();
        LoadUIWinLevel();
        LoadUIFailedLevel();
    }

    protected virtual void LoadUIMainGame()
    {
        if (this.uiMainGame != null) return;
        uiMainGame = GetComponentInChildren<UIMainGame>();
        Debug.LogWarning(transform.name + ": LoadUIMainGame", gameObject);
    }
    protected virtual void LoadUIWinLevel()
    {
        if (this.uiWinLevel != null) return;
        uiWinLevel = GetComponentInChildren<UIWinLevel>();
        Debug.LogWarning(transform.name + ": LoadUIWinLevel", gameObject);
    }
        
    protected virtual void LoadUIFailedLevel()
    {
        if (this.uiFailedLevel != null) return;
        uiFailedLevel = GetComponentInChildren<UIFailedLevel>();
        Debug.LogWarning(transform.name + ": LoadUIFailedLevel", gameObject);
    }

    protected override void Start()
    {
        LevelManager.Instance.OnWinLevel += LevelManager_OnWinLevel;
        LevelManager.Instance.OnNextLevel += LevelManager_OnNextLevel;

        uiWinLevel.gameObject.SetActive(false);
        uiFailedLevel.gameObject.SetActive(false);
    }
    private void LevelManager_OnWinLevel(object sender, System.EventArgs e)
    {
        uiWinLevel.gameObject.SetActive(true);
        uiMainGame.gameObject.SetActive(false);
    }
    private void LevelManager_OnNextLevel(object sender, System.EventArgs e)
    {
        uiMainGame.gameObject.SetActive(true);
    }
}
