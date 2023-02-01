using System.Collections;
using System.Collections.Generic;
//using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
//using ControlInput;
using MenuNamespace;
namespace AD1762_GTSDF
{

	public class CombatantController : Combatant
	{
		//Controls_Map Controls;

		public Menu MenuAcces;


		public GameObject Body;
		public GameObject Head;
		public GameObject Neck;

		public Rigidbody CombatantRigidbody;

		Vector2 Move_Vector;
		float Look_X;
		float Look_Y;

		public float MoveSpeed;
		byte RunByte;
		public float RunSpeed;
		public float LookXSensivity;
		public float LookYSensivity;
		public float AimXSensivity;
		public float AimYSensivity;

		void Move(Vector2 Move_ctx)
		{
			Move_Vector = Move_ctx;
		}
		void MoveStop()
		{
			Move_Vector.x = 0; Move_Vector.y = 0;
		}
		void Look(Vector2 Look_ctx)
		{
			Look_Y += Look_ctx.x * LookXSensivity;
			Look_X += Look_ctx.y * LookYSensivity;
		}
		void LookCancel()
		{
			Look_X = 0; Look_Y = 0;
		}
		void Run()
		{
			if (Move_Vector.y == 1) { RunByte = 1; };
		}
		void StopRun()
		{
			RunByte = 0;
		}

		public Collider InteractionSphere;
		public GameObject InteractionUI;
		public bool InteractableText;
		private Interface[] InteractArray = new Interface[3];
		private Interface Interactable;

		void Interact()
		{
			if (Interactable != null)
			{
				DisaplePlayerInteract();
				//Controls.Interact.Enable();
				Interactable.SetInteractionNames();
				InteractionUI.SetActive(true);
			}
		}
		void Interact_Command(int CommandNumber)
		{
			ToggleOnUI();
			Cursor.lockState = CursorLockMode.Confined;
			Interactable.Interaction(CommandNumber);
		}
		public void InteractSet(Interface InterfaceSet)
		{
			bool Key = true;
			bool Key2 = true;
			int i = 0;
			int i2 = 0;
			while (Key2)
			{
				if (InteractArray[i] == InterfaceSet)
				{
					Key = false;
					Key2 = false;
				}
				if (i == InteractArray.Length - 1)
				{
					Key2 = false;
				}
				i++;
			}
			while (Key)
			{
				if (Key && InteractArray[i2] == null)
				{
					InteractArray[i2] = InterfaceSet;
					Key = false;
					if (Interactable == null) { Interactable = InterfaceSet; }
				}
				i2++;
			}
		}
		public void InteractRemove(Interface InterfaceRemove)
		{
			for (int i = 0; i <= InteractArray.Length - 1; i++)
			{
				if (InteractArray[i] == InterfaceRemove)
				{
					InteractArray[i] = null;
				}
			}
			if (Interactable == InterfaceRemove)
			{
				Interactable = null;
			}
		}
		bool InteractBool = true;
		void updateInteractable()
		{
			if (Interactable != null)
			{
				for (int i = 0; i < InteractArray.Length - 1; i++)
				{
					if (InteractArray[i] != null)
					{
						if (Vector3.Distance(Interactable.gameObject.transform.position, InteractionSphere.transform.position) >= Vector3.Distance(InteractArray[i].transform.position, InteractionSphere.transform.position))
						{
							Interactable = InteractArray[i];
							//InteractableText.GetComponent<UnityEngine.UI.Text>().text = Interactable.name;
						}
					}
				}
				//InteractableText.text = Interactable.ConsoleName;
				InteractBool = true;
			}
			else if (InteractBool)
			{
				//InteractableText.text = "";
				InteractionUI.SetActive(false);
				//Controls.Interact.Disable();
				EnaplePlayerInteract();
				InteractBool = false;
			}
		}

		public void Fire(
			//InputAction.CallbackContext FireCommand)
			)
		{
			if (ActiveWeapon != null)
			{
				if (ActiveWeapon.GetComponent<IW_Item>().ItemIs != null)
				{
					if (ActiveWeapon.GetComponent<IW_Item>().ItemIs.GetType() == typeof(Weapon))
					{
						Weapon FireWeapon = (Weapon)ActiveWeapon.GetComponent<IW_Item>().ItemIs;
						FireWeapon.Fire();
					}
				}
				else
				{ Debug.Log("NULL" + ActiveWeapon); }
			}
		}
		private void OnEnable()
		{
			//Controls.Enable();
		}
		private void OnDisable()
		{
			//Controls.Disable();
		}


