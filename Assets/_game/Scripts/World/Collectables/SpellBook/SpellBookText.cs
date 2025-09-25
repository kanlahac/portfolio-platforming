using TMPro;
using UnityEngine;

namespace World.Collectables.SpellBook
{
    sealed class SpellBookText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _leftTitle;
        [SerializeField] private TextMeshProUGUI _leftText;
        [SerializeField] private TextMeshProUGUI _rightTitle;
        [SerializeField] private TextMeshProUGUI _rightText;
        [SerializeField] private SpellBookData _spellBookData;


        private void Awake()
        {
            _leftTitle.text = _spellBookData.Left.Title;
            _leftText.text = _spellBookData.Left.Text;

            _rightTitle.text = _spellBookData.Right.Title;
            _rightText.text = _spellBookData.Right.Text;
        }

    }
}
