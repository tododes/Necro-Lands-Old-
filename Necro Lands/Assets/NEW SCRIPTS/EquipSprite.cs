using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class EquipSprite : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler{
    public GameObject[] items;
    public Sprite[] itemDetails;
    public int index;
    public Image itemDetailImage;
    
    public bool CanActivate;

    public GameObject myObject;

    private int PositionInList;
    private bool SpriteInit = false;
    private bool AttributeInit = false;
    private Player OurClient;
    private Modifier modifier;
    private int qty;

    public Image coolDownImage;
    public Text coolDownText;

    public int skillCoolDown;

    public WarningText warning;

    public int EquipExp, EquipLevel;

	// Use this for initialization
	void Start () 
    {
        MergeSortItems(items, 0, items.Length - 1);
        myObject = findObject(items, 0, items.Length-1, PlayerPrefs.GetString("equip"+index));
        EquipExp = PlayerPrefs.GetInt(myObject.name + " Exp");
        EquipLevel = PlayerPrefs.GetInt(myObject.name + " Level");
        // Debug.Log(PlayerPrefs.GetInt("equipqty" + index));
        qty = PlayerPrefs.GetInt("equipqty" + index);
        Debug.Log(myObject.name + " : " + qty);
        OurClient = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
        modifier = OurClient.gameObject.GetComponentInChildren<Modifier>();
        skillCoolDown = 0;
        coolDownImage.enabled = false;
        coolDownText.enabled = false;
	}

    IEnumerator CountCoolDown()
    {
        skillCoolDown = myObject.GetComponent<Item>().coolDown;
        coolDownImage.enabled = true;
        coolDownText.enabled = true;
        while(skillCoolDown > 0)
        {
            skillCoolDown--;
            coolDownText.text = skillCoolDown.ToString();
            yield return new WaitForSeconds(1);
        }
        coolDownImage.enabled = false;
        coolDownText.enabled = false;
        yield return null;
    }

    IEnumerator Activate()
    {
        for (int i = 0; i < qty; i++)
        {
            myObject.GetComponent<Item>().ActivateExtraAttributes(OurClient);
            myObject.GetComponent<Item>().ActivateExtraModifiers(modifier);
        }
        for (int i = 0; i < myObject.GetComponent<Item>().duration; i++)
        {
            yield return new WaitForSeconds(1);
        }
        for (int i = 0; i < qty; i++)
        {
            myObject.GetComponent<Item>().DeActivateExtraAttributes(OurClient);
            myObject.GetComponent<Item>().DeActivateExtraModifiers(modifier);
        }
        yield return null;
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (CanActivate && skillCoolDown == 0)
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(Activate());
            StartCoroutine(CountCoolDown());
        }
        else if (CanActivate && skillCoolDown > 0)
        {
            warning.DisplayWarning("ON COOLDOWN");
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (myObject != this.gameObject)
        {
            itemDetailImage.enabled = true;
            itemDetailImage.sprite = itemDetails[PositionInList];
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        itemDetailImage.enabled = false;
    }
	
	void Update () 
    {
        if (!SpriteInit)
        {
            if (myObject == gameObject)
            {
                gameObject.GetComponent<Image>().color = Color.black;
            }
            else 
            {
                gameObject.GetComponent<Image>().sprite = myObject.GetComponent<SpriteRenderer>().sprite;
                
            }
            
            SpriteInit = true;
        }

        if (!AttributeInit)
        {
           
            if (myObject != gameObject)
            {
            
                CanActivate = myObject.GetComponent<Item>().CanActivate;
                for (int i = 0; i < qty; i++)
                {
                   
                    myObject.GetComponent<Item>().AddAttributes(OurClient);
                    myObject.GetComponent<Item>().AddModifiers(modifier);
                    
                }
            }
            AttributeInit = true;
        }

        if(EquipExp >= 50 + 5 * (EquipLevel-1) * (EquipLevel-1) * (EquipLevel-1))
        {
            EquipExp -= 50 + 7 * (EquipLevel - 1) * (EquipLevel - 1) * (EquipLevel - 1);
            EquipLevel++;
            PlayerPrefs.SetInt(myObject.name + " Level", EquipLevel);
        }
	}

    
    GameObject findObject(GameObject[] g, int low, int high, string n)
    {
        int mid;
        if (g.Length == 0)
            return this.gameObject;
        if (low >= high)
        {
            if (low == high && g[low].name.CompareTo(n) == 0)
                return g[low];
            return this.gameObject;
        }
       if (low <= high)
        {
           
            mid = (low + high) / 2;
           if (g[mid].name.CompareTo(n) == 0)
           {
               PositionInList = mid;
               return g[mid];
           }
            else if (g[mid].name.CompareTo(n) > 0)
                return findObject(g, low, mid, n);
            return findObject(g, mid+1, high, n);
        }
       return this.gameObject;
    }

    void MergeSortItems(GameObject[] g, int low, int high)
    {
       
        int mid;
        if (low < high)
        {
            mid = (low + high) / 2;
            MergeSortItems(g, low, mid);
            MergeSortItems(g, mid + 1, high);
            MergeItems(g,low,mid,high);
        }
    }

    void MergeItems(GameObject[] g, int low, int mid, int high)
    {
        int a = low;
        int b = mid + 1;
        int c = low;
       
        GameObject[] temps = new GameObject[g.Length];
        while (a <= mid && b <= high)
        {
            if (g[a].name.CompareTo(g[b].name) < 0)
            {
                
                temps[c] = g[a];
                a++;
                c++;
            }
            else
            {
               
                temps[c] = g[b];
                b++;
                c++;
            }
        }
        while (a <= mid)
        {
            temps[c] = g[a];
            a++;
            c++;
        }
        while (b <= high)
        {
            temps[c] = g[b];
            b++;
            c++;
        }

        for (int i = low; i < c; i++)
        {
            g[i] = temps[i];
        }
       
    }
     
}
