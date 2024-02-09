using System.Collections;
using UnityEngine;

namespace Source.Enemies
{
    public class EnemyFollow : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float moveSpeed;
        
        private Vector3 _initialPosition;
        private bool _isAttacking;
        private bool _bulletInRange;

        private void Start()
        {
            _isAttacking = false;
            _bulletInRange = false;
        }

        private void Update()
        {
            _initialPosition = transform.position;

            if (_bulletInRange && !_isAttacking)
            {
                StartCoroutine(Offensive());
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_isAttacking)
            {
                FollowPlayer();
            }

            if (other.CompareTag("Bullet") && !_isAttacking)
            {
                _bulletInRange = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && !_isAttacking)
            {
                transform.position = _initialPosition;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && !_isAttacking)
            {
                StartCoroutine(Attack());
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Player") && _isAttacking)
            {
                StopCoroutine(Attack());
            }
        }
        
        private void FollowPlayer()
        {
            Vector3 direction = player.position - transform.position;

            direction.Normalize();
                
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        
        private IEnumerator Offensive()
        {
            FollowPlayer();

            yield return new WaitForSeconds(3f);

            transform.position = _initialPosition;

            _bulletInRange = false;
        }
        
        private IEnumerator Attack()
        {
            _isAttacking = true;
            
            transform.position = _initialPosition; 
            
            yield return new WaitForSeconds(1f);
            
            _isAttacking = false;
        }
    }
}
