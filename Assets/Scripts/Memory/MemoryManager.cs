
using UnityEngine;
using TMPro;

public class MemoryManager : MonoBehaviour
{
    // カテゴリーごとのPanel
    public GameObject peoplePanel;
    public GameObject locationPanel;
    public GameObject otherPanel;

    // 記憶名のTextMeshPro
    public TMP_Text[] peopleMemoryNames;
    public TMP_Text[] locationMemoryNames;
    public TMP_Text[] otherMemoryNames;

    public TMP_Text memoryCount;

    // 記憶を入手しているかどうか
    public bool[] peopleObtained;
    public bool[] locationObtained;
    public bool[] otherObtained;

    // 記憶の名前
    public string[] peopleNames;
    public string[] locationNames;
    public string[] otherNames;


    void Start()
{
    ShowPeople();
}


    // 人物タブ
    public void ShowPeople()
    {
        peoplePanel.SetActive(true);
        locationPanel.SetActive(false);
        otherPanel.SetActive(false);

        UpdateMemoryList(
            peopleMemoryNames,
            peopleNames,
            peopleObtained
        );

        UpdateMemoryCount(peopleObtained);
    }


    // 場所タブ
    public void ShowLocation()
    {
        peoplePanel.SetActive(false);
        locationPanel.SetActive(true);
        otherPanel.SetActive(false);

        UpdateMemoryList(
            locationMemoryNames,
            locationNames,
            locationObtained
        );

        UpdateMemoryCount(locationObtained);
    }


    // その他タブ
    public void ShowOther()
    {
        peoplePanel.SetActive(false);
        locationPanel.SetActive(false);
        otherPanel.SetActive(true);

        UpdateMemoryList(
            otherMemoryNames,
            otherNames,
            otherObtained
        );

        UpdateMemoryCount(otherObtained);
    }


    // 記憶の名前を更新
    void UpdateMemoryList(
        TMP_Text[] texts,
        string[] names,
        bool[] obtained
    )
    {
        for (int i = 0; i < texts.Length; i++)
        {
            if (obtained[i])
            {
                texts[i].text = names[i];
            }
            else
            {
                texts[i].text = "？？？";
            }
        }
    }


    // 入手済みの記憶数を表示
    void UpdateMemoryCount(bool[] obtained)
    {
        int count = 0;

        for (int i = 0; i < obtained.Length; i++)
        {
            if (obtained[i])
            {
                count++;
            }
        }

        memoryCount.text =
            "記憶：" + count + "/" + obtained.Length;
    }
}
