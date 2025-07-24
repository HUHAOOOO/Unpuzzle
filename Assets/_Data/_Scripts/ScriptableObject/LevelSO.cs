//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "Level_", menuName = "SO/LevelSO")]
//public class LevelSO : ScriptableObject
//{
//    public int width;
//    public int height;

//    //[HideInInspector]
//    public CubeSO[,] gridData;

//    public CubeSO GetCubeAt(int x, int y)
//    {
//        if (x < 0 || y < 0 || x >= width || y >= height) return null;
//        return gridData[x, y];
//    }

//#if UNITY_EDITOR
//    private void OnValidate()
//    {
//        if (width <= 0 || height <= 0) return;

//        // tao mang moi
//        CubeSO[,] newGrid = new CubeSO[width, height];

//        // Copy data tu mang cu neu co 
//        if (gridData != null)
//        {
//            for (int x = 0; x < Mathf.Min(gridData.GetLength(0), width); x++)
//            {
//                for (int y = 0; y < Mathf.Min(gridData.GetLength(1), height); y++)
//                {
//                    newGrid[x, y] = gridData[x, y];
//                }
//            }
//        }

//        gridData = newGrid;
//    }
//#endif
//}





using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_", menuName = "SO/LevelSO")]
public class LevelSO : ScriptableObject
{
    public int width;
    public int height;

    [Tooltip("Luoi cac CubeSO, theo thu tu tu tren xuong, trai sang phai")]
    public List<CubeSO> gridData = new List<CubeSO>();

    public CubeSO GetCubeAt(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height) return null;
        Debug.Log($"GetCubeAt(HANG : {y}, COT : {x}) -> index in List: {y * width + x} \n name : {gridData[y * width + x].name}");
        //Debug.Log($"gridData[y * width + x] : " + gridData[y * width + x].name);
        return gridData[y * width + x];//y * do rong + x(de dich xuong) | [ ] Hieu /co ban no la list mo ta 1 Array
    }

#if UNITY_EDITOR
    // goi khi thay doi
    private void OnValidate()
    {
        int targetSize = width * height;

        if (gridData == null)
            gridData = new List<CubeSO>(targetSize);

        // thieu thi them 
        while (gridData.Count < targetSize)
            gridData.Add(null);

        // Du xoa 
        while (gridData.Count > targetSize)
            gridData.RemoveAt(gridData.Count - 1);

        for(int i=0; i < gridData.Count; i++)
        {
            Debug.Log($"gridData[{i}] : {gridData[i].name}");
        }

    }

#endif
}
