using UnityEngine;

public class Swipes : MonoBehaviour
{
    // определение действия с bool
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    // нахождение пальца на экране
    private bool isDraging = false;
    // момент касания и дельта свайпа
    private Vector2 startTouch, swipeDelta;

    // Метод инициализации лишний, сразу метод обновления кода раз в тик
    private void Update()
    {
        // инициализация переменных
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
        #region ПК-версия
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Мобильная версия
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Просчитать дистанцию
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Проверка на пройденность расстояния
        if (swipeDelta.magnitude > 100)
        {
            //Определение направления
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                
                if (x < 0)
                {
                    swipeLeft = true;
                    Debug.Log("swipeLeft!!!");
                }
                else
                {
                    swipeRight = true;
                    Debug.Log("swipeRight!!!");
                }
            }
            else
            {
                
                if (y < 0)
                {
                    swipeDown = true;
                    Debug.Log("swipeDown!!!");
                }
                else
                {
                    swipeUp = true;
                    Debug.Log("swipeUp!!!");
                }
            }

            Reset();
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
