using UnityEngine;
using System.Collections;

public class ModeButton : MonoBehaviour {

	public GameObject detailsText;
    public EndlessLevelButton endlessButton;

	private Fading fade;
	public int index;
	private string[] scene = {"Game",
                              "Game - Defending Frenzy",
                              "Main Game - Killing Frenzy",
                              "Game - Kuntil Anak Frenzy",
                              "Game - Pocong Frenzy",
                              "Game - Tuyul Frenzy",
                              "Game - Beguganjang Frenzy",
                              "Game - Leak Frenzy",
                              "Game - Boss Fight",
                              "Game - Mega Boss Fight"};
	private string[] details = 
	{
		"FIGHT AGAINST THE DEDEMITS ENDLESSLY!!",
		"DEFEND AGAINST DEDEMITS FOR 10 MINUTES AND DON'T DIE!!",
		"KILL 150 ENEMIES IN 3 MINUTES",
		"KILL 40 KUNTILANAKS IN 3 MINUTES",
		"KILL 40 POCONGS IN 3 MINUTES",
		"KILL 40 TUYULS IN 3 MINUTES",
		"KILL 40 GENDERUWOS IN 3 MINUTES",
		"KILL 40 LEAKS IN 3 MINUTES",
		"FIGHT AGAINST DEDEMIT BOSSES!!",
		"FIGHT AGAINST DEDEMIT MEGA BOSSES!!"
	};

    public string getSceneName(int i)
    {
        return scene[i];
    }
	// Use this for initialization
	void Start () {
		detailsText.GetComponent<TextMesh> ().text = details [index];

		fade = GameObject.Find ("BlackImage").GetComponent<Fading>();

	}

	void OnMouseEnter()
	{
		gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
	}
	void OnMouseExit()
	{
		gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
	}
	void OnMouseDown()
	{
        GetComponent<AudioSource>().Play();
		//Application.LoadLevel (scene[index]);
        if (index == 0)
        {
            endlessButton.name = scene[index];
            endlessButton.RecordKey = "Scale Record";
            endlessButton.gameObject.SetActive(true);
        }
        else if (index == 8)
        {
            endlessButton.name = scene[index];
            endlessButton.RecordKey = "Boss Scale Record";
            endlessButton.gameObject.SetActive(true);
        }
        else if (index == 9)
        {
            endlessButton.name = scene[index];
            endlessButton.RecordKey = "Mega Boss Scale Record";
            endlessButton.gameObject.SetActive(true);
        }   
        else
		    fade.Finish (scene[index]);
	}
}
