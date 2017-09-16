using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StoryState : MonoBehaviour {
    
    private string[] words =
    {
        "...........","Where am I ??","Where are the others ??", "..........", "What's going on here??", "HEEEEYYY, WHERE ARE YOU??","","HAHAHAHA !!",
        "YOU'RE TRAPPED, INTRUDER!!","TRAPPED??? WHAT DO YOU MEAN TRAPPED??","HAHAHA!! WELCOME TO OUR REALM, THE NECRO REALM !!", "........................",
        "AND THIS LAND IS ONE OF THE PART OT THE REALM","WE CALL IT THE NECROLAND","WHO ARE YOU??","WE CALL OURSELVES DEDEMIT, WHICH MEANS EVIL SPIRIT","I'M KUNTILANAK, THE SOUL OF A DEAD PREGNANT",
        "I'M TUYUL, THE DEAD KID","BEHOLD THE BEGUGANJANG, A SUMMONED SPIRIT FROM BLACK MAGIC","I'M LEAK THE GHOSTLY WITCH", "FINALLY I'M POCONG, A SHROUDED GHOST THAT AWAKED FROM GRAVE!!",
        "UMM IS THERE ANY WAY I CAN GET OUT OF HERE??", "ABSOLUTELY NO, KID!!","YOU WILL BE TRAPPED IN THIS REALM FOREVER!!!",""
    };
    private Text text;
    private Image image, spriteImage, arrowImage;
    public static int counter = 0;
    public static bool skipPermitted = true, sceneFinished = false;
   
	// Use this for initialization
	void Start ()
    {
     
        spriteImage = GameObject.Find("Image (1)").GetComponent<Image>();
        text = GameObject.Find("StoryText").GetComponent<Text>();
        image = GameObject.Find("ConText").GetComponent<Image>();
        arrowImage = GameObject.Find("ArrowImage").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0)) && skipPermitted)
        {
            counter++;
            Debug.Log(counter);
        }
        Conditional();
        SetText(words[counter]);
    }

    void Conditional()
    {
        if (counter == 6)
        {
            Disable();
            skipPermitted = false;
        }
        if (counter == 7)
        {
            Enable();
        }

        if (counter == 24 || counter == 25)
        {
            Disable();
            sceneFinished = true;
            skipPermitted = false;
        }
    }

    void Enable()
    {
        image.enabled = true;
        spriteImage.enabled = true;
        arrowImage.enabled = true;
    }

    void Disable()
    {
        image.enabled = false;
        spriteImage.enabled = false;
        arrowImage.enabled = false;
    }

    void SetText(string txt)
    {
        text.text = txt;
    }
}
