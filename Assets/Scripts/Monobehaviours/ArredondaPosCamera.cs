using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Classe que corrige a posição da camera
/// </summary>
public class ArredondaPosCamera : CinemachineExtension
{
    public float PixelsPerUnit = 32; // Valor de pixels por unidade, no caso 32 como utilizado ao longo do desenvolvimento do jogo

    /* Método que efetua a correção da camera */
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(stage == CinemachineCore.Stage.Body)
        {
            Vector3 pos = state.FinalPosition;
            Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);
            state.PositionCorrection += pos2 - pos;
        }
    }

    /* Método para arredondar o valor com base nos pixels por unidade */
    float Round(float x)
    {
        return Mathf.Round(x * PixelsPerUnit) / PixelsPerUnit;
    }
}
