using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public int slotNumber;

    public void Save()
    {
        SaveSystem.Save(slotNumber);
    }
}