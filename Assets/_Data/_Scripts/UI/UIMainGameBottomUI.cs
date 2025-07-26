using TMPro;
using UnityEngine;

public class UIMainGameBottomUI : CoreMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    public TextMeshProUGUI LevelText
    {
        get => levelText;
        set => levelText = value;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLevelText();
    }

    protected virtual void LoadLevelText()
    {
        if (this.levelText != null) return;
        levelText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadLevelText", gameObject);
    }
}
