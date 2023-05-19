using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraControllable
{
  public void MoveCamera(CameraController cameraController, ref InputMovement inputMovement);
}
