using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ShipSelection : MonoBehaviour
{
    [SerializeField] private List<ShipData> ships;
    [SerializeField] private Image shipImage;
    [SerializeField] private TextMeshProUGUI shipName;
    [SerializeField] private TextMeshProUGUI statsText;

    [SerializeField] private GameData gameData;

    private int currentIndex = 0;

    private void Start()
    {
        UpdateShipDisplay();
    }

    public void NextShip()
    {
        currentIndex = (currentIndex + 1) % ships.Count;
        UpdateShipDisplay();
    }

    public void PreviousShip()
    {
        currentIndex = (currentIndex - 1 + ships.Count) % ships.Count;
        UpdateShipDisplay();
    }

    public void SelectShip()
    {
        gameData.selectedShip = ships[currentIndex];
        Debug.Log("Nave seleccionada: " + gameData.selectedShip.shipName);
    }

    private void UpdateShipDisplay()
    {
        ShipData currentShip = ships[currentIndex];
        shipImage.sprite = currentShip.shipSprite;
        shipName.text = currentShip.shipName;
        statsText.text = $"Velocidad: {currentShip.verticalSpeed}\nVida: {currentShip.life}";
    }
}
