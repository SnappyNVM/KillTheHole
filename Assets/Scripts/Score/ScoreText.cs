using TMPro;
using UnityEngine;
using Zenject;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _prefix;

    private ScoreHolder _holder;

    [Inject]
    private void Constuct(ScoreHolder scoreHolder) => _holder = scoreHolder;

    private void Start() => _holder.ScoreIncreased += SetText;

    private void SetText(int scores) => _text.text = _prefix + scores.ToString();
}
