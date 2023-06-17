using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private void Update()
    {
        // получаем позицию курсора на экране
        Vector3 mousePosition = Input.mousePosition;

        // преобразуем позицию курсора в мировые координаты
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // вычисляем угол между персонажем и курсором
        float angle = Mathf.Atan2(worldPosition.y - transform.position.y, worldPosition.x - transform.position.x) * Mathf.Rad2Deg;

        // создаем кватернион поворота на этот угол
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // применяем поворот к персонажу
        transform.rotation = rotation;
    }
}
