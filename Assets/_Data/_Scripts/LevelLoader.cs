using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelSO levelSO;

    //public GameObject arrowUpPrefab, arrowDownPrefab, arrowLeftPrefab, arrowRightPrefab;
    //public GameObject numberPrefab, gearPrefab;
    public float cellSize = 1.05f;

    void Start()
    {
        //GenerateLevel(levelSO);
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

                Vector3 pos = new Vector3(hang * cellSize, 0,cot * cellSize);//y hang , x cot : (0,0) (0,1)
                Debug.Log("==== pos : [" + hang + "," + cot + "] = " + pos);
                ////Vector3 pos = new Vector3(x * cellSize, 0, y * cellSize);
                ////Debug.Log("==== pos : [" + x + "," + y + "] = " + pos);
                GameObject obj = null;

                GameObject cubePrefab = dataCubeSO.cubePrefab;
                //switch (dataCubeSO.cubeType)
                //{
                

                //    case CubeType.ArrowUp: obj = Instantiate(cubePrefab, pos, cubePrefab.transform.rotation); break;
                //    case CubeType.ArrowDown: obj = Instantiate(arrowDownPrefab, pos, arrowDownPrefab.transform.rotation); break;
                //    case CubeType.ArrowLeft: obj = Instantiate(arrowLeftPrefab, pos, arrowLeftPrefab.transform.rotation); break;
                //    case CubeType.ArrowRight: obj = Instantiate(arrowRightPrefab, pos, arrowRightPrefab.transform.rotation); break;
                //        //case CubeType.Number:
                //        //    obj = Instantiate(numberPrefab, pos, Quaternion.identity);
                //        //    // Gán số vào block
                //        //    var text = obj.GetComponentInChildren<TextMesh>();
                //        //    if (text != null) text.text = data.numberValue.ToString();
                //        //    break;
                //        //case CubeType.Gear: obj = Instantiate(gearPrefab, pos, Quaternion.identity); break;
                //}
                //obj = Instantiate(cubePrefab, pos, cubePrefab.transform.rotation);
                obj = CubeSpawner.Instance.Spawn(cubePrefab, pos, cubePrefab.transform.rotation);
                obj.gameObject.SetActive(true);

                //if (obj != null) obj.transform.parent = this.transform;
            }
        }
    }
}
