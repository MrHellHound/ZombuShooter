using Source.Guns.APC_9;
using TMPro;
using UnityEngine;

namespace Source.UI
{
    public class AmmoCounter : MonoBehaviour
    {
        public Apc apc;
        [SerializeField] private TextMeshProUGUI apcAmmo;
        [SerializeField] private TextMeshProUGUI apcAmmoReserve;
        private void Update()
        {
            apcAmmo.text = apc.bulletsInMag.ToString();
            apcAmmoReserve.text = apc.bulletsReserve.ToString();
        }
    }
}
