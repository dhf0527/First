using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBtmController : MonoBehaviour
{
    private List<KioskData> kioskDatas = new List<KioskData>();

    public bool IsCheck(string name, KioskData data)
    {
        if (kioskDatas.Count == 0)
        {
            kioskDatas.Add(data);
            return true;
        }
        else
        {
            bool check = true;
            foreach (var item in kioskDatas)
            {
                if (item.name == name)
                {
                    check = false;
                }
                
            }

            if (check)
            {
                kioskDatas.Add(data);
            }
            return check;
        }
    }
}
