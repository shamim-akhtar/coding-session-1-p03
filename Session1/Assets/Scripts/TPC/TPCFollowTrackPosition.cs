
using UnityEngine;

namespace TPC
{
  public class TPCFollowTrackPosition : TPCFollow
  {
    public TPCFollowTrackPosition(Transform cameraTranform, Transform playerTransform)
    : base(cameraTranform, playerTransform)
    {

    }

    public override void Frame()
    {
      // Create the initial rotation quaternion based on the 
      // camera angle offset.
      Quaternion initialRotation =
         Quaternion.Euler(GameConstants.CameraAngleOffset);

      // Now rotate the camera to the above initial rotation offset.
      // We do it using damping/Lerp
      // You can change the damping to see the effect.
      mCameraTransform.rotation =
          Quaternion.RotateTowards(mCameraTransform.rotation,
              initialRotation,
              Time.deltaTime * GameConstants.Damping);

      base.Frame();
    }
  }
}