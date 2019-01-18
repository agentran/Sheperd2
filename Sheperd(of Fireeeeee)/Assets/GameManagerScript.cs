using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour {


    public float Score;
    public TextMeshProUGUI ScoreText;
    public List<GameObject> Herd = new List<GameObject>();

	// Use this for initialization
	void Start () {
		foreach(HerdMovement sheep in FindObjectsOfType<HerdMovement>())
        {
            Herd.Add(sheep.transform.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(float howmuch)
    {
        Score += howmuch;
        ScoreText.text = "Score - " + Score;
    }

    public void ActiveOrDeactiveAllHerdMovementScripts()
    {
        foreach(GameObject sheep in Herd)
        {
            sheep.GetComponent<HerdMovement>().enabled = !sheep.GetComponent<HerdMovement>().enabled;
        }
    }
}
