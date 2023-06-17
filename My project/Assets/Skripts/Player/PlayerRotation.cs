using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private void Update()
    {
        // �������� ������� ������� �� ������
        Vector3 mousePosition = Input.mousePosition;

        // ����������� ������� ������� � ������� ����������
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // ��������� ���� ����� ���������� � ��������
        float angle = Mathf.Atan2(worldPosition.y - transform.position.y, worldPosition.x - transform.position.x) * Mathf.Rad2Deg;

        // ������� ���������� �������� �� ���� ����
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // ��������� ������� � ���������
        transform.rotation = rotation;
    }
}
