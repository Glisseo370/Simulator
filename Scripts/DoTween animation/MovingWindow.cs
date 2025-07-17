using UnityEngine;
using DG.Tweening;

public class MovingWindow : MonoBehaviour
{
    [SerializeField] private GameObject closePlace;
    [SerializeField] private GameObject openPlace;

    private Sequence movWin;

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        movWin = DOTween.Sequence();
        gameObject.transform.DOMove(openPlace.transform.position, 0.5f);
    }

    public void Hide()
    {
        movWin = DOTween.Sequence();
        movWin.Join(gameObject.transform.DOMove(closePlace.transform.position, 0.5f).OnComplete(() => gameObject.SetActive(false)));
    }
}
