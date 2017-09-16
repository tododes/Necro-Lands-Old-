using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemShopController : MonoBehaviour {

    private int gold;
    private List<Item> playerItemList = new List<Item>();
    private Text goldText;
    private Text messageText;
    private Color messageTextColor = Color.red;
    private float messageTimer = 0f;
    private GameObject BuyConfirmation;
    private GameObject SellConfirmation;
    private List<Item> items = new List<Item>();
    private int totalPrice;
    private Text totalPriceText;

    private Image DetailImage;
    public Sprite[] detailSprite;
    private int indexing;

    class Item
    {
        public string itemName { get; set; }
        public int itemQty { get; set; }
        public int itemPrice { get; set; }
    }

    // Use this for initialization
    void Start () {
       
        DetailImage = GameObject.Find("DetailImage").GetComponent<Image>();
        DetailImage.enabled = false;
        totalPrice = 0;
        totalPriceText = GameObject.Find("Total Price Text").GetComponent<Text>();

        BuyConfirmation = GameObject.Find("Buy Confirmation");
        BuyConfirmation.SetActive(false);

        SellConfirmation = GameObject.Find("Sell Confirmation");
        SellConfirmation.SetActive(false);

       

        goldText = GameObject.Find("Gold Text").GetComponent<Text>();
        goldText.text = "Gold : " + gold;

        messageText = GameObject.Find("Message Text").GetComponent<Text>();
        messageTextColor.a = 0;
        messageText.color = messageTextColor;

        GetCurrItemPossesion();

        /*for(int i=1; i<=playerItemList.Count; i++)
        {
            PlayerPrefs.DeleteKey("item" + i);
        }

        PlayerPrefs.DeleteKey("gold");

        PlayerPrefs.SetInt("gold", 10000);*/
        //PlayerPrefs.SetInt("gold", 100000);
        gold = PlayerPrefs.GetInt("gold");
    }
	
	// Update is called once per frame
	void Update () {
        goldText.text = "Gold : " + gold + "G";
        totalPriceText.text = "Total Price: " + totalPrice + "G";

        if (DetailImage.sprite != detailSprite[indexing])
            DetailImage.sprite = detailSprite[indexing];
        if(messageTimer > 0f)
        {
            messageTimer -= Time.deltaTime;
            messageTextColor.a = messageTimer/5;
            messageText.color = messageTextColor;
        }
    }

   public void setIndex(int i)
    {
        DetailImage.enabled = true;
        indexing = i;
    }

   public void DisableDetail()
   {
       DetailImage.enabled = false;
   }
    /*bool CheckItemPossesion(string item)
    {
        int idx = playerItemList.IndexOf(item.ToLower());

        Debug.Log("Index" + idx);

        if (idx < 0)
            return false;
        else
            return true;
    }*/

    void SetMessageText(string message)
    {
        messageText.text = message;
        messageTextColor.a = 1;
        messageText.color = messageTextColor;
        messageTimer = 5f;
    }

    void GetCurrItemPossesion()
    {
        playerItemList.Clear();

        for (int i = 1; i <= 20; i++)
        {
            if (!PlayerPrefs.HasKey("item" + i))
                break;
            else
            {
                Item temp = new Item();
                temp.itemName = PlayerPrefs.GetString("item" + i);
                temp.itemQty = PlayerPrefs.GetInt("item" + i + "qty");
                playerItemList.Add(temp);
            }
        }
    }

    void DeleteItems()
    {
        for(int i=0; i<items.Count; i++)
        {
            GameObject.Find(items[i].itemName + " qty").GetComponent<Text>().text = "x0";
        }

        items.Clear();

        totalPrice = 0;
    }

    public void ConfirmBuyItem(string answer)
    {
        if(answer == "yes")
        {
            BuyConfirmation.SetActive(false);

            Debug.Log("item Count" + playerItemList.Count);
            /*if (CheckItemPossesion(itemName))
            {
                SetMessageText("You already have " + itemName);
            }
            else */
            if ((gold - totalPrice) > 0)
            {
                gold -= totalPrice;
                bool exist;
                Debug.Log("Items count:" + items.Count);
                for(int i=0; i<items.Count; i++)
                {
                    exist = false;

                    for(int j=0; j<playerItemList.Count; j++)
                    {
                        if(items[i].itemName.CompareTo(playerItemList[j].itemName.ToLower()) == 0)
                        {
                            PlayerPrefs.SetInt("item" + (j + 1) + "qty", (items[i].itemQty + playerItemList[j].itemQty));
                            exist = true;
                            break;
                        }
                    }

                    if(!exist)
                    {
                        PlayerPrefs.SetString("item" + (playerItemList.Count + 1), items[i].itemName);
                        PlayerPrefs.SetInt("item" + (playerItemList.Count + 1) + "qty", items[i].itemQty);
                        GetCurrItemPossesion();
                    }
                }
                PlayerPrefs.SetInt("gold", gold);
                DeleteItems();
                GetCurrItemPossesion();
            }
            else
            {
                SetMessageText("You don't have enough gold");
            }
        }
        else if(answer == "no")
        {
            BuyConfirmation.SetActive(false);
            //this.item = "";
        }
        
    }

    public void ConfirmSellItem(string answer)
    {
        if(answer == "yes")
        {
            SellConfirmation.SetActive(false);

            Debug.Log("Items count:" + items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < playerItemList.Count; j++)
                {
                    if (items[i].itemName.CompareTo(playerItemList[j].itemName.ToLower()) == 0)
                    {
                        if(items[i].itemQty <= playerItemList[j].itemQty)
                            gold += ((items[i].itemPrice * items[i].itemQty)/2);
                        else
                            gold += ((items[i].itemPrice * playerItemList[j].itemQty) / 2);

                        int qty = playerItemList[j].itemQty - items[i].itemQty;
                        if (qty <= 0)
                        {
                            PlayerPrefs.DeleteKey("item" + (j + 1));
                            PlayerPrefs.DeleteKey("item" + (j + 1) + "qty");
                        }
                        else
                            PlayerPrefs.SetInt("item" + (j + 1) + "qty", qty);
                        break;
                    }
                }
            }

            PlayerPrefs.SetInt("gold", gold);
            DeleteItems();
            GetCurrItemPossesion();
        }
        else if(answer == "no")
        {
            SellConfirmation.SetActive(false);
        }
    }

    public void BuyItem(string item)
    {
        int price = int.Parse(item.Remove(0, item.IndexOf("#") + 1));
        item = item.Substring(0, item.IndexOf("#"));

        if (CheckCurrBuyItem(item) == 1)
        {
            Item temp = new Item();
            temp.itemName = item;
            temp.itemQty = 1;
            temp.itemPrice = price;
            items.Add(temp);
        }

        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].itemName.CompareTo(item) == 0)
                GameObject.Find(item + " qty").GetComponent<Text>().text = "x" + items[i].itemQty;
        }

        TotalPriceCount();
    }

    public void BuyAllItems()
    {
        BuyConfirmation.SetActive(true);
    }

    public void SellAllItems()
    {
        SellConfirmation.SetActive(true);
    }

    public void ResetAllItems()
    {
        DeleteItems();
    }

    public void TotalPriceCount()
    {
        totalPrice = 0;

        for(int i=0; i<items.Count; i++)
        {
            totalPrice += (items[i].itemPrice * items[i].itemQty);
        }
    }

    int CheckCurrBuyItem(string sItem)
    {
        for(int i=0; i<items.Count; i++)
        {
            if(items[i].itemName.CompareTo(sItem) == 0)
            {
                if (items[i].itemQty < (99 - CheckItemQtyPossession(sItem)))
                    items[i].itemQty++;
                else
                    SetMessageText("You can only have 99 " + items[i].itemName);
                return 0;
            }
        }

        return 1;
    }

    int CheckItemQtyPossession(string sItem)
    {
        for(int i=0; i<playerItemList.Count; i++)
        {
            if (sItem.ToLower().CompareTo(playerItemList[i].itemName) == 0)
                return playerItemList[i].itemQty;
        }

        return 0;
    }

    public void BackToGameMenu()
    {
        Application.LoadLevel("Game Menu Scene");
    }

}
