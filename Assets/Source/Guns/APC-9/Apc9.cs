using System.Collections;
using Source.Player;
using UnityEngine;

namespace Source.Guns.APC_9
{
    public class Apc9 : MonoBehaviour
    {
        [SerializeField]
        private GunsData gunsData;

        [SerializeField] 
        private PlayerMove playerMove;

        [SerializeField]
        private Transform bulletSpawnLocation;

        [SerializeField] 
        private GameObject bulletPrefab;
    
        [SerializeField]
        private Transform shellSpawnLocation;

        [SerializeField] private Transform muzzleFlashSpawnPosition;
        [SerializeField] private GameObject muzzleFlash;

        [SerializeField]
        private GameObject shellPrefab;

        private int _bulletsInMag;
        
        private bool _isShooting;
        private bool _isReloading;
        
        [SerializeField] private GameObject lowAmmo;
        [SerializeField] private GameObject nowAmmo;

        private void Start()
        {
            _isShooting = true;
            _bulletsInMag = gunsData.MagCapacity;
        }

        private void Update()
        {
            // Логика стрельбы
            if (Input.GetKey(KeyCode.Mouse0) && playerMove.isSighting && _bulletsInMag != 0 && !_isReloading)
            {
                StartCoroutine(Shoot());
                GameObject newFlash = Instantiate(muzzleFlash, muzzleFlashSpawnPosition.position, muzzleFlashSpawnPosition.rotation);
                Destroy(newFlash, 0.01f);
            }
            
            // Логика перезарядки
            if (_bulletsInMag < gunsData.MagCapacity && Input.GetKey(KeyCode.R))
            {
                _isReloading = true;
                StartCoroutine(Reload());
            }
            
            // Логика предупреждений
            if (_bulletsInMag <= gunsData.AmmoToWarn)
            {
                lowAmmo.SetActive(true);
            }
            if (_bulletsInMag == 0)
            {
                lowAmmo.SetActive(false);
                nowAmmo.SetActive(true);
            }
            if (_isReloading)
            {
                lowAmmo.SetActive(false);
                nowAmmo.SetActive(false);
            }
        }

        private IEnumerator Shoot()
        {
            if (!_isShooting)
                yield break;

            _isShooting = false;
            
            // Спавн пуль
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
            newBullet.transform.Rotate(-90,0,0);
            
            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(bulletSpawnLocation.forward * gunsData.bulletForce, ForceMode.Impulse);
            }
            
            Vector3 rightDirection = shellSpawnLocation.right;

            Vector3 worldRightDirection = shellSpawnLocation.TransformDirection(rightDirection);

            // Спавн гильз
            GameObject newShell = Instantiate(shellPrefab, shellSpawnLocation.position, shellSpawnLocation.rotation);
            
            Rigidbody shellRigidbody = newShell.GetComponent<Rigidbody>();
            if (shellRigidbody != null)
            {
                shellRigidbody.AddForce(worldRightDirection * gunsData.shellForce, ForceMode.Impulse);
            }
            
            Destroy(newBullet, 3f);
            Destroy(newShell, 3f);

            yield return new WaitForSeconds(1 / (gunsData.FireRate / 60f));
            
            _isShooting = true;
            _bulletsInMag--;
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(gunsData.ReloadTime);
            _bulletsInMag = gunsData.MagCapacity;
           _isReloading = false;
        }
    }
}
