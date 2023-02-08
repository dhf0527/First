using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBtmController : MonoBehaviour
{
    private List<KioskData> kioskDatas = new List<KioskData>();

    [SerializeField] private TMPro.TMP_Text totalPriceText;

    [HideInInspector] public List<ItemBtmDetail> itemBtmDetails = new List<ItemBtmDetail>();

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

    public void AddCount(string name)
    {
        foreach (var item in itemBtmDetails)
        {
            if (item.kioskData.name == name)
            {
                if (item.Count >= 99)
                {
                    return;
                }
                item.Count += 1;
                item.changeSum();
                break;
            }
        }
    }

    private void Start()
    {
        TotalPrcie();
    }

    public void TotalPrcie()
    {
        if (itemBtmDetails.Count == 0)
        {
            totalPriceText.text = "0¿ø";
            return;
        }
        int sum = 0;
        foreach (var item in itemBtmDetails)
        {
            sum += item.Count * item.kioskData.price;
        }
        totalPriceText.text = string.Format("{0: #,###}¿ø", sum);
    }

    public void DeleteData(KioskData data)
    {
        foreach (var item in itemBtmDetails)
        {
            if (data.name == item.kioskData.name)
            {
                itemBtmDetails.Remove(item);
                kioskDatas.Remove(item.kioskData);
                TotalPrcie();
                break;
            }
        }
    }
}
