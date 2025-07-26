using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : CoreMonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField] protected LevelLoader levelLoader;

    [SerializeField] private int currentLevel;
    [SerializeField] private LevelSO currentLevelSO;
    [SerializeField] private LevelSO nextLevelSO;

    [SerializeField] private List<LevelSO> listLevelSO = new List<LevelSO>();

    [SerializeField] int cubeCount;
    [SerializeField] bool isWinLevel;
    public event EventHandler OnNewLevel;
    public event EventHandler OnWinLevel;
    public event EventHandler OnNextLevel;

    public int CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }
    public LevelSO CurrentLevelSO
    {
        get => currentLevelSO;
        set => currentLevelSO = value;
    }
    public int CubeCount
    {
        get => cubeCount;
        set => cubeCount = value;
    }
    protected override void LoadComponents()
    {
        LoadLevelLoader();
        LoadListLevelSO();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        SetLevel(listLevelSO[0]);
    }

    protected virtual void LoadLevelLoader()
    {
        if (this.levelLoader != null) return;
        levelLoader = GetComponentInChildren<LevelLoader>();
        Debug.LogWarning(transform.name + ": LoadLevelLoader", gameObject);
    }
    protected virtual void LoadListLevelSO()
    {
        if (this.listLevelSO.Count > 0) return;

        LevelSO[] lvSOArray = Resources.LoadAll<LevelSO>("LevelSO");
        listLevelSO = lvSOArray.ToList();
        SelectionSort(listLevelSO);
        Debug.LogWarning(transform.name + ": LoadListLevelSO", gameObject);
    }

    private void SelectionSort(List<LevelSO> listLevelSO)
    {
        for (int i = 0; i < listLevelSO.Count - 1; i++)
        {
            int minIndex = i;
            // tim nho nhat tu i 
            for (int j = i + 1; j < listLevelSO.Count; j++)
            {
                //if (string.Compare(listLevelSO[j].name, listLevelSO[minIndex].name) < 0)
                int x = int.Parse(listLevelSO[j].name.Replace("Level_", ""));
                int y = int.Parse(listLevelSO[minIndex].name.Replace("Level_", ""));
                if (x < y)// nho hon minIndex THI > new minIndex
                {
                    minIndex = j;
                }
            }
            // Doi cho 
            if (minIndex != i)
            {
                LevelSO temp = listLevelSO[i];
                listLevelSO[i] = listLevelSO[minIndex];
                listLevelSO[minIndex] = temp;
            }
        }
    }


    protected override void Awake()
    {
        if (Instance != null) Debug.LogWarning("Just allow 1 LevelManager singleton");
        Instance = this;
    }
    protected override void Start()
    {
        OnNewLevel += LevelManager_OnNewLevel;
        OnWinLevel += LevelManager_OnWinLevel;

        SetLevel(listLevelSO[currentLevel]);
        //levelLoader.GenerateLevel(currentLevelSO);
    }
    private void Update()
    {
        CheckWinlevel();
    }

    // Btn >  : Next Level 
    public void SetNextLevel()
    {
        SetLevel(nextLevelSO);
        OnNextLevel?.Invoke(this,EventArgs.Empty);
    }
    public void SetAgaintLevel()
    {
        SetLevel(currentLevelSO);
        //OnNextLevel?.Invoke(this, EventArgs.Empty);
    }
    private void SetLevel(LevelSO updateCurrentLevelSO)
    {
        this.currentLevelSO = updateCurrentLevelSO;
        levelLoader.LevelSO = currentLevelSO;
        levelLoader.GenerateLevel(currentLevelSO);
        UpdateNextLevel();

        OnNewLevel?.Invoke(this,EventArgs.Empty);
    }

    private void UpdateNextLevel()
    {
        string levelString = currentLevelSO.name.Replace("Level_", "");
        Debug.Log(levelString);
        int level = int.Parse(levelString);
        currentLevel = level;
        level += 1;
        Debug.Log(level);

        if (listLevelSO.Count == level)
        {
            nextLevelSO = listLevelSO[0];
        }
        else
            nextLevelSO = listLevelSO[level];
    }

    /// <summary>
    /// 
    /// </summary>
    private void CheckWinlevel()
    {
        if (cubeCount <= 0) isWinLevel = true;
        if (!isWinLevel) return;
        WinLevel();
    }
    private void WinLevel()
    {
        OnWinLevel?.Invoke(this, EventArgs.Empty);
    }


    private void LevelManager_OnWinLevel(object sender, System.EventArgs e)
    {
        //Debug.Log("WinLevel : LevelManager_OnWinLevel");

        isWinLevel = false;
        cubeCount = 0;
    }    
    private void LevelManager_OnNewLevel(object sender, System.EventArgs e)
    {
        GameManager.Instance.MovesCount = currentLevelSO.moves;
        Debug.Log("LevelManager_OnNewLevel MovesCount \n currentLevelSO.moves : " + currentLevelSO.moves);
    }
}
