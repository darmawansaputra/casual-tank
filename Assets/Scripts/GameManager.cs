using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager GM;
    public Text txtScore;
    public TankStats tankStats;

    public Transform farmParent;
    public Farm[] farmPrefab;

    public float timer = 0;

    public float[] expTarget = {
        10f, 20f, 30f, 40f, 55f, 60f, 75f, 90f, 105f,
        135f, 165f, 195f, 225f, 255f, 285f, 315f, 345f, 375f, 405f,
        455f, 505f, 555f, 605f, 655f, 705f, 755f, 805f, 855f, 905f
    };

    public bool saved = false;

	// Use this for initialization
	void Awake () {
        //int id = Array.IndexOf(expTarget, 505);

        GM = this;
    }

    private void Start() {
        StartCoroutine("SpawnFarmPopulate");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SaveLeaderboard() {
        int score = Mathf.RoundToInt(timer);
        txtScore.text = score + " Detik";

        saved = true;

        if(PlayerPrefs.HasKey("H1") && score < PlayerPrefs.GetInt("H1", 0)) {
            int temp1 = PlayerPrefs.GetInt("H1", 0);
            PlayerPrefs.SetInt("H1", score);

            if(PlayerPrefs.HasKey("H2")) {
                int temp2 = PlayerPrefs.GetInt("H2", 0);
                PlayerPrefs.SetInt("H2", temp1);

                if(PlayerPrefs.HasKey("H3")) {
                    int temp3 = PlayerPrefs.GetInt("H3", 0);
                    PlayerPrefs.SetInt("H2", temp2);

                    if(PlayerPrefs.HasKey("H4")) {
                        int temp4 = PlayerPrefs.GetInt("H4", 0);
                        PlayerPrefs.SetInt("H4", temp3);

                        PlayerPrefs.SetInt("H5", temp4);
                    }
                    else
                        PlayerPrefs.SetInt("H4", temp3);
                }
                else
                    PlayerPrefs.SetInt("H3", temp2);
            }
            else
                PlayerPrefs.SetInt("H2", temp1);
        }
        else if(PlayerPrefs.HasKey("H2") && score < PlayerPrefs.GetInt("H2", 0)) {
            int temp2 = PlayerPrefs.GetInt("H2", 0);
            PlayerPrefs.SetInt("H2", score);

            if(PlayerPrefs.HasKey("H3")) {
                int temp3 = PlayerPrefs.GetInt("H3", 0);
                PlayerPrefs.SetInt("H2", temp2);

                if(PlayerPrefs.HasKey("H4")) {
                    int temp4 = PlayerPrefs.GetInt("H4", 0);
                    PlayerPrefs.SetInt("H4", temp3);

                    PlayerPrefs.SetInt("H5", temp4);
                }
                else
                    PlayerPrefs.SetInt("H4", temp3);
            }
            else
                PlayerPrefs.SetInt("H3", temp2);
        }
        else if(PlayerPrefs.HasKey("H3") && score < PlayerPrefs.GetInt("H3", 0)) {
            int temp3 = PlayerPrefs.GetInt("H3", 0);
            PlayerPrefs.SetInt("H2", score);

            if(PlayerPrefs.HasKey("H4")) {
                int temp4 = PlayerPrefs.GetInt("H4", 0);
                PlayerPrefs.SetInt("H4", temp3);

                PlayerPrefs.SetInt("H5", temp4);
            }
            else
                PlayerPrefs.SetInt("H4", temp3);
        }
        else if(PlayerPrefs.HasKey("H4") && score < PlayerPrefs.GetInt("H4", 0)) {
            int temp4 = PlayerPrefs.GetInt("H4", 0);
            PlayerPrefs.SetInt("H4", score);

            PlayerPrefs.SetInt("H5", temp4);
        }
        else if(PlayerPrefs.HasKey("H5") && score < PlayerPrefs.GetInt("H5", 0)) {
            PlayerPrefs.SetInt("H5", score);
        }
        else if(!PlayerPrefs.HasKey("H1"))
            PlayerPrefs.SetInt("H1", score);
        else if(!PlayerPrefs.HasKey("H2"))
            PlayerPrefs.SetInt("H2", score);
        else if(!PlayerPrefs.HasKey("H3"))
            PlayerPrefs.SetInt("H3", score);
        else if(!PlayerPrefs.HasKey("H4"))
            PlayerPrefs.SetInt("H4", score);
        else if(!PlayerPrefs.HasKey("H5"))
            PlayerPrefs.SetInt("H5", score);
    }

    void FixedUpdate() {
        if(!saved)
            timer += Time.fixedDeltaTime;
    }

    IEnumerator SpawnFarmPopulate() {
        while(true) {
            if (farmParent.childCount <= 193)
                SpawnPopulationFarm();

            yield return new WaitForSeconds(3f);
        }
    }

    void SpawnPopulationFarm() {
        float xCenter = UnityEngine.Random.Range(-50, 50);
        float yCenter = UnityEngine.Random.Range(-45, 45);

        //Spawn 7 farm
        for(int i = 0; i < 7; i++) {
            Farm f = farmPrefab[UnityEngine.Random.Range(0, farmPrefab.Length)];

            float x = UnityEngine.Random.Range(xCenter - 6, xCenter + 6);
            float y = UnityEngine.Random.Range(yCenter - 6, yCenter + 6);

            Instantiate(f, new Vector2(x, y), Quaternion.identity, farmParent);
        }
    }
}
