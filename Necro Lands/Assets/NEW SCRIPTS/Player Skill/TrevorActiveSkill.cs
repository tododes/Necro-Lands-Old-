using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrevorActiveSkill : MonoBehaviour 
{
    private int coolDown;
    private int currentCoolDown;
    private int skillDuration;
    private PlayerShoot myPlayerShoot;
    private PlayerMove myMovement;
    public GameObject TrevorFire;
    private ParticleSystem myParticle;
    private Player myPlayer;

    public float RequiredMana;

    [Header("COOLDOWN DISPLAYER")]
    public Image coolDownImage;
    public Text coolDownText;
    public WarningText warning;

    void Start()
    {
        myPlayer = GetComponent<Player>();
        myPlayerShoot = GetComponent<PlayerShoot>();
        myMovement = GetComponent<PlayerMove>();
        coolDown = 30;
        currentCoolDown = 0;
        skillDuration = 14;
        myParticle = GetComponentInChildren<ParticleSystem>();
        myParticle.emissionRate = 0f;
        myParticle.startColor = Color.Lerp(Color.yellow, Color.red, 0.6f);
        
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
        StartCoroutine(CountCoolDown());
        StartCoroutine(StartParticle());
        TrevorFire.SetActive(true);

    }

  
    IEnumerator StartParticle()
    {
        myPlayer.Mana -= RequiredMana;
        myParticle.emissionRate = 100f;
        for (int i = 0; i < skillDuration; i++)
        {
            yield return new WaitForSeconds(1);
        }
        myParticle.emissionRate = 0f;
        yield return null;
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

   
}
