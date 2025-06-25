using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private int _maxPage;
    [SerializeField] private Vector3 _pageStep;
    [SerializeField] private RectTransform _levelPagesRect;
    [SerializeField] private float _tweenTime;
    [SerializeField] private LeanTweenType _twenType;


    private int _currentPage;
    private Vector3 _targetPos;
    private float _dragThershould;


    private void Awake()
    {
        _currentPage = 1;
        _targetPos = _levelPagesRect.localPosition;
        _dragThershould = Screen.width / 15;
    }

    public void Next()
    {
        if(_currentPage < _maxPage)
        {
            _currentPage++;
            _targetPos += _pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if(_currentPage > 1)
        {
            _currentPage--;
            _targetPos -= _pageStep;
            MovePage();
        }
    }

    public void MovePage()
    {
        _levelPagesRect.LeanMoveLocal(_targetPos, _tweenTime).setEase(_twenType);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       if(Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > _dragThershould)
        {

        }
    }
}
