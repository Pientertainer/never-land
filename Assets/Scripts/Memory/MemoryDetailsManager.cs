
using UnityEngine;
using TMPro;

public class MemoryDetailsManager : MonoBehaviour
{
    public TMP_Text memoryTitle;
    public TMP_Text memoryDetails;

    public void ShowMemory(MemoryData memory)
    {
        memoryTitle.text = memory.memoryName;
        memoryDetails.text = memory.memoryDetails;
    }
}
