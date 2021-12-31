using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private PlayerItemPlacerController itemPlacerScript;
    [SerializeField]
    private Transform selector;
    public static int currentItemID=0;
    [SerializeField]
    private TextMeshProUGUI woodcostText;
    [SerializeField]
    private TextMeshProUGUI ironcostText;
    [SerializeField]
    private TextMeshProUGUI ironHaveText;
    [SerializeField]
    private TextMeshProUGUI woodHaveText;
    private string costString;
    [SerializeField]
    private PlayerItemPlacerController myItemController;
    [SerializeField]
    private TextMeshProUGUI woodText;
    public static int woodCount=20;
    [SerializeField]
    private TextMeshProUGUI ironText;
    public static int ironCount=50;
    [SerializeField]
    private TextMeshProUGUI goldText;
    public static int goldCount=0;
    [SerializeField]
    private Slider healthBar;
    public static float healthLeft;
    public static int maxCoin;




    private void Start()
    {
        healthLeft = 100;
        maxCoin = 5;
        ironCount = 3;
        woodCount = 2;
        goldCount = 0;
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !PauseController.paused)
        { 
            currentItemID += 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !PauseController.paused)
        { 
            currentItemID -= 1;
        }
        currentItemID = (currentItemID +9) % 9;

        //if (currentItemID > 0)
        selector.localPosition = new Vector3( (448f / 8f)*(currentItemID)-224f, selector.localPosition.y, selector.localPosition.z);
        //else
        //{ selector.localPosition = new Vector3(999999f, selector.localPosition.y, selector.localPosition.z); }

        woodHaveText.text = "You Have " + woodCount.ToString() + " Wood";
        ironHaveText.text = "You Have " + ironCount.ToString() + " Iron";

        costString = "";
        if (myItemController.woodCost[currentItemID] > 0)
        {
            costString = "Cost\n";
            if (myItemController.woodCost[currentItemID] > woodCount)
            { costString += "<color=#FF0000>"; }
            costString += myItemController.woodCost[currentItemID];
        }
        woodcostText.text = costString;

        costString = "";
        if (myItemController.ironCost[currentItemID] > 0)
        {
            costString = "Cost\n";
            if (myItemController.ironCost[currentItemID] > ironCount)
            { costString += "<color=#FF0000>"; }
            costString += myItemController.ironCost[currentItemID];
        }
        ironcostText.text = costString;


        woodText.text = woodCount.ToString();
        ironText.text = ironCount.ToString();
        goldText.text = goldCount.ToString();


        healthLeft -= Time.deltaTime/20;
        healthBar.value = healthLeft;
    }
}
