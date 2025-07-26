using UnityEngine;

public class GameManager : CoreMonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int monkeyCount;
    [SerializeField] private int movesCount;
    [SerializeField] private bool isGameOver;

    // [ ] Su kien game over
    // 1 ko the choi nx KO ban raycast dc 
    // 2 bat UI Failed 

    public int MonkeyCount
    {
        get => monkeyCount;
        set => monkeyCount = value;
    }
    public int MovesCount
    {
        get => movesCount;
        set => movesCount = value;
    }
    protected override void Awake()
    {
        if (Instance != null) Debug.LogWarning("Just allow 1 GameManager singleton");
        Instance = this;
    }

    private void Update()
    {
        if (movesCount <= 0)
        {
            Debug.Log("THUA ROI");
            isGameOver = true;
        }
    }

}
