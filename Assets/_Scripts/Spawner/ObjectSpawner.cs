using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Префаб объекта, который вы хотите создавать
    public int numberOfObjects = 10; // Количество объектов, которые вы хотите создать
    public float distanceFromCenter = 10f; // Начальное расстояние от центра
    public float distanceIncrement = 10f; // Расстояние между объектами

    private void Start()
    {
        Vector3 spawnPosition = new Vector3(0,0,0); // Начинаем с позиции центра

        // Цикл для создания объектов
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Создаем объект из префаба
            GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // Увеличиваем расстояние для следующего объекта
            distanceFromCenter += distanceIncrement;

            // Вычисляем новую позицию для следующего объекта
            spawnPosition = transform.position + (transform.forward * distanceFromCenter);
        }
    }
}