		public GameObject CanvasMenu;

		public void ToggleOnPlayer()
		{
			//Controls.UI.Disable();
			//Controls.Player.Enable();
		}
		public void ToggleOnUI()
		{
			//Controls.Player.Disable();
			//Controls.UI.Enable();
		}

		private void Awake()
		{
			/*
			Controls = new Controls_Map();
			Controls.Player.Move.performed += Move_ctx => Move(Move_ctx.ReadValue<Vector2>());
			Controls.Player.Move.canceled += Moce_Stop_ctx => MoveStop();
			Controls.Player.Look.performed += Look_ctx => Look(Look_ctx.ReadValue<Vector2>());
			Controls.Player.Look.canceled += Look_ctx => LookCancel();
			Controls.Player.Run.performed += Run_ctx => Run();
			Controls.Player.Run.canceled += Run_ctx => StopRun();
			Controls.Player.Fire.performed += Fire_ctx => Fire(Fire_ctx);
			Controls.Player.Interact.performed += Interact_ctx => Interact();
			Controls.Player.EscMenu.performed += EM_ctx => MenuAcces.ToggleEscMenu();

			Controls.Player.Interact1.performed += Interact_ctx => SwitshWeapon(0);
			Controls.Player.Interact2.performed += Interact_ctx => SwitshWeapon(1);
			Controls.Player.Interact3.performed += Interact_ctx => SwitshWeapon(2);
			Controls.Player.Interact4.performed += Interact_ctx => SwitshWeapon(3);
			//Controls.Player.Interact5.performed += Interact_ctx => SwitshWeapon(4);

			Controls.UI.EscMenu.performed += EM_ctx => MenuAcces.ToggleEscMenu();

			Controls.Interact.Interact1.performed += Interact_ctx => Interact_Command(0);
			Controls.Interact.Interact2.performed += Interact_ctx => Interact_Command(1);
			Controls.Interact.Interact3.performed += Interact_ctx => Interact_Command(2);
			Controls.Interact.Interact4.performed += Interact_ctx => Interact_Command(3);
			Controls.Interact.Interact5.performed += Interact_ctx => Interact_Command(4);

			Cursor.lockState = CursorLockMode.Locked;
			*/
		}
		void Start()
		{
			//Controls.Interact.Disable();
			//Controls.UI.Disable();
		}
		void Update()
		{
			updateInteractable();
			//CombatantHead.transform.rotation.Set(Look_X, Look_Y, 0f, 0f);
			//CombatantHead.transform.rotation.Set(-Look_Vector.y * LookYSensivity + CombatantRigidbody.transform.rotation.y, Look_Vector.x * LookXSensivity + CombatantRigidbody.transform.rotation.x, 0f, 0f);
			Head.transform.Rotate(-Look_X * LookYSensivity, 0f, 0f);
			//Neck.transform.Rotate(0f, Look_Y * LookXSensivity, 0f);
			Body.transform.Rotate(0f, Look_Y * LookXSensivity, 0f);
		}
		void FixedUpdate()
		{
			CombatantRigidbody.AddRelativeForce(Move_Vector.x * MoveSpeed, 0, Move_Vector.y * MoveSpeed + RunByte * RunSpeed);
		}
		void Log(int inti)
		{
			Debug.Log(inti);
		}
		void DisaplePlayerInteract()
		{
			/*
			Controls.Player.Interact1.Disable();
			Controls.Player.Interact2.Disable();
			Controls.Player.Interact3.Disable();
			Controls.Player.Interact4.Disable();
			Controls.Player.Interact5.Disable();
			*/
		}
		void EnaplePlayerInteract()
		{
			/*
			Controls.Player.Interact1.Enable();
			Controls.Player.Interact2.Enable();
			Controls.Player.Interact3.Enable();
			Controls.Player.Interact4.Enable();
			Controls.Player.Interact5.Enable();
			*/
		}
	}

}