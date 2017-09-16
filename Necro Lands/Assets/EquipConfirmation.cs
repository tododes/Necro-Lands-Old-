using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EquipConfirmation : MonoBehaviour {

    public int idx;
    private EquipImage equip;

    void Start()
    {
        equip = transform.parent.parent.gameObject.GetComponent<EquipImage>();
        idx = equip.index;
    }

    public void UnEquip()
    {
        PlayerPrefs.SetString("equip"+idx, "");
        PlayerPrefs.SetInt("equipqty" + idx, -1);
        equip.Initiated = false;
        transform.parent.gameObject.SetActive(false);
    }

    public void Cancel()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
