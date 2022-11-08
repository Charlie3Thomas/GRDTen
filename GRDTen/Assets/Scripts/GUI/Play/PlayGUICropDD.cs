using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayGUICropDD : MonoBehaviour
{
    private string[] crops_list = new string[] {
        "apple",
      "avocado",
      "banana",
      "barley",
      "bean",
      "cashew",
      "cassava",
      "cereal",
      "cocoa bean",
      "coffee bean",
      "grapes",
      "maize",
      "orange",
      "palm oil",
      "pea",
      "potato",
      "rapeseed",
      "rice",
      "rye",
      "seasame",
      "soybean",
      "sugar beet",
      "sugar cane",
      "sunflower seed",
      "sweet potato",
      "tea",
      "tobacco",
      "tomato",
      "wheat",
      "yams"
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
