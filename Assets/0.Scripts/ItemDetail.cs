using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;
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
}
