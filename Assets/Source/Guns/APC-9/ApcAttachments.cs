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
        
        private void Update()
        {
            UIChanger();
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
            
            // Рукоять
            if (underBarrel.activeInHierarchy)
            {
                underBarrelSprite.SetActive(true);
            }
            else
            {
                underBarrelSprite.SetActive(false);
            }
            
            // Приклад
            if (stock.activeInHierarchy)
            {
                stockSprite.SetActive(true);
            }
            else
            {
                stockSprite.SetActive(false);
            }
        }
    }
}
