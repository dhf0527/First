using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;

    [SerializeField] private ItemBtmDetail itembd;
    [SerializeField] private Transform parent;

    private ItemBtmController ibCont;
    private KioskData kioskData;
    public ItemDetail SetNameText(string name)
    {
        nameText.text = name;
        return this;
    }

    public ItemDetail SetPriceText(int price)
    {
        priceText.text = string.Format("{0:##,###}¿ø", price);
        return this;
    }

    public ItemDetail SetIBCont(ItemBtmController cont)
    {
        ibCont = cont;
        return this;
    }

    public ItemDetail SetParent(Transform parent)
    {
        this.parent = parent;
        return this;
    }

    public ItemDetail SetItembd(ItemBtmDetail itembd)
    {
        this.itembd = itembd;
        return this;
    }

    public ItemDetail SetKioskData(KioskData data)
    {
        kioskData = data;
        SetNameText(data.name);
        SetPriceText(data.price);
        return this;
    }

    public void Onclick()
    {
        if (ibCont.IsCheck(kioskData.name, kioskData))
        {
            ItemBtmDetail ibd = Instantiate(itembd, parent);
            ibd.DataSetting(kioskData,ibCont);

            ibCont.itemBtmDetails.Add(ibd);
        }
        else
        {
            ibCont.AddCount(kioskData.name);
        }
        ibCont.TotalPrcie();
    }

}
