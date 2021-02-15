﻿using RPG.Core;
using RPG.Movement;
using RPG.Resources;
using RPG.Saving;
using UnityEngine;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction, ISaveable
    {
        [SerializeField] float timeBetweenAtacks = .8f;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Weapon defaultWeapon;

        Weapon currentWeapon;
        Health target;
        float timeSinceLastAttack = Mathf.Infinity;
        private void Start()
        {
            if(currentWeapon == null)
            {
                EquippingWeapon(defaultWeapon);
            }
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;

            if (target.IsDead()) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position,1f);
            }

            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
            }
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead(); 
        }
        private void AttackBehavior()
        {
            transform.LookAt(target.transform.position);
            if (timeSinceLastAttack >= timeBetweenAtacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        public Health GetTarget()
        {
            return target;
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetWeaponRange();
        }

        public void EquippingWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.SpawnWeapon(rightHandTransform, leftHandTransform, animator);
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttacks");
        }

        void Hit()  //Animation Event
        {
            if (target == null) return;

            if (currentWeapon.hasProjectile())
            {
                currentWeapon.LaunchProjectile(rightHandTransform,leftHandTransform, target, gameObject);
            }

            else
            {                
                target.TakeDamage(gameObject,currentWeapon.GetDamage());
            }
        }

        void Shoot()
        {
            Hit();
        }

        public object CaptureState()
        {
            return currentWeapon.name;
        }

        public void RestoreState(object state)
        {
            string weaponName = (string)state;
            Weapon weapon = UnityEngine.Resources.Load<Weapon>(state.ToString());
            EquippingWeapon(weapon);
        }
    }
}
