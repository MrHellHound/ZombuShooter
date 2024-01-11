using System.Collections;
using UnityEngine;

namespace Source.Guns
{
    public class Apc9 : MonoBehaviour
    {
        [SerializeField]
        private GunsData gunsData;

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

        private void Start()
        {
            _isShooting = true;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                StartCoroutine(Shoot());
                GameObject newFlash = Instantiate(muzzleFlash, muzzleFlashSpawnPosition.position, muzzleFlashSpawnPosition.rotation);
                Destroy(newFlash, 0.01f);
            }
        }

        private IEnumerator Shoot()
        {
            if (!_isShooting)
                yield break;

            _isShooting = false;
            
            //Спавн пуль
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
            
            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(bulletSpawnLocation.forward * gunsData.bulletForce, ForceMode.Impulse);
            }
            
            Vector3 rightDirection = shellSpawnLocation.right;

            Vector3 worldRightDirection = shellSpawnLocation.TransformDirection(rightDirection);

            //Спавн гильз
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
        }
    }
}
