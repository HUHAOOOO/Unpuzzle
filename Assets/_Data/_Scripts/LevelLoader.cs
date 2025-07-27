using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : CoreMonoBehaviour
{
    [SerializeField] protected LevelManager levelManager;//GO con thi van nen lien ket binh thuong | Singleton de cho GO xa ket noi thoi
    [SerializeField] protected List<GameObject> listCurrentCubeInLevel = new List<GameObject>();
    protected override void LoadComponents()
    {
        LoadLevelManager();
    }
    protected virtual void LoadLevelManager()
    {
        if (this.levelManager != null) return;
        levelManager = transform.parent.GetComponent<LevelManager>();
        Debug.LogWarning(transform.name + ": LoadLevelManager", gameObject);
    }

    [SerializeField] private LevelSO levelSO;
    [SerializeField] private float cellSize = 1.05f;
    [SerializeField] private int cubeCount;


    public LevelSO LevelSO
    {
        get => levelSO;
        set => levelSO = value;
    }
    protected override void Start()
    {
        LevelManager.Instance.OnWinLevel += LevelManager_OnWinLevel;
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateLevel(levelSO);
        }
    }
    public void GenerateLevel(LevelSO newLevelSO)
    {
        levelSO = newLevelSO;
        // duyet tung hang 
        for (int hang = 0; hang < levelSO.height; hang++)
        {
            // duyet tung cot 
            for (int cot = 0; cot < levelSO.width; cot++)
            {
                CubeSO dataCubeSO = levelSO.GetCubeAt(cot, hang);// lay cac cube theo index List > Array[,]
                if (dataCubeSO == null || dataCubeSO.cubeType == CubeType.None) continue;

                Vector3 pos = new Vector3(hang * cellSize, 0, cot * cellSize);//y hang , x cot : (0,0) (0,1)
                Debug.Log("==== pos : [" + hang + "," + cot + "] = " + pos);
                ////Vector3 pos = new Vector3(x * cellSize, 0, y * cellSize);
                ////Debug.Log("==== pos : [" + x + "," + y + "] = " + pos);
                GameObject obj = null;

                GameObject cubePrefab = dataCubeSO.cubePrefab;

                obj = CubeSpawner.Instance.Spawn(cubePrefab, pos, cubePrefab.transform.rotation);
                obj.gameObject.SetActive(true);
                SaveListGOInlevel(obj);

                CountCubes(dataCubeSO);
            }
        }
        levelManager.CubeCount = this.cubeCount;
    }

    private void SaveListGOInlevel(GameObject newGO)
    {
        listCurrentCubeInLevel.Add(newGO);
    }


    private void CountCubes(CubeSO cubeSO)
    {
        switch (cubeSO.cubeType)
        {
            case CubeType.ArrowUp:
            case CubeType.ArrowDown:
            case CubeType.ArrowLeft:
            case CubeType.ArrowRight:
                cubeCount++;
                break;
            //case CubeType.Number:
            //    obj = Instantiate(numberPrefab, pos, Quaternion.identity);
            //    // Gán số vào block
            //    var text = obj.GetComponentInChildren<TextMesh>();
            //    if (text != null) text.text = data.numberValue.ToString();
            //    break;
            //case CubeType.Gear: obj = Instantiate(gearPrefab, pos, Quaternion.identity); break;
            default:
                break;

        }
    }





    private void LevelManager_OnWinLevel(object sender, System.EventArgs e)
    {
        Debug.Log("LevelManager_OnWinLevel Despawn Cube_Gear");
        cubeCount = 0;
        levelSO = null;
        foreach (GameObject obj in listCurrentCubeInLevel)
        {
            if (obj.name == "Cube_Gear")
                //CubeSpawner.Instance.Despawn(obj);
                CubeSpawner.Instance.DespawnCube_Gear(obj);
        }
        listCurrentCubeInLevel.Clear();
    }
    private void GameManager_OnGameOver(object sender, System.EventArgs e)
    {
        cubeCount = 0;
        levelSO = null;
        foreach (GameObject obj in listCurrentCubeInLevel)
        {
            CubeSpawner.Instance.DespawnGO(obj);
        }
        listCurrentCubeInLevel.Clear();
    }
}
