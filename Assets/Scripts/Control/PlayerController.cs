using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;

namespace RPG.Control
{
    
    public class PlayerController : MonoBehaviour
    {
        bool nowhereToClick;
        private void Update()
        {
            if (InteractWithCombat())
                return;
            if (InteractWithMovement())
                return;
            Debug.Log("Inrasir");
            
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();
                if (combatTarget == null)
                    continue;

                if(Input.GetMouseButtonDown(0))
                    GetComponent<Fighter>().Attack(combatTarget);

                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {       
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                    GetComponent<Mover>().MoveTo(hit.point);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
