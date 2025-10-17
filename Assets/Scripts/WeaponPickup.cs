using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Transform weaponHoldPoint;

    private GameObject currentWeapon = null;


    private void OnTriggerEnter(Collider other)
    {
   
        if (currentWeapon == null && other.CompareTag("Weapon"))
        {
            Debug.Log("Holding Weapon!");

            currentWeapon = other.gameObject;

            currentWeapon.GetComponent<Collider>().enabled = false;

            if (currentWeapon.GetComponent<Rigidbody>())
            {
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
            }

            currentWeapon.transform.SetParent(weaponHoldPoint);

            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localRotation = Quaternion.identity;
        }
    }
}