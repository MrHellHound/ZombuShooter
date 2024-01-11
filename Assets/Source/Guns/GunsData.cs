using UnityEngine;

namespace Source.Guns
{
    [CreateAssetMenu(menuName = "Guns", fileName = "new Gun")]
    public class GunsData : ScriptableObject
    {
        [Tooltip("Моделька оружия")] 
        [SerializeField] private GameObject _gunModel;
        public GameObject GunModel => this._gunModel;
        
        [Tooltip("Спрайт")] 
        [SerializeField] private Sprite _mainSprite;
        public Sprite MainSprite => this._mainSprite;
        
        [Tooltip("Урон оружия")]
        [SerializeField] private int _damage;
        public int Damage => this._damage;
        
        [Tooltip("Уровень оружия")]
        [SerializeField] private int _level;
        public int Level => this._level;
        
        [Tooltip("Скорострельность оружия")]
        [SerializeField] private int _fireRate;
        public int FireRate => this._fireRate;
        
        [Tooltip("Скорость пули")]
        [SerializeField] private int _bulletForce;
        public int bulletForce => this._bulletForce;
        
        [Tooltip("Скорость гильзы")]
        [SerializeField] private int _shellForce;
        public int shellForce => this._shellForce;
        
        [Tooltip("Количество патронов в магазине")]
        [SerializeField] private int _bulletsInMag;
        public int BulletsInMag => this._bulletsInMag;
        
    }
}
