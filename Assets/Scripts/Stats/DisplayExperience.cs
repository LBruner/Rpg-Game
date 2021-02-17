using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    class DisplayExperience : MonoBehaviour
    {
        [SerializeField] Text xpText;
        Experience experience;


        private void Start()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        private void Update()
        {
            xpText.text = string.Format("{0:0}", experience.GetXP());
        }
    }
}