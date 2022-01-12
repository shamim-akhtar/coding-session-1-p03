using UnityEngine;

namespace TPC
{
  public class TPCTrack : TPCBase
  {
    // the constructor.
    public TPCTrack(Transform cameraTranform, Transform playerTransform)
      : base(cameraTranform, playerTransform)
    {

    }
    public override void Frame()
    {
      float playerHeight = GameConstants.CameraPositionOffset.y;
      Vector3 targetPos = mPlayerTransform.position;
      targetPos.y += playerHeight;
      mCameraTransform.LookAt(targetPos);
    }

  }
}