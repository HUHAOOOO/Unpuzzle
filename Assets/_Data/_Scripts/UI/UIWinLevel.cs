using UnityEngine;
using UnityEngine.UI;

public class UIWinLevel : CoreMonoBehaviour
{
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private Button menuBtn;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadNextLevelBtn();
        LoadMenuBtn();
    }
    protected virtual void LoadNextLevelBtn()
    {
        if (this.nextLevelBtn != null) return;
        //nextLevelBtn = GetComponentInChildren<Button>();
        nextLevelBtn = transform.Find("NextLevelBtn")?.GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadNextLevelBtn", gameObject);
    }
    protected virtual void LoadMenuBtn()
    {
        if (this.menuBtn != null) return;
        menuBtn = transform.Find("MenuLevelBtn")?.GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadMenuBtn", gameObject);
    }

    protected override void Start()
    {
        nextLevelBtn.onClick.AddListener(() => { LevelManager.Instance.SetNextLevel(); });
        nextLevelBtn.onClick.AddListener(() => { OffThisGO(); });
        menuBtn.onClick.AddListener(() => { Loader.Load(Loader.Scene.MainMenuScene); });
    }
    private void OffThisGO()
    {
        this.gameObject.SetActive(false);
    }
}
