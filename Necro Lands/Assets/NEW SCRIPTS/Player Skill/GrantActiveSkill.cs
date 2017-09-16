using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GrantActiveSkill : MonoBehaviour {
    public bool GrantSkillActivated;
    private int coolDown;
    private int skillDuration;
    private int currentCoolDown;
    private ParticleSystem myParticle;
    private Player myPlayer;

    public float RequiredMana;


    [Header("COOLDOWN DISPLAYER")]
    public Image coolDownImage;
    public Text coolDownText;
    public WarningText warning;

	// Use this for initialization
	void Awake () 
    {
        myPlayer = GetComponent<Player>();
        GrantSkillActivated = false;
        currentCoolDown = 0;
        coolDown = 40;
        skillDuration = 20;
        myParticle = GetComponentInChildren<ParticleSystem>();
        myParticle.emissionRate = 0f;
        myParticle.startColor = Color.green;
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

    IEnumerator GrantSkill()
    {
        myPlayer.Mana -= RequiredMana;
        GrantSkillActivated = true;
        myParticle.emissionRate = 50f;
        for (int i = 0; i < skillDuration; i++)
        {
            yield return new WaitForSeconds(1);
        }
        GrantSkillActivated = false;
        myParticle.emissionRate = 0f;
        yield return null;
    }

    void Update()
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
        StartCoroutine(GrantSkill());
        StartCoroutine(CountCoolDown());
    }
}
