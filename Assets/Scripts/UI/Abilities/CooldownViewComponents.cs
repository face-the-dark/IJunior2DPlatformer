using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Abilities
{
    public class CooldownViewComponents : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private TextMeshProUGUI _cooldownText;

        public void Enable()
        {
            _fillImage.gameObject.SetActive(true);
            _backgroundImage.gameObject.SetActive(true);
            _cooldownText.gameObject.SetActive(true);
        }

        public void Disable()
        {
            _fillImage.gameObject.SetActive(false);
            _backgroundImage.gameObject.SetActive(false);
            _cooldownText.gameObject.SetActive(false);
        }

        public void UnfillImageAndUpdateText(Cooldown abilityCooldown)
        {
            _fillImage.fillAmount = abilityCooldown.CurrentValue;
            _cooldownText.text = abilityCooldown.Delta.ToString();
        }
    }
}