using UnityEngine;
using UnityEngine.UI;

public class UIFailedLevel : CoreMonoBehaviour
{
    [SerializeField] private Button againLevelBtn;
    [SerializeField] private Button menuBtn;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAgainLevelBtn();
        LoadMenuBtn();
    }
    protected virtual void LoadAgainLevelBtn()
    {
        if (this.againLevelBtn != null) return;
        againLevelBtn = transform.Find("AgainLevelBtn")?.GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadAgainLevelBtn", gameObject);
    }
    protected virtual void LoadMenuBtn()
    {
        if (this.menuBtn != null) return;
        menuBtn = transform.Find("MenuLevelBtn")?.GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadMenuBtn", gameObject);
    }

    protected override void Start()
    {
        againLevelBtn.onClick.AddListener(() => { LevelManager.Instance.SetAgaintLevel(); });
        againLevelBtn.onClick.AddListener(() => { OffThisGO(); });
        menuBtn.onClick.AddListener(() => { Loader.Load(Loader.Scene.MainMenuScene); });
    }
    private void OffThisGO()
    {
        this.gameObject.SetActive(false);
    }
}
