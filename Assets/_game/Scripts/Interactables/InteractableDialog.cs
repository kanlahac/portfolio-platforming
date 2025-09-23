using TMPro;
using Tools;
using Ui;
using UnityEngine;

namespace Interactables
{
    sealed class InteractableDialog : MonoBehaviour, IInteractable
    {
        [SerializeField] private DiegeticUi _dialog;
        [SerializeField] private TextMeshProUGUI _dialogText;
        [SerializeField] private DialogData _dialogData;
        [SerializeField] private float _dialogDuration;
        private Animator _animator;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        public void Interact()
        {
            if (_dialog.IsActive) return;

            string text = _dialogData.DialogList[Random.Range(0, _dialogData.DialogList.Length)];

            _dialogText.text = text;
            _animator.SetTrigger("Cheer");

            _dialog.ShowUi(_dialogDuration);

            GamepadTools.Vibrate(0.5f, 0.5f, 0.1f);
        }
    }
}
