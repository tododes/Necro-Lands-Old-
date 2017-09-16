using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarciaActiveSkill : MonoBehaviour {

    private int coolDown;
    private int currentCoolDown;
    private int skillDuration;
    private PlayerShoot myPlayerShoot;
    private PlayerMove myMovement;
    private ParticleSystem myParticle;
    public bool MarciaSkillActivated;
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
        currentCoolDown = 0;
        coolDown = 30;
        skillDuration = 6;
        myParticle = GetComponentInChildren<ParticleSystem>();
        myParticle.emissionRate = 0f;
        myParticle.startColor = Color.yellow;
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
            
        if (myMovement.isNavigable != (!MarciaSkillActivated))
            myMovement.isNavigable = !MarciaSkillActivated;

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

        if (MarciaSkillActivated)
        {
            transform.Rotate(new Vector3(0, 1440f, 0) * Time.deltaTime);
        }
    }

    public void Skilling()
    {
        StartCoroutine(CountCoolDown());
        StartCoroutine(MarciaActive());
        StartCoroutine(RapidShooting(0.05f));
    }

    IEnumerator RapidShooting(float interval)
    {
        while (MarciaSkillActivated)
        {
            myPlayerShoot.shoot();
            yield return new WaitForSeconds(interval);
        }
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

    IEnumerator MarciaActive()
    {
        myPlayer.Mana -= RequiredMana;
        MarciaSkillActivated = true;
        myParticle.emissionRate = 50f;
        for (int i = 0; i < skillDuration; i++)
        {
            yield return new WaitForSeconds(1);
        }
        MarciaSkillActivated = false;
        myParticle.emissionRate = 0f;
        yield return null;
    }
}
