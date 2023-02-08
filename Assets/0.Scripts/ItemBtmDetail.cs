using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemBtmDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private TMP_Text sumText;

    [SerializeField] private ItemBtmController ibCont;

    public KioskData kioskData;
    int count = 0;

    public int Count {
        get { return count; }
        set 
        {
            count = value;
            countText.text = string.Format("{0}°³", count);
        }
    }

    int sum = 0;

    public int Sum
    {
        get { return sum; }
        set
        {
            sum = value;
            sumText.text = string.Format("{0:#,###}", sum);
        }
    }

    public void DataSetting(KioskData data, ItemBtmController cont)
    {
        ibCont = cont;
        kioskData = data;
        Count += 1;

        changeSum();
        titleText.text = data.name;
    }

    public void OnMinus()
    {
        if (Count <= 1)
        {
            return;
        }

        Count -= 1;
        changeSum();
        ibCont.TotalPrcie();
    }
    public void OnPlus()
    {
        if (Count >= 99)
        {
            return;
        }

        Count += 1;
        changeSum();
        ibCont.TotalPrcie();
    }

    public void changeSum()
    {
        Sum = Count * kioskData.price;
    }
    public void OnDelete()
    {
        ibCont.DeleteData(kioskData);
        Destroy(gameObject);
    }

}
