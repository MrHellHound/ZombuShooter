using UnityEngine;
using UnityEngine.UI;

namespace Source.Guns
{
    [CreateAssetMenu(menuName = "Scriptable guns", fileName = "New gun")]
    public class GunsData : ScriptableObject
    {
        [Tooltip("Моделька оружия")] 
        [SerializeField] private string _gunName;
        public string GunName => this._gunName;
        
        [Tooltip("Моделька оружия")] 
        [SerializeField] private GameObject _gunModel;
        public GameObject GunModel => this._gunModel;
        
        [Tooltip("Спрайт")] 
        [SerializeField] private Image _mainSprite;
        public Image MainSprite => this._mainSprite;
        
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
        
        [Tooltip("Количество патронов вмещаемых в магазин")]
        [SerializeField] private int _magCapacity;
        public int MagCapacity
        {
            get => _magCapacity;
            set => _magCapacity = value;
        }
        
        [Tooltip("Время перезарядки")]
        [SerializeField] private int _reloadTime;
        public int ReloadTime
        {
            get => _reloadTime;
            set => _reloadTime = value;
        }
        
        [Tooltip("Количество патронов после которого происходит предупреждение")]
        [SerializeField] private int _ammoToWarn;
        public int AmmoToWarn => this._ammoToWarn;
        
    }
}
