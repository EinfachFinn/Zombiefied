/// <summary>
/// This script belongs to cowsins� as a part of the cowsins� FPS Engine. All rights reserved. 
/// </summary>
using UnityEngine;
namespace cowsins {
[System.Serializable]
public class DefaultAttachment
{
    public Attachment defaultBarrel,
        defaultScope,
        defaultStock,
        defaultGrip,
        defaultMagazine,
        defaultFlashlight,
        defaultLaser;
}
/// <summary>
/// Attach this to your weapon object ( the one that goes in the weapon array of WeaponController )
/// </summary>
public class WeaponIdentification : MonoBehaviour
{
    public Weapon_SO weapon;

    [Tooltip("Every weapon, excluding melee, must have a firePoint, which is the point where the bullet comes from." +
        "Just make an empty object, call it firePoint for organization purposes and attach it here. ")]
    public Transform[] FirePoint;

    [HideInInspector] public int totalMagazines, magazineSize, bulletsLeftInMagazine, totalBullets; // Internal use

    [Tooltip("Defines the default attachments for your weapon. The first time you pick it up, these attachments will be equipped.")]public DefaultAttachment defaultAttachments; 

    [HideInInspector]public Attachment barrel, 
        scope, 
        stock, 
        grip, 
        magazine, 
        flashlight, 
        laser;


    [Tooltip("Defines all the attachments that can be equipped on your weapon.")]public CompatibleAttachments compatibleAttachments;

        [HideInInspector] public float heatRatio; 

    private void Start()
    {
        totalMagazines = weapon.totalMagazines;
        GetMagazineSize(); 
        GetComponentInChildren<Animator>().keepAnimatorStateOnDisable = true;
    }

    public void GetMagazineSize()
    {
        if (magazine == null) magazineSize = weapon.magazineSize;
        else magazineSize = weapon.magazineSize + magazine.GetComponent<Magazine>().magazineCapacityAdded;

        if (bulletsLeftInMagazine > magazineSize) bulletsLeftInMagazine = magazineSize; 
    }
}
}