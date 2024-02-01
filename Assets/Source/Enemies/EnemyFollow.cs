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

        private void Start()
        {
            _isAttacking = false;
        }

        private void Update()
        {
            _initialPosition = transform.position;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_isAttacking)
            {
                Vector3 direction = player.position - transform.position;

                direction.Normalize();
                
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }

            if (other.CompareTag("Bullet") && !_isAttacking)
            {
                StartCoroutine(Offensive());
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

        private IEnumerator Offensive()
        {
            Vector3 direction = player.position - transform.position;

            direction.Normalize();
                
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            yield return new WaitForSeconds(3f);
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
