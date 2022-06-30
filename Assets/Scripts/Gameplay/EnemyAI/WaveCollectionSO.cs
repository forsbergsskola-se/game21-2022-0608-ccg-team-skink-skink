using System.Collections;
using System.Collections.Generic;
using Gameplay.AI;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Utilities/WaveCollection", fileName = "NewWaveCollectionSO")]
public class WaveCollectionSO : ScriptableObject
{
    [SerializeField] private WaveSO[] waveCollection = new WaveSO[0];
    
    public WaveSO[] Collection => waveCollection;
}
