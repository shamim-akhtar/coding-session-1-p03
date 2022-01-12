using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPC;

public class CThirdPersonCamera : MonoBehaviour
{
  [SerializeField]
  Transform mPlayerTransform;

  [SerializeField]
  Vector3 CameraAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
  [SerializeField]
  Vector3 CameraPositionOffset = new Vector3(0.0f, 2.0f, -3.0f);
  [SerializeField]
  float Damping = 1.0f;

  public enum CameraType
  {
    TRACK,
    FOLLOW_POS,
    FOLLOW_POS_ROT,
  }
  [SerializeField]
  CameraType mCameraType = CameraType.TRACK;

  Dictionary<CameraType, TPCBase> myCameras = new Dictionary<CameraType, TPCBase>();

  //TPCBase myCamera;
  // Start is called before the first frame update
  void Start()
  {
    myCameras.Add(CameraType.TRACK, 
      new TPCTrack(transform, mPlayerTransform));

    myCameras.Add(CameraType.FOLLOW_POS, 
      new TPCFollowTrackPosition(transform, mPlayerTransform));

    myCameras.Add(CameraType.FOLLOW_POS_ROT, 
      new TPCFollowTrackPositionAndRotation(transform, mPlayerTransform));

    ////myCamera = new TPCTrack(transform, mPlayerTransform);
    ////myCamera = new TPCFollowTrackPosition(transform, mPlayerTransform);
    //myCamera = new TPCFollowTrackPositionAndRotation(transform, mPlayerTransform);

    GameConstants.CameraAngleOffset = CameraAngleOffset;
    GameConstants.CameraPositionOffset = CameraPositionOffset;
    GameConstants.Damping = Damping;
  }

  private void Update()
  {
    GameConstants.CameraAngleOffset = CameraAngleOffset;
    GameConstants.CameraPositionOffset = CameraPositionOffset;
    GameConstants.Damping = Damping;
  }

  private void LateUpdate()
  {
    myCameras[mCameraType].Frame();
    //myCamera.Frame();
  }
}
