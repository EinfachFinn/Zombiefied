using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace UnityTutorial.Manager
{
	
	
    public class InputManager : MonoBehaviour
	{
    	
		[Header("TargetScripts")]
		public PickUpAndDrop PickUpDrop;
		public InventarSwitch InventarSwitch;
		public PlayerInteract PlayerInteract;
    	
	    [SerializeField] private PlayerInput PlayerInput;
	    public InputActionAsset Inputs;
		
		
		//Actions
	    public Vector2 Move {get; private set;}
	    
	    public Vector2 Look {get; private set;}
	    
	    public bool Run {get; private set;}
	    
	    //Interaction
		public bool PickUp {get; private set;}
		public bool Interact {get; private set;}
		
		//inventar
		public bool InventarL {get; private set;}
		public bool InventarR {get; private set;}
	   
	   
		public float MouseScroll;
	   
	   
	   
	   
	   
		private InputActionMap _MovementMap;
		private InputActionMap _InteractionMap;
	    
	    private InputAction _moveAction;
	    
	    private InputAction _lookAction;
	    
	    private InputAction _runAction;
	    
	    //interaction
		private InputAction _PickUpAction;
		private InputAction _InteractAction;
	    
		//inventar
		private InputAction _InventarL;
		private InputAction _InventarR;
		
		//mouse inventar
		private InputAction _MouseInventar;
	    
	    //Press Button Action here
	    
	    
	    
	    private void Awake() 
	    {	
	    	HideCursor();
	    	//Connect _action with ActionMap.FindAction("")
	    	_MovementMap = Inputs.FindActionMap("Movement");
	    	_InteractionMap = Inputs.FindActionMap("Interaction");
	    	
	    	//movement
	    	_moveAction = _MovementMap.FindAction("Move");
	    	_lookAction = _MovementMap.FindAction("Look");
	    	_runAction =  _MovementMap.FindAction("Run");
	    	
	    	//interaction
	    	_PickUpAction = _InteractionMap.FindAction("PickUp");
	    	_InteractAction = _InteractionMap.FindAction("Interact");
	    	
	    	//inventar
	    	_InventarL = _InteractionMap.FindAction("InventarLeft");
	    	_InventarR = _InteractionMap.FindAction("InventarRight");
	    	_MouseInventar = _InteractionMap.FindAction("InventarMouse");
	    	
	    	//Movement
	    	_moveAction.performed += onMove;
	    	_lookAction.performed += onLook;
	    	_runAction.performed += onRun;
	    	
	    	//interaction
	    	_PickUpAction.performed += onPickUp;
	    	_InteractAction.performed += onInteract;
	    	
	    	//inventar
	    	_InventarR.performed += onInventarR;
	    	_InventarL.performed += onInventarL;
	    	//mouseInventar
	    	_MouseInventar.performed += x => MouseScroll = x.ReadValue<float>();
	    	
	    	_moveAction.canceled += onMove;
	    	_lookAction.canceled += onLook;
	    	_runAction.canceled += onRun;
	    	
	    	
	    }
	    
	    private void HideCursor()
	    {
		    Cursor.visible = false;
		    Cursor.lockState = CursorLockMode.Locked;
	    }
	    
		
	    //defines what the Value is (with Input)
	    private void onMove(InputAction.CallbackContext context)
	    {
		    Move = context.ReadValue<Vector2>();
	    }
  		
	    //defines what the Value is (with Input)
	    private void onLook(InputAction.CallbackContext context)
	    {
		    Look = context.ReadValue<Vector2>();
	    }
	    
	    //defines what the Value is (with Input)
	    private void onRun(InputAction.CallbackContext context)
	    {
		    Run = context.ReadValueAsButton();
	    }
	    
	    
	    
	    private void onPickUp(InputAction.CallbackContext context)
	    {
	    	
	    	PickUp = context.ReadValueAsButton();
	    	PickUpDrop.PickUp();
	    }
	    
		private void onInteract(InputAction.CallbackContext context)
		{
			Interact = context.ReadValueAsButton();
			PlayerInteract.Interact();
		}
	
	
	
		private void onInventarR(InputAction.CallbackContext context)
		{
			InventarR = context.ReadValueAsButton();
			InventarSwitch.Right();
		}
		private void onInventarL(InputAction.CallbackContext context)
		{
			InventarL = context.ReadValueAsButton();
			InventarSwitch.Left();
		}
		
		
		private void Update()
		{
			if(MouseScroll > 0)
			{
				InventarSwitch.Right();
				MouseScroll = 0;
			}
			if(MouseScroll < 0)
			{
				InventarSwitch.Left();
				MouseScroll = 0;
			}
		}
		
		
	
	    private void OnEnable()
	    {
	    	_MovementMap.Enable();
	    	_InteractionMap.Enable();
	    }
	    
	    private void OnDisable()
	    {
	    	_MovementMap.Disable();
	    	_InteractionMap.Disable();
	    }
	
	
    }

}
