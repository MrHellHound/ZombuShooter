using UnityEngine;

namespace Source.Guns
{
    public class AttachmentSystem : MonoBehaviour
    {
        [Header("Моделька оружия")] [SerializeField] private GameObject mainGun;
        [Header("Обвесы")] [SerializeField] private GameObject attachment1, attachment2, attachment3, attachment4, attachment5;

        [Header("Спрайт оружия")] [SerializeField] private GameObject mainGunInfo;
        [Header("Спрайт обвесов")] [SerializeField] private GameObject[] attachmentSprite1, attachmentSprite2, attachmentSprite3, attachmentSprite4, attachmentSprite5;

        private void Update() => UIChanger();
        
        private void UIChanger()
        {
            // GunInfo
            if (mainGun.activeInHierarchy)
            {
                mainGunInfo.SetActive(true);
            }
            else 
            {
                mainGunInfo.SetActive(false);
            }
            
            // Модуль 1
            if (attachment1 != null && attachment1.activeInHierarchy && attachmentSprite1 != null)
            {
                foreach (var spriteObject in attachmentSprite1)
                {
                    spriteObject.SetActive(true);
                }
            }
            else if (attachmentSprite1 != null)
            {
                foreach (var spriteObject in attachmentSprite1)
                {
                    spriteObject.SetActive(false);
                }
            }
            
            // Модуль 2
            if (attachment2 != null && attachment2.activeInHierarchy && attachmentSprite2 != null)
            {
                foreach (var spriteObject in attachmentSprite2)
                {
                    spriteObject.SetActive(true);
                }
            }
            else if (attachmentSprite2 != null)
            {
                foreach (var spriteObject in attachmentSprite2)
                {
                    spriteObject.SetActive(false);
                }
            }
            
            // Модуль 3
            if (attachment3 != null && attachment3.activeInHierarchy && attachmentSprite3 != null)
            {
                foreach (var spriteObject in attachmentSprite3)
                {
                    spriteObject.SetActive(true);
                }
            }
            else if (attachmentSprite3 != null)
            {
                foreach (var spriteObject in attachmentSprite3)
                {
                    spriteObject.SetActive(false);
                }
            }
            
            // Модуль 4
            if (attachment4 != null && attachment4.activeInHierarchy && attachmentSprite4 != null)
            {
                foreach (var spriteObject in attachmentSprite4)
                {
                    spriteObject.SetActive(true);
                }
            }
            else if (attachmentSprite4 != null)
            {
                foreach (var spriteObject in attachmentSprite4)
                {
                    spriteObject.SetActive(false);
                }
            }
            
            // Модуль 5
            if (attachment5 != null && attachment5.activeInHierarchy && attachmentSprite5 != null)
            {
                foreach (var spriteObject in attachmentSprite5)
                {
                    spriteObject.SetActive(true);
                }
            }
            else if (attachmentSprite5 != null)
            {
                foreach (var spriteObject in attachmentSprite5)
                {
                    spriteObject.SetActive(false);
                }
            }
        }
    }
}
