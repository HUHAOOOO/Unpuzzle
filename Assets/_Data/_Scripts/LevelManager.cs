using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : CoreMonoBehaviour
{
    [SerializeField] private LevelSO currentLevelSO;
    [SerializeField] protected LevelLoader levelLoader;

    [SerializeField] private List<LevelSO> listLevelSO = new List<LevelSO>();


    public LevelSO CurrentLevelSO
    {
        get => currentLevelSO;
        set => currentLevelSO = value;
    }
    protected override void LoadComponents()
    {
        LoadLevelLoader();
        LoadListLevelSO();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        currentLevelSO = listLevelSO[0];
    }

    protected virtual void LoadLevelLoader()
    {
        if (this.levelLoader != null) return;
        levelLoader = GetComponentInChildren<LevelLoader>();
        Debug.LogWarning(transform.name + ": LoadLevelLoader", gameObject);
    }
    protected virtual void LoadListLevelSO()
    {
        if (this.listLevelSO.Count > 0 ) return;

        //sprite_EMPTY = Resources.Load<LevelSO>("/LevelSO/Level_"+i);
        LevelSO[] lvSOArray = Resources.LoadAll<LevelSO>("LevelSO");
        listLevelSO = lvSOArray.ToList();
        Debug.LogWarning(transform.name + ": LoadListLevelSO", gameObject);
    }


    protected override void Start()
    {
        levelLoader.GenerateLevel(CurrentLevelSO);
    }

    private void SwitchLevel()
    {
        //switch
        //case
        // ? 
    }

    private void SetLevel(LevelSO currentLevelSO)
    {
        this.currentLevelSO = currentLevelSO;
    }
}
