using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{

    public event EventHandler OnPlatesSpawned;
    public event EventHandler OnPlatesRemoved;
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSwpanedAmout;
    private int platesSwpanedAmoutMax = 4;
    private void Update() {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax) {
            spawnPlateTimer = 0f;

            if (KitchenGameManager.Instance.IsGamePlaying() && platesSwpanedAmout < platesSwpanedAmoutMax) {
                platesSwpanedAmout ++;

                OnPlatesSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject()) {
            if (platesSwpanedAmout > 0) {
                platesSwpanedAmout--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlatesRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
