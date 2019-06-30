using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {
    public Slider sMaxHealth;
    public Slider sHealthRegen;
    public Slider sBodyDamage;
    public Slider sBulletDamage;
    public Slider sBulletDurability;
    public Slider sBulletSpeed;
    public Slider sReload;
    public Slider sMovement;

    TankStats tankStats;

    private void Start() {
        tankStats = GameManager.GM.tankStats;
    }

    public void UPMaxHealth() {
        if (tankStats.pointStat < 1 || sMaxHealth.value >= 6)
            return;

        sMaxHealth.value++;
        tankStats.pointStat--;
        tankStats.maxHealth += 50f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    public void UPHealthRegen() {
        if (tankStats.pointStat < 1 || sHealthRegen.value >= 6)
            return;

        sHealthRegen.value++;
        tankStats.pointStat--;
        tankStats.healthRegen += 2f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    public void UPBodyDamage() {
        if (tankStats.pointStat < 1 || sBodyDamage.value >= 6)
            return;

        sBodyDamage.value++;
        tankStats.pointStat--;
        tankStats.bodyDamage += 5f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    public void UPBulletDamage() {
        if (tankStats.pointStat < 1 || sBulletDamage.value >= 6)
            return;

        sBulletDamage.value++;
        tankStats.pointStat--;
        tankStats.bulletDamage += 5f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    public void UPBulletDurability() {
        if (tankStats.pointStat < 1 || sBulletDurability.value >= 6)
            return;

        sBulletDurability.value++;
        tankStats.pointStat--;
        tankStats.bulletDurability += 3f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    public void UPBulletSpeed() {
        if (tankStats.pointStat < 1 || sBulletSpeed.value >= 6)
            return;

        sBulletSpeed.value++;
        tankStats.pointStat--;
        tankStats.bulletSpeed += 2f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    public void UPReload() {
        if (tankStats.pointStat < 1 || sReload.value >= 6)
            return;

        sReload.value++;
        tankStats.pointStat--;
        tankStats.reloadSpeed -= 0.05f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    public void UPMovement() {
        if (tankStats.pointStat < 1 || sMovement.value >= 6)
            return;

        sMovement.value++;
        tankStats.pointStat--;
        tankStats.movementSpeed += 0.35f;
        UIManager.UM.UpdateUIUpgrade(tankStats.pointStat);
    }

    
}
