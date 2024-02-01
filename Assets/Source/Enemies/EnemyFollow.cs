using System;
using UnityEngine;

namespace Source.Enemies
{
    public class EnemyFollow : MonoBehaviour
    {
        [SerializeField] private Transform enemy;
        [SerializeField] private Transform player;
        [SerializeField] private float moveSpeed;
        
        private Vector3 initialPosition;

        private void Update()
        {
            initialPosition = transform.position;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Vector3 direction = player.position - transform.position;

                direction.Normalize();
                
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                transform.position = initialPosition;
            }
        }
    }
}
