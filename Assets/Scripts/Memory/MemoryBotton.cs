
using UnityEngine;

public class MemoryButton : MonoBehaviour
{
    public MemoryData memoryData;
    public MemoryDetailsManager detailsManager;

    public void OnClickMemory()
    {
        detailsManager.ShowMemory(memoryData);
    }
}
