using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LucyActiveSkill : MonoBehaviour {

    private int coolDown;
    private int currentCoolDown;
    private int skillDuration;
    private Player myPlayer;
    private ParticleSystem myParticle;

    public float RequiredMana;

    [Header("COOLDOWN DISPLAYER")]
    public Image coolDownImage;
    public Text coolDownText;
  
    public bool LucySkillActivated;

    public WarningText warning;

    void Awake()
    {
        myPlayer = GetComponent<Player>();
        coolDown = 40;
        currentCoolDown = 0;
        skillDuration = 25;
        myParticle = GetComponentInChildren<ParticleSystem>();
        myParticle.emissionRate = 0f;
        myParticle.startColor = Color.magenta;
    }

    IEnumerator CountCoolDown()
    {
        currentCoolDown = coolDown;
        for (int i = 0; i < coolDown; i++)
        {
            currentCoolDown--;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    IEnumerator SwapDamage()
    {
        myPlayer.Mana -= RequiredMana;
        myParticle.emissionRate = 50f;
        LucySkillActivated = true;
        float temp = myPlayer.Attack;
        myPlayer.Attack = myPlayer.Armor;
        myPlayer.Armor = temp;
        for (int i = 0; i < skillDuration; i++)
        {
            yield return new WaitForSeconds(1);
        }
        myParticle.emissionRate = 0f;
        temp = myPlayer.Attack;
        myPlayer.Attack = myPlayer.Armor;
        myPlayer.Armor = temp;
        LucySkillActivated = false;
        yield return null;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (currentCoolDown <= 0 && coolDownText.text != "")
        {
            coolDownImage.enabled = false;
            coolDownText.text = "";
        }
        else if (currentCoolDown > 0 && coolDownText.text != currentCoolDown.ToString())
        {
            coolDownImage.enabled = true;
            coolDownText.text = currentCoolDown.ToString();
        }
            
        if (Input.GetKeyDown(KeyCode.Q) && currentCoolDown == 0 && myPlayer.Mana >= RequiredMana)
        {
            Skilling();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentCoolDown > 0)
        {
            warning.DisplayWarning("ON COOLDOWN");
        }
        else if (Input.GetKeyDown(KeyCode.Q) && myPlayer.Mana < RequiredMana)
        {
            warning.DisplayWarning("NOT ENOUGH MANA");
        }
	}

    public void Skilling()
    {
        StartCoroutine(CountCoolDown());
        StartCoroutine(SwapDamage());
    }
}
