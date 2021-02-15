using RPG.Combat;
using RPG.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        [SerializeField] Text enemyHealthValue;

        private void Awake()
        {
            
        }

        private void Update()
        {
            Fighter player = GameObject.FindWithTag("Player").GetComponent<Fighter>();
            Health target = player.GetTarget();

            if (target == null)
            {
                enemyHealthValue.text = "N/A ENEMY";
            }
            else
            {
                enemyHealthValue.text = string.Format("{0:0}%", target.GetPercentage());
            }
        }
    }
}
