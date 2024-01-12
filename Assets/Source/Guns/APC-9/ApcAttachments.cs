using UnityEngine;

namespace Source.Guns.APC_9
{
    public class ApcAttachments : MonoBehaviour
    {
        // Изменение модельки
        
        [SerializeField] private GameObject silencer;
        
        [SerializeField] private GameObject scope;
        
        [SerializeField] private GameObject underBarrel;
        
        [SerializeField] private GameObject stock;
        
        // Изменение спрайта
        
        [SerializeField] private GameObject silencerSprite;
        
        [SerializeField] private GameObject scopeSprite;
        
        [SerializeField] private GameObject underBarrelSprite;
        
        [SerializeField] private GameObject stockSprite;
        
        // Изменения индикаторов

        [SerializeField] private GameObject[] indicators;
        private int _index = 0;

        private void Update()
        {
            UIChanger();
            Debug.Log(_index);
        }

        private void UIChanger()
        {
            // Глушитель
            if (silencer.activeInHierarchy)
            {
                silencerSprite.SetActive(true);
            }
            else
            {
                silencerSprite.SetActive(false);
            }
            
            // Прицел
            if (scope.activeInHierarchy)
            {
                scopeSprite.SetActive(true);
            }
            else
            {
                scopeSprite.SetActive(false);
            }
        }
    }
}
