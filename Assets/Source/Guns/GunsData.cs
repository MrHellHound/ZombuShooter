using UnityEngine;

namespace Source.Guns
{
    [CreateAssetMenu(menuName = "Guns", fileName = "new Gun")]
    public class GunsData : ScriptableObject
    {
        [Tooltip("Моделька оружия")] [SerializeField] private GameObject gunModel;
        [Tooltip("Спрайт")] [SerializeField] private Sprite mainSprite;
        [Tooltip("Урон оружия")] [SerializeField] private int damage;
        [Tooltip("Уровень оружия")] [SerializeField] private int level;
        
    }
}
