using System.Collections;
using Invector.vCharacterController;
using UnityEngine;

namespace Source.Guns.APC_9
{
    public class Apc : MonoBehaviour
    {
        public int bulletsInMag;
        public int bulletsReserve;
        public int bulletsToReload;
        
        [SerializeField]
        private GunsData gunsData;

        [SerializeField] 
        private vThirdPersonController vThirdPersonController;

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

        private bool _isShooting;
        private bool _isReloading;
        
        [SerializeField] private GameObject lowAmmo;
        [SerializeField] private GameObject nowAmmo;

        private void Start()
        {
            _isShooting = true;
            bulletsInMag = gunsData.MagCapacity;
            bulletsToReload = gunsData.MagCapacity;
        }

        private void Update()
        {
            // Логика стрельбы
            if (Input.GetKey(KeyCode.Mouse0) && vThirdPersonController.isStrafing && bulletsInMag != 0 && !_isReloading)
            {
                StartCoroutine(Shoot());
                // Спавн дульной вспышки
                GameObject newFlash = Instantiate(muzzleFlash, muzzleFlashSpawnPosition.position, muzzleFlashSpawnPosition.rotation);
                Destroy(newFlash, 0.01f);
            }
            
            // Логика перезарядки
            if (bulletsInMag < gunsData.MagCapacity && Input.GetKey(KeyCode.R))
            {
                _isReloading = true;
                StartCoroutine(Reload());
            }
            
            // Логика предупреждений
            if (bulletsInMag <= gunsData.AmmoToWarn)
            {
                lowAmmo.SetActive(true);
            }
            if (bulletsInMag == 0)
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
            if (!_isShooting || _isReloading)
                yield break;

            _isShooting = false;

            // Вычисляем угол разброса в зависимости от точности
            float spreadAngle = 180f - gunsData.AccuracyPercentage;

            // Создаем случайное значение в пределах угла разброса
            float randomAngle = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);

            // Применяем случайное вращение к направлению выстрела
            Vector3 bulletDirection = Quaternion.Euler(0f, 0f, randomAngle) * bulletSpawnLocation.forward;

            // Спавн пуль с учетом разброса
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnLocation.position, Quaternion.LookRotation(bulletDirection));
            newBullet.transform.Rotate(-90,0,0);
    
            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(bulletDirection * gunsData.bulletForce, ForceMode.Impulse);
            }
    
            // Спавн гильз
            Vector3 rightDirection = shellSpawnLocation.right;

            Vector3 worldRightDirection = shellSpawnLocation.TransformDirection(rightDirection);
            
            GameObject newShell = Instantiate(shellPrefab, shellSpawnLocation.position, shellSpawnLocation.rotation);
            
            Rigidbody shellRigidbody = newShell.GetComponent<Rigidbody>();
            if (shellRigidbody != null)
            {
                shellRigidbody.AddForce(worldRightDirection * gunsData.shellForce, ForceMode.Impulse);
            }
            
            Destroy(newShell, 3f);
            Destroy(newBullet, 3f);

            yield return new WaitForSeconds(1 / (gunsData.FireRate / 60f));

            _isShooting = true;
            bulletsInMag--;
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(gunsData.ReloadTime);

            if (bulletsInMag < gunsData.MagCapacity && bulletsReserve > 0)
            {
                int bulletsToReloadNow = Mathf.Min(bulletsToReload, gunsData.MagCapacity - bulletsInMag, bulletsReserve);
                bulletsReserve -= bulletsToReloadNow;
                bulletsInMag += bulletsToReloadNow;
            }
            _isReloading = false;
        }
    }
}
