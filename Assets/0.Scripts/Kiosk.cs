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

public struct KioskData
{
    public string name;
    public int price;
}

public class Kiosk : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject detailMenuObj;
    [SerializeField] private GameObject titleObj;

    [SerializeField] private Transform titleParent;
    [SerializeField] private ItemTitle titlePrefab;
    [SerializeField] private Transform detailParent;
    [SerializeField] private ItemDetail detailPrefab;

    [SerializeField] private ItemBtmController ibCont;
    [SerializeField] private ItemBtmDetail itembd;

    List<string> titlelist = new List<string>();
    Dictionary<string, KioskData> menuDic = new Dictionary<string, KioskData>();
    private MainMenuType selectType = MainMenuType.FastFood;

    List<ItemDetail> itemDetails = new List<ItemDetail>();

    public int count { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        List<string> curMenus = new List<string>();
        titlelist.Clear();
        // 메뉴 메인
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
        SubMenuSetting(toggle);
        if (toggle.isOn)
        {
            Debug.Log(toggle.name);
        }
    }

    void SubMenuSetting(Toggle toggle)
    {
        if (!toggle.isOn)
            return;

        menuDic.Clear();

        switch (toggle.name)
        {
            case "햄버거":
                {
                    string[] keys = { "불고기버거", "새우버거", "게살버거", "치즈버거", "치킨버거" };
                    int[] prices = { 3000, 5000, 8000, 4500, 6000 };

                    DataSetCreateMenu(keys, prices);
                }
                break;

            case "음료":
                {
                    string[] keys = { "콜라", "제로콜라", "사이다", "제로사이다", "환타", "웰치스" };
                    int[] prices = { 1500, 2000, 1500, 1500, 1200, 1000 };

                    DataSetCreateMenu(keys, prices);
                }
                break;

            case "스낵류":
                {
                    string[] keys = {"감자튀김","어니언링","오징어링","너겟","치즈스틱" };
                    int[] prices = { 500, 800, 1500, 1200, 1500};

                    DataSetCreateMenu(keys, prices);
                }
                break;

            case "소스":
                {
                    string[] keys = {"칠리", "어니언", "치즈", "머스타드", "케찹" };
                    int[] prices = { 300, 300, 300, 300, 300 };

                    DataSetCreateMenu(keys, prices);
                }
                break;

            case "아이스크림":
                {
                    string[] keys = { "초콜렛", "바닐라", "딸기", "녹차", "쿠키앤크림", "민트초코칩"};
                    int[] prices = { 800, 800, 1200, 1000, 1500, 1500};

                    DataSetCreateMenu(keys, prices);
                }
                break;
        }

    }

    void DataSetCreateMenu(string[] keys, int[] prices)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            KioskData data = new KioskData();
            data.price = prices[i];
            data.name = keys[i];

            menuDic.Add(keys[i], data);
        }

        //오브젝트 생성
        if (detailParent.childCount < keys.Length)
        {
            int gap = System.Math.Abs(detailParent.childCount - keys.Length);
            for (int i = 0; i < gap; i++)
            {
                itemDetails.Add(Instantiate(detailPrefab, detailParent));
            }
        }

        int index = 0;
        foreach (var item in menuDic)
        {
            itemDetails[index].gameObject.SetActive(true);
            itemDetails[index]
                .SetParent(ibCont.transform)
                .SetItembd(itembd)
                .SetIBCont(ibCont)
                .SetKioskData(item.Value);

            index++;
        }

        int close = menuDic.Count - (detailParent.childCount);
        if (close < 0)
        {
            int c = detailParent.childCount - 1;
            for (int i = 0; i < System.Math.Abs(close); i++)
            {
                itemDetails[c].gameObject.SetActive(false);
                c--;
            }
        }
    }
}
