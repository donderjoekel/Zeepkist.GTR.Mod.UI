using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TNRD.Zeepkist.GTR.UI
{
    public class StarButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image starImage;

        [SerializeField] private Color activeColor = new Color(1, 1, 1, 1);
        [SerializeField] private Color inactiveColor = new Color(1, 1, 1, 0.15f);

        [SerializeField] private int index;

        private StarButtons starButtons;

        [PublicAPI] public event Action<int> Clicked;

        public void Initialize(StarButtons starButtons)
        {
            this.starButtons = starButtons;
        }

        private void OnClick()
        {
            Clicked?.Invoke(index);
        }

        [PublicAPI]
        public void SetActive()
        {
            starImage.color = activeColor;
        }

        [PublicAPI]
        public void SetInactive()
        {
            starImage.color = inactiveColor;
        }

        /// <inheritdoc />
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            OnClick();
        }

        /// <inheritdoc />
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            starButtons.ActivateUntil(index);
        }

        /// <inheritdoc />
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            starButtons.DeactivateAll();
        }
    }
}
