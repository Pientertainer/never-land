
using UnityEngine;
using TMPro;

public class MemoryManager : MonoBehaviour
{
    // 記憶データ
    public MemoryData[] peopleMemories;
    public MemoryData[] locationMemories;
    public MemoryData[] otherMemories;

    // 記憶一覧の表示
    public TMP_Text[] peopleMemoryNames;
    public TMP_Text[] locationMemoryNames;
    public TMP_Text[] otherMemoryNames;

    // 入手数の表示
    public TMP_Text memoryCount;

    // カテゴリーのパネル
    public GameObject peoplePanel;
    public GameObject locationPanel;
    public GameObject otherPanel;

    // 人物の記憶
    public void ShowPeople()
    {
        peoplePanel.SetActive(true);
        locationPanel.SetActive(false);
        otherPanel.SetActive(false);

        UpdateMemoryList(
            peopleMemoryNames,
            peopleMemories
        );

        UpdateMemoryCount(peopleMemories);
    }

    // 場所の記憶
    public void ShowLocation()
    {
        peoplePanel.SetActive(false);
        locationPanel.SetActive(true);
        otherPanel.SetActive(false);

        UpdateMemoryList(
            locationMemoryNames,
            locationMemories
        );

        UpdateMemoryCount(locationMemories);
    }

    // その他の記憶
    public void ShowOther()
    {
        peoplePanel.SetActive(false);
        locationPanel.SetActive(false);
        otherPanel.SetActive(true);

        UpdateMemoryList(
            otherMemoryNames,
            otherMemories
        );

        UpdateMemoryCount(otherMemories);
    }

    // 記憶一覧を更新
    void UpdateMemoryList(
        TMP_Text[] texts,
        MemoryData[] memories
    )
    {
        for (int i = 0; i < texts.Length; i++)
        {
            if (memories[i] != null &&
                memories[i].obtained)
            {
                texts[i].text = memories[i].memoryName;
            }
            else
            {
                texts[i].text = "???";
            }
        }
    }

    // 入手数を更新
    void UpdateMemoryCount(MemoryData[] memories)
    {
        int count = 0;

        for (int i = 0; i < memories.Length; i++)
        {
            if (memories[i] != null &&
                memories[i].obtained)
            {
                count++;
            }
        }

        memoryCount.text =
            "記憶：" + count + "/" + memories.Length;
    }

    // 記憶を入手する
    public void AcquireMemory(MemoryData memory)
    {
        if (memory == null)
        {
            Debug.LogWarning("MemoryDataが設定されていません");
            return;
        }

        memory.obtained = true;

        // 現在表示しているカテゴリーを更新
        if (peoplePanel.activeSelf)
        {
            ShowPeople();
        }
        else if (locationPanel.activeSelf)
        {
            ShowLocation();
        }
        else if (otherPanel.activeSelf)
        {
            ShowOther();
        }
    }
}
