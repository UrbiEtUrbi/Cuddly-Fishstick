using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SmartObjectPlacer : MonoBehaviour
{
    public Rect rectangleBounds;  // Bounds where objects will be placed
    public ObjectListData objectListData;  // List of objects to place (ScriptableObject with ObjectData)
  

    private List<Rect> availableSpaces = new List<Rect>();  // List of available spaces for placing objects

    void Start()
    {
        GenerateObjects();  // Start the object generation when the scene loads
    }

    void GenerateObjects()
    {
        // Calculate total area of the rectangle and the target fill area based on density
        float totalArea = rectangleBounds.width * rectangleBounds.height;
        float targetFillArea = totalArea * objectListData.Density;
        float usedArea = 0;

        // Sort objects by size (largest first) to try placing larger objects first
        List<ObjectData> sortedObjects = objectListData.objects.OrderByDescending(o => o.width * o.height).ToList();

        int safetyCounter = 1000; // Prevent infinite loops

        // Keep placing objects until the used area reaches the target fill area
        while (usedArea < targetFillArea && safetyCounter-- > 0)
        {
            // Pick a random object from the list (can repeat objects)
            ObjectData selectedObject = sortedObjects[Random.Range(0, sortedObjects.Count)];

            // Generate random position inside rectangleBounds for this object
            float randomX = Random.Range(rectangleBounds.x, rectangleBounds.x + rectangleBounds.width - selectedObject.width);
            float randomY = Random.Range(rectangleBounds.y, rectangleBounds.y + rectangleBounds.height - selectedObject.height);

            Rect randomPlacement = new Rect(randomX, randomY, selectedObject.width, selectedObject.height);

            // Check if the randomly chosen spot overlaps with any existing placed object
            if (DoesOverlap(randomPlacement))
            {
                continue;  // If overlap, try again with a different random placement
            }


            // Place the object at the chosen position
            Instantiate(selectedObject.prefab, new Vector2(randomPlacement.x + randomPlacement.width / 2 - rectangleBounds.width/2, randomPlacement.y + randomPlacement.height / 2 -rectangleBounds.height / 2), Quaternion.identity);

            // Update used area
            usedArea += randomPlacement.width * randomPlacement.height;

            // Optionally, track available spaces if you want to implement them later
            SplitSpace(randomPlacement);
        }

        if (safetyCounter <= 0)
        {
            Debug.LogWarning("Safety counter reached! The algorithm might be stuck.");
        }
    }

    bool DoesOverlap(Rect placement)
    {
        // Check if the random placement overlaps with any previously placed object
        foreach (var space in availableSpaces)
        {
            if (space.Overlaps(placement))
            {
                return true;  // Return true if any overlap is found
            }
        }
        return false;  // No overlap
    }

    void SplitSpace(Rect usedSpace)
    {
        // This method updates available spaces after placing an object
        // You can add logic to split the remaining available space into smaller areas
        availableSpaces.Add(usedSpace);
    }
}