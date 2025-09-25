using Tools;
using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

namespace World.Collectables.SpellBook
{
    sealed class SpellBook : MonoBehaviour
    {
        [SerializeField] private Transform _closeBook;
        [SerializeField] private Transform _openBook;
        [SerializeField] private CinemachineCamera _bookCamera;
        [SerializeField] private InputActionReference _exitAction;
        [SerializeField] private LevelData _levelData;
        [SerializeField] private InternalEvent _switchInputMap;
        private SphereCollider _collider;
        private bool IsActive;


        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
        }


        private void OnEnable()
        {
            IdleAnimation();

            _closeBook.localScale = Vector3.one;
            _openBook.localScale = Vector3.zero;

            _collider.enabled = true;
            IsActive = false;

            _exitAction.action.performed += EndCollect;
        }


        private void OnDisable()
        {
            transform.DOKill();

            _exitAction.action.performed -= EndCollect;
        }


        private void Update()
        {
            if (IsActive == false) return;
            
            transform.LookAt(Camera.main.transform);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                StartCollect();
            }
        }


        public void StartCollect()
        {
            _collider.enabled = false;

            _switchInputMap.Event.Invoke();

            transform.DOKill();

            Sequence sequence = DOTween.Sequence();

            sequence.Append(
                transform.DOLocalRotate(new Vector3(0, 360 * 20, 0), 3f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.InQuint)
            );

            sequence.Join(
                transform.DOMoveY(transform.position.y + 5, 3f)
                    .SetEase(Ease.InQuint)
            );

            GamepadTools.IncrementalVibrate(0.5f, 0.5f, 3.5f, Ease.InQuint);

            sequence.AppendCallback(() =>
            {
                // BOOOM
                _closeBook.localScale = Vector3.zero;
                _openBook.localScale = Vector3.one;

                _bookCamera.Priority = 20;

                IsActive = true;
                _levelData.AddCollectable();
            });

            sequence.AppendCallback(() =>
            {
                GamepadTools.Vibrate(1f, 1f, 0.15f);
            }).SetDelay(1f);
        }


        public void EndCollect(InputAction.CallbackContext context)
        {
            if (IsActive == false) return;

            _bookCamera.Priority = 0;

            GamepadTools.Vibrate(0.5f, 0.5f, 0.15f);

            transform.DOKill();

            Sequence sequence = DOTween.Sequence();

            sequence.Join(
                transform.DOScale(Vector3.zero, 0.5f)
                    .SetEase(Ease.InBounce)
            );

            sequence.AppendCallback(() =>
            {
                // BOOOM

                 _switchInputMap.Event.Invoke();
                 
                IsActive = false;
                gameObject.SetActive(false);
            });
        }


        private void IdleAnimation()
        {
            transform.DOLocalMoveY(transform.localPosition.y - 0.75f, 2f)
                .SetEase(Ease.InOutCubic)
                .SetLoops(-1, LoopType.Yoyo);

            transform.DOLocalRotate(new Vector3(0, 360, 0), 5, RotateMode.LocalAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }
    }
}
