using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayGUICropDD : MonoBehaviour
{
    private string[] crops_list = new string[] {
      "Apples",
      "Avocados",
      "Bananas",
      "Barley",
      "Beans",
      "Cashews",
      "Cassava",
      "Cereals",
      "Cocoa Beans",
      "Coffee Beans",
      "Grapes",
      "Maize",
      "Oranges",
      "Palm oil",
      "Peas",
      "Potatoes",
      "Rapeseed",
      "Rice",
      "Rye",
      "Seasame",
      "Soybeans",
      "Sugar beets",
      "Sugar canes",
      "Sunflower seeds",
      "Sweet potatoes",
      "Tea",
      "Tobacco",
      "Tomatoes",
      "Wheat",
      "Yams"
    };

    [SerializeField] private TMPro.TMP_Dropdown dd_menu;
    [SerializeField] private GameObject[] dd_text;

    private void Start()
    {
        dd_menu.onValueChanged.AddListener(delegate { DDValueChange(); });
        foreach (GameObject go in dd_text)
        {
            go.GetComponent<TextMeshProUGUI>().text = crops_list[dd_menu.value];
        }
    }

    private void DDValueChange()
    {
        //Debug.Log(crops_list[dd_menu.value]);
        foreach (GameObject go in dd_text)
        {
            go.GetComponent<TextMeshProUGUI>().text = crops_list[dd_menu.value];
        }
        CropSelectionManager.instance.selection = dd_menu.value;
    }

}
