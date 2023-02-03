using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MainMenuType
{
    FastFood,
    Pizza,
    China,
    Coffee,
    Korea,
    Chicken
}
public class Kiosk : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject detailMenuObj;
    [SerializeField] private GameObject titleObj;

    [SerializeField] private Transform titleParent;
    [SerializeField] private ItemTitle titlePrefab;
    [SerializeField] private Transform detailParent;
    [SerializeField] private GameObject detailPrefab;

    List<string> titlelist = new List<string>();
    Dictionary<string, int> menuDic = new Dictionary<string, int>();

    private MainMenuType selectType = MainMenuType.FastFood;

    public int count { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        List<string> curMenus = new List<string>();
        titlelist.Clear();
        switch (selectType)
        {
            case MainMenuType.FastFood:
                {
                    string[] strs = { "햄버거", "음료", "스낵류", "소스", "아이스크림" };
                    foreach (var item in strs)
                    {
                        titlelist.Add(item);
                    }
                }
                break;
            case MainMenuType.Pizza:
                break;
            case MainMenuType.China:
                break;
            case MainMenuType.Coffee:
                break;
            case MainMenuType.Korea:
                break;
            case MainMenuType.Chicken:
                break;
            default:
                break;
        }

        OnShowMain();
    }

    public void OnShowMain()
    {
        ShowMain(true);
    }

    public void OnShowDetail()
    {
        ShowMain(false);

        //타이틀 세팅
        for (int i = 0; i < titlelist.Count; i++)
        {
            ItemTitle title = Instantiate(titlePrefab, titleParent);
            title.SetText(titlelist[i]);
            title.name = titlelist[i];

            Toggle toggle = title.GetComponent<Toggle>();
            toggle.group = titleParent.GetComponent<ToggleGroup>();
            toggle.onValueChanged.AddListener(delegate { OnToggle(toggle); });

            if (i == 0)
            {
                toggle.isOn = true;
            }
        }
    }

    void ShowMain(bool isShow)
    {
        menuObj.SetActive(isShow);
        detailMenuObj.SetActive(!isShow);
        titleObj.SetActive(!isShow);
    }

    public void OnToggle(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Debug.Log(toggle.name);
        }
    }
}
