using RPG.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickup : MonoBehaviour, IRaycastable
    {
        [SerializeField] Weapon weapon;
        [SerializeField] float respawnTime = 4f;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                Pickup(other.GetComponent<Fighter>());
            }
        }

        private void Pickup(Fighter fighter)
        {
            fighter.EquippingWeapon(weapon);
            StartCoroutine(HideForSeconds(respawnTime));
        }

        private IEnumerator HideForSeconds(float seconds)
        {
            ShowAndHidePickUp(false);
            yield return new WaitForSeconds(seconds);
            ShowAndHidePickUp(true);

        }


        private void ShowAndHidePickUp(bool shouldShow)
        {
            GetComponent<SphereCollider>().enabled = shouldShow;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                    transform.GetChild(i).gameObject.SetActive(shouldShow);
            }
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Pickup(callingController.GetComponent<Fighter>());
            }
            return true;
        }

        public CursorType GetCursorType()
        {
            return CursorType.Pickup;
        }
    }
}
