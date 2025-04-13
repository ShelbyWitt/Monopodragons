//GamePieceModelUpdater.cs


using UnityEngine;

public class GamePieceModelUpdater : MonoBehaviour
{
    // Assign in the Inspector: the transform where the model should be parented.
    public Transform modelHolder;

    private GameObject currentModel;

    public void UpdatePlayerModel(string selectedRace, string selectedGender, string selectedColor)
    {
        // Ensure the modelHolder is available.
        if (modelHolder == null)
        {
            Debug.LogWarning("Model holder not assigned on the game piece!");
            return;
        }

        // Remove the mutant placeholder (and any previously instantiated model).
        foreach (Transform child in modelHolder)
        {
            Destroy(child.gameObject);
        }

        // Get the RaceManager (make sure it exists in the scene or is accessible globally).
        RaceManager raceManager = GameObject.FindObjectOfType<RaceManager>();
        if (raceManager == null)
        {
            Debug.LogError("RaceManager not found in the Solo scene!");
            return;
        }

        // Retrieve the RaceProperty based on selected race.
        RaceProperty raceProp = raceManager.GetRaceProperty(selectedRace);
        if (raceProp == null)
        {
            Debug.LogWarning("Race property not found for: " + selectedRace);
            return;
        }

        // Determine the correct prefab by gender.
        GameObject prefabToInstantiate = null;
        if (selectedGender == "Female" && raceProp.femaleCharacterModel != null)
        {
            prefabToInstantiate = raceProp.femaleCharacterModel;
        }
        else
        {
            prefabToInstantiate = raceProp.maleCharacterModel;
        }

        if (prefabToInstantiate == null)
        {
            Debug.LogWarning("No valid prefab for the selected race/gender combination.");
            return;
        }

        // Instantiate the new model as a child of modelHolder.
        currentModel = Instantiate(prefabToInstantiate, modelHolder.position, modelHolder.rotation, modelHolder);

        // OPTIONAL: Apply the chosen color.
        Renderer renderer = currentModel.GetComponentInChildren<Renderer>();
        if (renderer != null && ColorManager.ColorOptions.ContainsKey(selectedColor))
        {
            renderer.material.color = ColorManager.ColorOptions[selectedColor];
        }
    }
}
