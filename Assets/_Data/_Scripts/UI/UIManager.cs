using UnityEngine;

public class UIManager : CoreMonoBehaviour
{
    [SerializeField] protected UIMainGame uiMainGame;
    [SerializeField] protected UIWinLevel uiWinLevel;
    [SerializeField] protected UIFailedLevel uiFailedLevel;
    [SerializeField] protected UIPauseMenu uiPauseMenu;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIMainGame();
        LoadUIWinLevel();
        LoadUIFailedLevel();
        LoadUIPauseMenu();
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
    protected virtual void LoadUIPauseMenu()
    {
        if (this.uiPauseMenu != null) return;
        uiPauseMenu = GetComponentInChildren<UIPauseMenu>();
        Debug.LogWarning(transform.name + ": LoadUIPauseMenu", gameObject);
    }

    protected override void Start()
    {
        LevelManager.Instance.OnWinLevel += LevelManager_OnWinLevel;
        LevelManager.Instance.OnNextLevel += LevelManager_OnNextLevel;
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;

        uiWinLevel.gameObject.SetActive(false);
        uiFailedLevel.gameObject.SetActive(false);
        uiPauseMenu.gameObject.SetActive(false);
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
    private void GameManager_OnGameOver(object sender, System.EventArgs e)
    {
        uiMainGame.gameObject.SetActive(false);
        uiFailedLevel.gameObject.SetActive(true);
    }

    public void SetActiveTrue_PauseMenu()
    {
        uiPauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume_PauseMenu()
    {
        uiPauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
