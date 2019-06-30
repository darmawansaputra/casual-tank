using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text txtScore1;
    public Text txtScore2;
    public Text txtScore3;
    public Text txtScore4;
    public Text txtScore5;

    void Awake() {
        if(PlayerPrefs.HasKey("H1"))
            txtScore1.text = "1. " + PlayerPrefs.GetInt("H1", 0) + " Detik";
        else
            txtScore1.text = "1. -";

        if(PlayerPrefs.HasKey("H2"))
            txtScore2.text = "2. " + PlayerPrefs.GetInt("H2", 0) + " Detik";
        else
            txtScore2.text = "2. -";

        if(PlayerPrefs.HasKey("H3"))
            txtScore3.text = "3. " + PlayerPrefs.GetInt("H3", 0) + " Detik";
        else
            txtScore3.text = "3. -";

        if(PlayerPrefs.HasKey("H4"))
            txtScore4.text = "4. " + PlayerPrefs.GetInt("H4", 0) + " Detik";
        else
            txtScore4.text = "4. -";

        if(PlayerPrefs.HasKey("H5"))
            txtScore5.text = "5. " + PlayerPrefs.GetInt("H5", 0) + " Detik";
        else
            txtScore5.text = "5. -";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
