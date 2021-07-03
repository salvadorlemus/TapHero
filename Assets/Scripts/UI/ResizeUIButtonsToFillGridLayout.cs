using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GunstelGames.Utils.UI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class ResizeUIButtonsToFillGridLayout : MonoBehaviour
    {
        [Header("Set On Editor")]
        // Anchors of parent needs to be centered for corect calculation
        private RectTransform _ParentRectTransform;
        private GridLayoutGroup _GridLayoutGroup;
        private int _ConstrainCount;
        
        private float _ParentWidth;
        private float _ParentHeight;

        [SerializeField]
        private RectTransform[] _ButtonsRectTransform;

        private void Awake()
        {
            _ParentRectTransform = GetComponent<RectTransform>();
            _GridLayoutGroup = GetComponent<GridLayoutGroup>();

            _ConstrainCount = _GridLayoutGroup.constraintCount;

            _ParentWidth = _ParentRectTransform.rect.width;
            _ParentHeight = _ParentRectTransform.rect.height;

            Debug.Log(_ParentRectTransform.rect.size);

            if (_GridLayoutGroup.constraint.Equals(GridLayoutGroup.Constraint.FixedColumnCount))
            {
                ResizeButtonsForFixedColumCount();
            }
            else
            {
                ResizeButtonsForFixedRowCount();
            }    
        }

        private void ResizeButtonsForFixedColumCount()
        {
            float numberOfRows = Mathf.RoundToInt(_ButtonsRectTransform.Length / _ConstrainCount);
            if (_ButtonsRectTransform.Length % _ConstrainCount  > 0f)
            {
                numberOfRows++;
            }
            else if (_ButtonsRectTransform.Length % _ConstrainCount < 0f)
            {
                numberOfRows = 1;
            }

            Debug.Log(_ButtonsRectTransform.Length % _ConstrainCount);
            Debug.Log(numberOfRows);

            float buttonWidth = _ParentWidth / _ConstrainCount;
            float buttonHeight = _ParentHeight / numberOfRows;
            _GridLayoutGroup.cellSize = new Vector2(buttonWidth - _GridLayoutGroup.spacing.x, buttonHeight - _GridLayoutGroup.spacing.y);
        }

        private void ResizeButtonsForFixedRowCount()
        {
            float numberOfColumns = Mathf.RoundToInt(_ButtonsRectTransform.Length / _ConstrainCount);
            if (_ButtonsRectTransform.Length % _ConstrainCount > 0f)
            {
                numberOfColumns++;
            }
            else if (_ButtonsRectTransform.Length % _ConstrainCount < 0f)
            {
                numberOfColumns = 1;
            }

            Debug.Log(_ButtonsRectTransform.Length % _ConstrainCount);
            Debug.Log(numberOfColumns);

            float buttonWidth = _ParentWidth / numberOfColumns;
            float buttonHeight = _ParentHeight / _ConstrainCount;
            _GridLayoutGroup.cellSize = new Vector2(buttonWidth - _GridLayoutGroup.spacing.x, buttonHeight - _GridLayoutGroup.spacing.y);
        }
    }
}