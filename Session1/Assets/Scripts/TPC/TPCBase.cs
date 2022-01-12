
using UnityEngine;

namespace TPC
{

  /// <summary>
  /// This class is the base class for all 
  /// third person camera controls.
  /// Remember these classes are NOT monobehavior classes
  /// and hence cannot be added to the GameObject as component.
  /// Instead we will instantiate the concrete implementation of
  /// these third person cameras in our CThirdPersonCamera monobehavior class.
  /// </summary>
  public abstract class TPCBase
  {
    /// <summary>
    /// For a third person camera to work it only 
    /// required the following two transforms.
    /// </summary>
    protected Transform mCameraTransform;
    protected Transform mPlayerTransform;

    // the constructor.
    public TPCBase(Transform cameraTranform, Transform playerTransform)
    {
      mCameraTransform = cameraTranform;
      mPlayerTransform = playerTransform;
    }

    public abstract void Frame();
  }
}