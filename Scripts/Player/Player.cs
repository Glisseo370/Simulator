using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject interactImage;
    [SerializeField] private TextMeshProUGUI interactText;

    [SerializeField] private InputActionReference movementControl;

    //[SerializeField] private Transform firstCamera;
    private Transform firstCamera;


    private bool isWalking;
    private Vector3 lastInteractDir;



    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        firstCamera = Camera.main.transform;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 0.7f;
        float interactRadius = 0.2f;
        if (Physics.SphereCast(transform.position, interactRadius, lastInteractDir, out RaycastHit raycastHit, interactDistance, layerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseInteract interactObject))
            {
                if (interactObject != null)
                {
                    interactObject.Interact(this);
                }
            }
        }
    }

    private void Update()
    {
        HandleInteraction();
        HandleMovement();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteraction()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        moveDir = firstCamera.forward * moveDir.z + firstCamera.right * moveDir.x;
        moveDir.y = 0f;

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 0.7f;
        float interactRadius = 0.2f;

        if (Physics.SphereCast(transform.position, interactRadius, lastInteractDir, out RaycastHit raycastHit, interactDistance, layerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseInteract baseInteract))
            {
                interactText.text = raycastHit.collider.name;
                interactImage.SetActive(true);
            }
        }
        else
        {
            interactImage.SetActive(false);
        }
    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //Vector3 moveDir = new Vector3(movement.x, 0 , movement.y);
        moveDir = firstCamera.forward * moveDir.z + firstCamera.right * moveDir.x;
        moveDir.y = 0f;

        //Debug.Log("1" + moveDir);
        //Debug.Log("2" + moveDir);
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.2f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {

                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 3f;

        float targetAngle = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }


}
