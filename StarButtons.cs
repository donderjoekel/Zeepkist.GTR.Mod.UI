using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TNRD.Zeepkist.GTR.UI
{
    public class StarButtons : MonoBehaviour
    {
        [SerializeField] private StarButton[] starButtons;

        [PublicAPI] public event Action<StarButtons, int> Clicked;
        [PublicAPI] public event Action<StarButtons> AllDeactivated;

        private void Awake()
        {
            foreach (StarButton starButton in starButtons)
            {
                starButton.Initialize(this);
                starButton.Clicked += OnStarClicked;
            }

            DeactivateAll(true);
        }

        private void OnStarClicked(int index)
        {
            Clicked?.Invoke(this, index);
        }

        [PublicAPI]
        public void ActivateUntil(int index)
        {
            for (int i = 0; i < starButtons.Length; i++)
            {
                if (i <= index)
                {
                    starButtons[i].SetActive();
                }
                else
                {
                    starButtons[i].SetInactive();
                }
            }
        }

        [PublicAPI]
        public void DeactivateAll(bool silent = false)
        {
            foreach (StarButton starButton in starButtons)
            {
                starButton.SetInactive();
            }

            if (!silent)
                AllDeactivated?.Invoke(this);
        }
    }
}
