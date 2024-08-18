using R3;
using Runtime.Gameplay.Misc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Runtime.Gameplay.Buildings.UI
{
    public class BuildingsToolbarItemView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,
        IPointerExitHandler
    {
        public ReadOnlyReactiveProperty<bool> IsSelected => _isSelected;
        public ReadOnlyReactiveProperty<bool> IsHover => _isHover;

        [Header("UX")] 
        [SerializeField] private Image _background;
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private Sprite _hoverSprite;
        [Space] 
        [SerializeField] private GameObject _darkBackground;
        [SerializeField] private GameObject _selectionMark;
        [SerializeField] private GameObject _lockedState;
        [SerializeField] private GameObject _unlockedState;
        [Header("Gameplay")] 
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _costText;

        private ReactiveProperty<bool> _isSelected = new();
        private ReactiveProperty<bool> _isHover = new();
        private bool _locked;

        public void SetSelected(bool selected)
        {
            _selectionMark.SetActive(selected);
            _isSelected.Value = selected;
        }

        public void SetHover(bool hover)
        {
            _background.sprite = hover ? _hoverSprite : _defaultSprite;
            _isHover.Value = hover;
        }

        public void SetIcon(Sprite icon) => _itemIcon.sprite = icon;
        public void SetCost(int cost) => _costText.text = cost.ToGameString();
        public void SetPurchasable(bool purchasable) => _darkBackground.SetActive(!purchasable);

        public void SetLocked(bool locked)
        {
            _background.sprite = _defaultSprite;
            _lockedState.SetActive(locked);
            _unlockedState.SetActive(!locked);
            _locked = locked;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_locked)
                return;
            SetSelected(!_isSelected.Value);
        }

        public void OnPointerEnter(PointerEventData eventData)
        { 
            if (_locked)
                return;
            SetHover(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_locked)
                return;
            SetHover(false);
        }
    }
}