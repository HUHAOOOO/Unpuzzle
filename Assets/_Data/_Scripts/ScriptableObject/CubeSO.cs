using UnityEngine;

[CreateAssetMenu(fileName = "Cube_Type", menuName = "SO/CubeSO")]
public class CubeSO : ScriptableObject
{
    public CubeType cubeType;
    public GameObject cubePrefab;
    public Sprite cubeSprite;

    //public int numberValue;//block number
}
