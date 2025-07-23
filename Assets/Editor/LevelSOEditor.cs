


//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(LevelSO))]
//public class LevelSOEditor : Editor
//{
//    private const float iconSize = 64f;

//    public override void OnInspectorGUI()
//    {
//        LevelSO levelSO = (LevelSO)target;

//        // Thiết lập chiều rộng và chiều cao
//        levelSO.width = EditorGUILayout.IntField("Width", levelSO.width);
//        levelSO.height = EditorGUILayout.IntField("Height", levelSO.height);

//        int targetSize = levelSO.width * levelSO.height;

//        // Khởi tạo hoặc chỉnh lại kích thước danh sách
//        if (levelSO.gridData == null)
//            levelSO.gridData = new System.Collections.Generic.List<CubeSO>(targetSize);

//        while (levelSO.gridData.Count < targetSize)
//            levelSO.gridData.Add(null);
//        while (levelSO.gridData.Count > targetSize)
//            levelSO.gridData.RemoveAt(levelSO.gridData.Count - 1);

//        EditorGUILayout.Space();
//        EditorGUILayout.LabelField("Grid Preview", EditorStyles.boldLabel);

//        // Hiển thị lưới theo ma trận X * Y
//        for (int y = 0; y < levelSO.height; y++)
//        {
//            EditorGUILayout.BeginHorizontal();

//            for (int x = 0; x < levelSO.width; x++)
//            {
//                int index = y * levelSO.width + x;
//                CubeSO cube = levelSO.gridData[index];

//                Texture2D preview = null;

//                if (cube != null)
//                {
//                    // Ưu tiên dùng icon do người dùng chỉ định (sprite) nếu có
//                    if (cube.cubeSprite != null)
//                    {
//                        preview = AssetPreview.GetAssetPreview(cube.cubeSprite);
//                        if (preview == null) preview = AssetPreview.GetMiniThumbnail(cube.cubeSprite);
//                    }
//                    else if (cube.cubePrefab != null)
//                    {
//                        preview = AssetPreview.GetAssetPreview(cube.cubePrefab);
//                        if (preview == null) preview = AssetPreview.GetMiniThumbnail(cube.cubePrefab);
//                    }
//                }

//                GUILayout.BeginVertical(GUILayout.Width(iconSize));

//                if (preview != null)
//                {
//                    GUILayout.Label(preview, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
//                }
//                else
//                {
//                    GUILayout.Box("", GUILayout.Width(iconSize), GUILayout.Height(iconSize));
//                }

//                levelSO.gridData[index] = (CubeSO)EditorGUILayout.ObjectField(cube, typeof(CubeSO), false, GUILayout.Width(iconSize));

//                GUILayout.EndVertical();
//            }

//            EditorGUILayout.EndHorizontal();
//        }

//        if (GUI.changed)
//        {
//            EditorUtility.SetDirty(levelSO);
//        }
//    }
//}
//#endif


/////////////////OK
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelSO))]
public class LevelSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelSO levelSO = (LevelSO)target;

        levelSO.width = EditorGUILayout.IntField("Width", levelSO.width);
        levelSO.height = EditorGUILayout.IntField("Height", levelSO.height);

        int targetSize = levelSO.width * levelSO.height;

        if (levelSO.gridData == null)
            levelSO.gridData = new System.Collections.Generic.List<CubeSO>(targetSize);

        while (levelSO.gridData.Count < targetSize)
            levelSO.gridData.Add(null);
        while (levelSO.gridData.Count > targetSize)
            levelSO.gridData.RemoveAt(levelSO.gridData.Count - 1);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Grid Preview", EditorStyles.boldLabel);

        float iconSize = 64f;

        for (int y = 0; y < levelSO.height; y++)
        {
            EditorGUILayout.BeginHorizontal();

            for (int x = 0; x < levelSO.width; x++)
            {
                int index = y * levelSO.width + x;

                CubeSO cube = levelSO.gridData[index];

                // Hình ảnh preview
                Texture2D preview = null;
                if (cube != null && cube.cubePrefab != null)
                    //preview = AssetPreview.GetAssetPreview(cube.cubePrefab);
                    preview = AssetPreview.GetAssetPreview(cube.cubeSprite);

                GUILayout.BeginVertical(GUILayout.Width(iconSize));

                // Hiển thị ảnh nếu có
                if (preview != null)
                {
                    GUILayout.Label(preview, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                }
                else
                {
                    GUILayout.Label("No Icon", GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                }

                // Cho chọn CubeSO
                levelSO.gridData[index] = (CubeSO)EditorGUILayout.ObjectField(cube, typeof(CubeSO), false, GUILayout.Width(iconSize));

                GUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUI.changed)
            EditorUtility.SetDirty(levelSO);
    }
}
#endif







////#if UNITY_EDITOR
////using UnityEditor;
////using UnityEngine;

////[CustomEditor(typeof(LevelSO))]
////public class LevelSOEditor : Editor 
////{
////    public override void OnInspectorGUI()
////    {
////        LevelSO levelSO = (LevelSO)target;

////        // Vẽ mặc định các biến Width, Height
////        levelSO.width = EditorGUILayout.IntField("Width", levelSO.width);
////        levelSO.height = EditorGUILayout.IntField("Height", levelSO.height);

////        int targetSize = levelSO.width * levelSO.height;

////        // Resize list nếu cần
////        if (levelSO.gridData == null)
////            levelSO.gridData = new System.Collections.Generic.List<CubeSO>(targetSize);

////        while (levelSO.gridData.Count < targetSize)
////            levelSO.gridData.Add(null);
////        while (levelSO.gridData.Count > targetSize)
////            levelSO.gridData.RemoveAt(levelSO.gridData.Count - 1);

////        EditorGUILayout.LabelField("Grid Layout", EditorStyles.boldLabel);

////        // Hiển thị dạng ma trận
////        for (int y = 0; y < levelSO.height; y++)
////        {
////            EditorGUILayout.BeginHorizontal();

////            for (int x = 0; x < levelSO.width; x++)
////            {
////                int index = y * levelSO.width + x;
////                levelSO.gridData[index] = (CubeSO)EditorGUILayout.ObjectField(
////                    levelSO.gridData[index], typeof(CubeSO), false, GUILayout.Width(80));
////            }

////            EditorGUILayout.EndHorizontal();
////        }

////        if (GUI.changed)
////        {
////            EditorUtility.SetDirty(levelSO);
////        }
////    }
////}
////#endif
