using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TNRD.Zeepkist.GTR.UI
{
    public class FavoriteButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image[] images;
        [SerializeField] private Sprite inactiveSprite;
        [SerializeField] private Sprite activeSprite;

        [PublicAPI] public event Action<FavoriteButton> Clicked;
        [PublicAPI] public bool IsActive { get; private set; }

        private void OnClick()
        {
            if (IsActive)
                SetInactive();
            else
                SetActive();

            Clicked?.Invoke(this);
        }

        [PublicAPI]
        public void SetInactive()
        {
            foreach (Image image in images)
            {
                image.sprite = inactiveSprite;
            }

            IsActive = false;
        }

        [PublicAPI]
        public void SetActive()
        {
            foreach (Image image in images)
            {
                image.sprite = activeSprite;
            }

            IsActive = true;
        }

        /// <inheritdoc />
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            OnClick();
        }
    }
}
