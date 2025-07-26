using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGameTopUI : CoreMonoBehaviour
{
    [SerializeField] private Button pauseMenuBtn;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI movesText;
    public TextMeshProUGUI MoneyText
    {
        get => moneyText;
        set => moneyText = value;
    }
    public TextMeshProUGUI MovesText
    {
        get => movesText;
        set => movesText = value;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPauseMenuBtn();
        LoadLevelText();
        LoadMovesText();
    }

    protected virtual void LoadPauseMenuBtn()
    {
        if (this.pauseMenuBtn != null) return;
        pauseMenuBtn = GetComponentInChildren<Button>();
        Debug.LogWarning(transform.name + ": LoadPauseMenuBtn", gameObject);
    }
    protected virtual void LoadLevelText()
    {
        if (this.moneyText != null) return;
        moneyText = transform.Find("MoneyCountText")?.GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadLevelText", gameObject);
    }
    protected virtual void LoadMovesText()
    {
        if (this.movesText != null) return;
        movesText = transform.Find("MovesText")?.GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadMovesText", gameObject);
    }


    private void Update()
    {
        moneyText.text = "$ " + GameManager.Instance.MonkeyCount.ToString();
        movesText.text = "Moves " + GameManager.Instance.MovesCount.ToString();
    }
}
