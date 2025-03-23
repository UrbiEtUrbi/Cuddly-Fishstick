using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SmartObjectPlacer : MonoBehaviour
{
    public Rect rectangleBounds;  // Bounds where objects will be placed
    private ObjectListData objectListData;  // List of objects to place (ScriptableObject with ObjectData)
  

    private List<Rect> availableSpaces = new List<Rect>();  // List of available spaces for placing objects

    EnemySpawner waveHandler;

    private void Awake()
    {
        waveHandler = GetComponent<EnemySpawner>();
        waveHandler.OnWaveStart.AddListener(GenerateObjects);
    }

    void GenerateObjects(string wave, ObjectListData objects)
    {
        objectListData = objects;
        // Calculate total area of the rectangle and the target fill area based on density
        float totalArea = rectangleBounds.width * rectangleBounds.height;
        float targetFillArea = totalArea * objectListData.Density;
        float usedArea = 0;


        int safetyCounter = 1000; // Prevent infinite loops

        // Keep placing objects until the used area reaches the target fill area
        while (usedArea < targetFillArea && safetyCounter-- > 0)
        {
            // Pick a random object from the list (can repeat objects)
            ObjectData selectedObject = objectListData.objects[Random.Range(0, objectListData.objects.Count)];

            // Generate random position inside rectangleBounds for this object
            float randomX = Random.Range(rectangleBounds.x, rectangleBounds.x + rectangleBounds.width - selectedObject.width);
            float randomY = Random.Range(rectangleBounds.y, rectangleBounds.y + rectangleBounds.height - selectedObject.height);

            Rect randomPlacement = new Rect(randomX, randomY, selectedObject.width, selectedObject.height);

            // Check if the randomly chosen spot overlaps with any existing placed object
            if (DoesOverlap(randomPlacement))
            {
                continue;
            }


            // Place the object at the chosen position
            Instantiate(selectedObject.prefab, new Vector2(randomPlacement.x + randomPlacement.width / 2 - rectangleBounds.width/2, randomPlacement.y + randomPlacement.height / 2 -rectangleBounds.height / 2), Quaternion.identity);

            // Update used area
            usedArea += randomPlacement.width * randomPlacement.height;

            SplitSpace(randomPlacement);
        }
    }

    bool DoesOverlap(Rect placement)
    {
        // Check if the random placement overlaps with any previously placed object
        foreach (var space in availableSpaces)
        {
            if (space.Overlaps(placement))
            {
                return true;
            }
        }
        return false;
    }

    void SplitSpace(Rect usedSpace)
    {
        availableSpaces.Add(usedSpace);
    }
}