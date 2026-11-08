
using UnityEngine;

[CreateAssetMenu(fileName = "NewMemory", menuName = "Game/Memory Data")]
public class MemoryData : ScriptableObject
{
    public string memoryName;
    [TextArea(3, 10)]
    public string memoryDetails;
}
