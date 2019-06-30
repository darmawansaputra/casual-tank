using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager UM;
    public Text txtPointAvailable;
    public Text txtProfile;
    public Slider sliderExp;

    private void Start() {
        UM = this;
    }

    public void UpdateUIUpgrade(int point) {
        txtPointAvailable.text = "Point Available: " + point;
    }

    public void UpdateUIProfile(int level, float exp, float maxExp) {
        txtProfile.text = "Tank Level " + level;
        sliderExp.value = exp;
        sliderExp.maxValue = maxExp;
    }
}
