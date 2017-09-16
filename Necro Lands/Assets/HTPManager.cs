using UnityEngine;
using System.Collections;
using Todo;

public class HTPManager : MonoBehaviour {
    public static int trainIndex;
    GameObject guideText,sprite;
    string[] guide = {"Press W, A, S, and D to move","Click on the left mouse button to shoot","Go to shop and buy items that strengthen\nyour attribute",
                      "Equip your items bought from the shop\n at the equipment menu","Each characters have different ability\nto harm the enemies",
                      "Each enemies also have different abilities\nto harm the character","There are multiple game modes in this\ngame that you need to give a shot!!"};
    

    void Start()
    {
        trainIndex = 1;
        guideText = GameObject.Find("guideText");
       
    }

    void Update()
    {
        guideText.GetComponent<TextMesh>().text = guide[trainIndex-1];
        for (int i = 1; i <= 7; i++)
        {
            if (i == trainIndex)
            {
                Action.SetY(GameObject.Find("G"+i).name,0f);
            }
            else
            {
                Action.SetY(GameObject.Find("G" + i).name, 10f);
            }
        }
    }
}
