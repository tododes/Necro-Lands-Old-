using UnityEngine;
using System.Collections;

public class SkillNode : MonoBehaviour {

    public status s;
    public enum status {rootNode, branchNode};
    public string sibling;
    public string parent;
   // public Color scolor;

    void Start()
    {
        for (int i = 1; i <= 7; i++)
        {
            if (GameObject.Find("s" + i).name != this.gameObject.name)
            {
                if (GameObject.Find("s" + i).GetComponent<SkillNode>().parent == parent && GameObject.Find("s" + i).GetComponent<Transform>().position.y == transform.position.y)
                {
                    sibling = GameObject.Find("s" + i).name;
                    break;
                }
            }
            if (i == 1)
            {
                GameObject.Find("s" + i).GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        GameObject.Find(PlayerPrefs.GetString("currSkill")).GetComponent<SpriteRenderer>().color = Color.red;
    }

    void Update()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.red && s == status.branchNode)
        {
            GameObject.Find(parent).GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    
	void OnMouseDown()
    {
        
        if (s == status.branchNode)
        {
            if (PlayerPrefs.GetString("currSkill") == parent && GameObject.Find(sibling).GetComponent<SpriteRenderer>().color != Color.red)
            {
                PlayerPrefs.SetString("currSkill", this.gameObject.name);
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            PlayerPrefs.SetString("currSkill", this.gameObject.name);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }


    }
}
