using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelSO levelSO;

    //public GameObject arrowUpPrefab, arrowDownPrefab, arrowLeftPrefab, arrowRightPrefab;
    //public GameObject numberPrefab, gearPrefab;
    public float cellSize = 1.05f;

    void Start()
    {
        GenerateLevel();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateLevel();
        }
    }
    void GenerateLevel()
    {
        // duyet tung hang 
        for (int y = 0; y < levelSO.height; y++)
        {
            // duyet tung cot 
            for (int x = 0; x < levelSO.width; x++)
            {
                CubeSO dataCubeSO = levelSO.GetCubeAt(x, y);// lay cac cube theo index List > Array[,]
                if (dataCubeSO == null || dataCubeSO.cubeType == CubeType.None) continue;

                //Vector3 pos = new Vector3(x * cellSize, 0, y * cellSize);
                Vector3 pos = new Vector3(y * cellSize, 0,x * cellSize);
                Debug.Log("==== pos : [" + y + "," + x + "] = " + pos);
                //Debug.Log("==== pos : [" + x + "," + y + "] = " + pos);
                GameObject obj = null;

                GameObject cubePrefab = dataCubeSO.cubePrefab;
                //switch (dataCubeSO.cubeType)
                //{
                //    // [ ] todo 
                //    // arrowUpPrefab : cac Prefab co the lay tu CubeSO

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
                // setactive ko 

                //if (obj != null) obj.transform.parent = this.transform;
            }
        }
    }
}
