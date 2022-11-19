using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace UnityTutorial.Manager
{
    public class InputManager : MonoBehaviour
    {
	    [SerializeField] private PlayerInput PlayerInput;
	    
	    public Vector2 Move {get; private set;}
	    
	    public Vector2 Look {get; private set;}
	    
	    public bool Run {get; private set;}
	    
	    
	    public bool Jump{get; private set;}//Own Buttons like THIS: [1]
	    
	    
	    
	    private InputActionMap _currentMap;
	    
	    private InputAction _moveAction;
	    
	    private InputAction _lookAction;
	    
	    private InputAction _runAction;
	    
	   
	    private InputAction _jumpAction;  //Own InputAction here [2]
	    
	    
	    private void Awake() 
	    {	
	    	HideCursor();
	    	//Connect _action with ActionMap.FindAction("")
	    	_currentMap = PlayerInput.currentActionMap;
	    	_moveAction = _currentMap.FindAction("Move");
	    	_lookAction = _currentMap.FindAction("Look");
	    	_runAction =  _currentMap.FindAction("Run");
			_jumpAction = _currentMap.FindAction("Jump"); //Assign Own Button Action here [3]
	    	
	    	
	    	
	    	_moveAction.performed += onMove;
	    	_lookAction.performed += onLook;
	    	_runAction.performed += onRun;
	    	_jumpAction.performed += onJump; //Own Button performs [4]
	    	
	    	_moveAction.canceled += onMove;
	    	_lookAction.canceled += onLook;
	    	_runAction.canceled += onRun;
	    	_jumpAction.canceled += onJump; //Own Button cancels [5]
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
	    //defines what the Value is (with Input)
	    private void onJump(InputAction.CallbackContext context) //If own Button is pressed [5]
	    {

	    		Jump = context.ReadValueAsButton();
	    }
		
	    
	    
	
	    private void OnEnable()
	    {
	    	_currentMap.Enable();
	    }
	    
	    private void OnDisable()
	    {
	    	_currentMap.Disable();
	    }
	
	
    }

}
