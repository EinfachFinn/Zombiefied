using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTutorial.Manager;

namespace UnityTutorial.PlayerControl
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float AnimBlendSpeed = 8.9f;
		[SerializeField] private Transform CameraRoot;
		[SerializeField] private Transform Camera;
		
		[Header("Camera")]
		[SerializeField] private float UpperLimit = -40f;
		[SerializeField] private float BottomLimit = 70f;
		[SerializeField] private float MouseSensitivity = 21.9f;
		[SerializeField] private float AirResistance = 0.8f;
		private Rigidbody _playerRigidbody;
		private InputManager _inputManager;
		private Animator _animator;
		private bool _hasAnimator;
		
		
		
		private int _xVelHash;
		private int _yVelHash;
		
		private int _groundHash;
		private int _fallingHash;
		private int _jumpHash;
		
		private int _zVelHash;
		
		private bool _grounded;
		private float _xRotation;
		private float _yRotation;
		
		public float _walkSpeed = 2f;
		public float _runSpeed = 6f;
		public float JumpFactor = 260f;
		
		private Vector2 _currentVelocity;
		
		
		
		[SerializeField] private float Dis2Ground = .8f; //Distance to ground
		[SerializeField] private LayerMask GroundCheck;
		private void Start()
		{
			_hasAnimator = TryGetComponent<Animator>(out _animator);
			_playerRigidbody = GetComponent<Rigidbody>();
			_inputManager = GetComponent<InputManager>();
			
			
			//Get Data out of Animator
			_xVelHash = Animator.StringToHash("X_Velocity");
			_yVelHash = Animator.StringToHash("Y_Velocity");
			_jumpHash = Animator.StringToHash("Jump");
			_groundHash = Animator.StringToHash("Grounded");
			_fallingHash = Animator.StringToHash("Falling");
			
			_zVelHash = Animator.StringToHash("Z_Velocity");
		
		}
			
		private void FixedUpdate()
		{
			Move();
			HandleJump();
			SampleGround();
		}
		
		private void LateUpdate()
		{
			CamMovement();
		}
		
		
		private void Move()
		{
			if(!_hasAnimator) return;
			
			float targetSpeed = _inputManager.Run ? _runSpeed : _walkSpeed;
			if(_inputManager.Move ==Vector2.zero ) targetSpeed = 0;
			
			_currentVelocity.x = Mathf.Lerp(_currentVelocity.x, _inputManager.Move.x * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
			
			_currentVelocity.y = Mathf.Lerp(_currentVelocity.y, _inputManager.Move.y * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
			
			var xVelDifference = _currentVelocity.x - _playerRigidbody.velocity.x;
			var zVelDifference = _currentVelocity.y - _playerRigidbody.velocity.z;
			
			_playerRigidbody.AddForce(transform.TransformVector(new Vector3(xVelDifference, 0 , zVelDifference)), ForceMode.VelocityChange);
			
		
			
			if(_grounded)
			{
                
				_currentVelocity.x = Mathf.Lerp(_currentVelocity.x, _inputManager.Move.x * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
				_currentVelocity.y =  Mathf.Lerp(_currentVelocity.y, _inputManager.Move.y * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);

			}
			_animator.SetFloat(_xVelHash , _currentVelocity.x);
			_animator.SetFloat(_yVelHash, _currentVelocity.y);
		}
			
	
		
		
		
		private void CamMovement()
		{
			if(!_hasAnimator) return;
			
			var Mouse_X = _inputManager.Look.x;
			var Mouse_Y = _inputManager.Look.y;
			Camera.position = CameraRoot.position;
			
			_xRotation -= Mouse_Y * MouseSensitivity * Time.smoothDeltaTime;
			_xRotation = Mathf.Clamp(_xRotation, UpperLimit, BottomLimit);
			
			Camera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
			_playerRigidbody.MoveRotation(_playerRigidbody.rotation * Quaternion.Euler(0, Mouse_X * MouseSensitivity * Time.smoothDeltaTime, 0) );
		}
		
		
		private void HandleJump()
		{
			if (!_hasAnimator) return;
			if(!_inputManager.Jump) return;
			_animator.SetTrigger(_jumpHash);
		}
		
	
		public void JumpAddForce()
		{
			_playerRigidbody.AddForce(- _playerRigidbody.velocity.y * Vector3.up, ForceMode.VelocityChange);
			_playerRigidbody.AddForce(Vector3.up * JumpFactor, ForceMode.Impulse);
			_animator.ResetTrigger(_jumpHash);
		}
		
	
		private void SampleGround()
		{
			if(!_hasAnimator) return;
            
			
			RaycastHit hitInfo;
			if(Physics.Raycast(_playerRigidbody.worldCenterOfMass, Vector3.down, out hitInfo, Dis2Ground + 0.1f, GroundCheck))
			{
				
				//Grounded
				_grounded = true;
				SetAnimationGrounding();
				return;
			}
			else
			{
			//Falling
			_grounded = false;
				
			_animator.SetFloat(_zVelHash, _playerRigidbody.velocity.y);
			SetAnimationGrounding();
				return;
			}
		}
		
		private void SetAnimationGrounding()
		{
			_animator.SetBool(_fallingHash, !_grounded);
			_animator.SetBool(_groundHash, _grounded);
			
		}
		
		
		
		
		
		
		
		
		
		
		
	}
}