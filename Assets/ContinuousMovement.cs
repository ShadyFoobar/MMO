using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 4;
    public XRNode inputSource;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float additionalHeight = .20f;

    private XROrigin rig;
    private Vector2 inputAxis;
    private CharacterController character;
    private float fallingSpeed;



    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        //gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingSpeed = 0;
        } else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }

    void CapsuleFollowHeadset()
    {
        character.height = rig.CameraInOriginSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }
}
