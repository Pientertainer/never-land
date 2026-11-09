
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MemoryDetailsManager : MonoBehaviour
{
    public TMP_Text memoryTitle;
    public TMP_Text memoryDetails;

    // 思い出すボタン
    public Button recallButton;

    // 選択した記憶を表示
    public void ShowMemory(MemoryData memory)
    {
        // 記憶データが設定されていない場合
        if (memory == null)
        {
            memoryTitle.text = "？？？";
            memoryDetails.text = "？？？";

            recallButton.interactable = false;
            return;
        }

        // 未入手の場合
        if (!memory.obtained)
        {
            memoryTitle.text = "???";
            memoryDetails.text = "???";

            recallButton.interactable = false;
        }
        else
        {
            // 入手済みの場合
            memoryTitle.text = memory.memoryName;
            memoryDetails.text = memory.memoryDetails;

            recallButton.interactable = true;
        }
    }
}
