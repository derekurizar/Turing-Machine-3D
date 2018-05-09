using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Machine : MonoBehaviour {
	private GameObject cube;
	private Vector3 offset;
	private GameObject text;
	private bool load;
	private float positionText;
	private float positionCube;
	private float positionSphere;
	private int counter;
	private int actualPosition;
	private GameObject particle;
	private GameObject child;
	private ParticleSystem sysParticle;
	private RectTransform rt;
	private TuringMachine tm;
	private Dictionary<string, string> rm;
	private bool errorMachine;
	private char dirMachine;
	private int stateMachine;
	private bool endMachine;
	private bool Keys;
	private char symbolMachine;
	private int steps;
	private GameObject initSphere;
	private MachineRules mr;
	public GameObject player;     	
	public Button btnNext;
	public Button btnReset;
	public Canvas CanvasText;
	public Canvas CanvasButton;
	public GameObject sphere;
	public InputField inputMachine;
	public Dropdown dropMachine;


	// Use this for initialization
	void Start () {

		//Inicializo Botones
		btnNext.onClick.AddListener(BuildMachine);
		btnReset.onClick.AddListener(ResetMachine);
		btnReset.interactable = false;

		//31 distancia cubo
		positionCube = -49f;
		positionText = -94.5f;
		positionSphere = -99.8f;
		actualPosition = 3;
		counter = 0;

		//Initialize
		InitializeValuesTuring();
		mr = new MachineRules();
		Keys = false;

		//Vista camara
		offset = transform.position - player.transform.position;
	}

	void InitializeValuesTuring(){
		errorMachine = false;
		dirMachine = 'I';
		stateMachine = 0;
		endMachine = false;
		steps = 0;
	}

	void AddBlock(string text){

		//Se agrega el bloque
		CreateCube();
		
		//Se agrega su luz
		CreateSphere();

		//Se agrega su texto
		CreateText(text);

		positionCube += 31;
		positionText += 31;
		positionSphere += 31;
		counter++;
	}

	//Construye la máquina
	void BuildMachine(){
		string tira = "βββ" + inputMachine.text + "βββ";
		CreateMachine (tira);

		switch(dropMachine.value){
			case 0:
			//Machine Palindrome
			rm = mr.getPal();
			tm = new TuringMachine(tira,rm, new int[]{11});
			
			break;

			case 1:
			//Machine Copy
			rm = mr.getCopy();

			tm = new TuringMachine(tira,rm, new int[]{1});

			break;

			case 2:
			//Machine Mult
			rm = mr.getMult();

			tm = new TuringMachine(tira,rm, new int[]{11});

			break;

			case 3:
			//Machine Sum
			rm = mr.getSum();

			tm = new TuringMachine(tira,rm, new int[]{3});

			break;

			case 4:
			//Machine Sub
			rm = mr.getSub();

			tm = new TuringMachine(tira,rm, new int[]{3});

			break;
		}

		//Disble buttons when the machine is working
		btnNext.interactable = false;
		inputMachine.interactable = false;
		dropMachine.interactable = false;
		btnReset.interactable = false;

		//And now Turn on the Machine
		//InvokeRepeating("MotorMachine", 0.5f, 0.5f);
		StartCoroutine(MotorMachine());
	}

	//This is the motor of the TuringMachine
	IEnumerator MotorMachine(){
		bool addSymbol = false;
		if(endMachine || errorMachine){
			//Se acaba la recursividad
		}else{
			tm.WorkMachine(ref errorMachine, ref dirMachine, ref stateMachine, ref endMachine, ref symbolMachine, ref addSymbol);
			steps++;
			if(errorMachine){
				ErrorMachine();
				btnReset.interactable = true;
			}else{
				ChangeTextElement("text"+actualPosition,symbolMachine.ToString());
				ChangeTextElement("txtState","Current State: " + stateMachine);
				ChangeTextElement("txtSteps","Steps: " + steps);

				yield return new WaitForSeconds(0.5f);
				
				if(dirMachine == 'R'){
					MoveToTheRight();
				}else if(dirMachine == 'L'){
					MoveToTheLeft();
				}

				yield return new WaitForSeconds(0.5f);
				
				if(addSymbol){
					AddBlock("β");
				}

				if(endMachine){
					SuccessMachine();
					btnReset.interactable = true;
				}
			}
			StartCoroutine(MotorMachine());
		}
	}

	void CreateMachine(string tira){
		for(int i=0;i < tira.Length;i++){
			AddBlock(tira[i].ToString());
		}

		particle = GameObject.Find("sphere3").gameObject;
		child = particle.transform.Find("Circle").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(0.078f, 1.0f, 0.65f, 1f);
		child = particle.transform.Find("Beam").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(0.078f, 1.0f, 0.65f, 1f);
		child = particle.transform.Find("Electric").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(0.078f, 1.0f, 0.65f, 1f);
		child = particle.transform.Find("Smog").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(0.078f, 1.0f, 0.65f, 1f);
		initSphere = GameObject.Find("Sphere").gameObject;
		initSphere.SetActive(false);
	}

	void ErrorMachine(){
		//Se colocan de rojo las luces
		for(int i=0;i < counter;i++){
			ChangeColorSphere(i,0.82f, 0.0f, 0.0f);
		}

		//Se coloca de rojo el cabezal
		particle = GameObject.Find("PointPlayer").gameObject;
		particle.GetComponent<Light>().color = new Color(0.82f, 0.0f, 0.0f, 1f);
		Keys = true;		
	}

	void SuccessMachine(){
		//Se colocan de verde las luces
		for(int i=0;i < counter;i++){
			ChangeColorSphere(i,0.078f, 1.0f, 0.65f);
		}

		//Se coloca de verde el cabezal
		particle = GameObject.Find("PointPlayer").gameObject;
		particle.GetComponent<Light>().color = new Color(0.0f, 1.0f, 0.0f, 1f);	
		Keys = true;
	}

	void ResetMachine(){
		//Elimina objetos de la Scene
		for(int i=0;i < counter;i++){
			particle = GameObject.Find("CubeMachine"+i).gameObject;
			Destroy(particle);
			particle = GameObject.Find("sphere"+i).gameObject;
			Destroy(particle);
			particle = GameObject.Find("text"+i).gameObject;
			Destroy(particle);
		}

		//Reinicia los valores inicales
		player.transform.position = new Vector3(-7.4f,-15.9f,51.9f);
		CanvasButton.transform.position = new Vector3(-161.3999f,-8.900002f,52.90002f);
		positionCube = -49f;
		positionText = -94.5f;
		positionSphere = -99.8f;
		actualPosition = 3;
		counter = 0;
		Keys = false;	

		//Se coloca amarillo el cabezal
		particle = GameObject.Find("PointPlayer").gameObject;
		particle.GetComponent<Light>().color = new Color(1f,0.89f,0.0f, 1f);

		//Initialize Turing Values
		InitializeValuesTuring();

		//Se reinician los textos
		ChangeTextElement("txtState","Current State: 0");
		ChangeTextElement("txtSteps","Steps: 0");

		//Enable buttons
		btnNext.interactable = true;
		inputMachine.interactable = true;
		dropMachine.interactable = true;
		btnReset.interactable = false;

		initSphere.SetActive(true);
	}

	void CreateCube(){
		cube = Instantiate(GameObject.FindGameObjectWithTag("Cube")) as GameObject;
		cube.transform.position = new Vector3(positionCube, 4.0f, 100.0f);
		cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		cube.name = "CubeMachine" + counter;
	}

	void CreateText(string character){
		text  = new GameObject("text" + counter, typeof(RectTransform));
		rt = (RectTransform)text.transform;
		rt.sizeDelta = new Vector2(20.0f,20.0f);
		var newTextComp = text.AddComponent<Text>();
		newTextComp.text = character;
		newTextComp.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		newTextComp.fontSize = 16;
		newTextComp.fontStyle = FontStyle.Bold;
		newTextComp.transform.SetParent (CanvasText.transform, true);
		newTextComp.transform.position = new Vector3(positionText, 9f, 54.5f);
	}

	void CreateSphere(){
		sphere = Instantiate(GameObject.FindGameObjectWithTag("Particle")) as GameObject;
		sphere.transform.position = new Vector3(positionSphere, 39.6f, 66.8f);
		sphere.transform.localScale = new Vector3(1,1,1);
		sphere.name = "sphere" + counter;
	}

	void MoveToTheLeft(){
		//Put yellow color to the last sphere position
		ChangeColorSphere(actualPosition,1f,0.89f,0.0f);

		//Put green color to the actual sphere position
		ChangeColorSphere(--actualPosition,0.078f, 1.0f, 0.65f);

		//move elements
		player.transform.Translate (-31.0f,0.0f,0.0f);
		CanvasButton.transform.Translate (-31.0f,0.0f,0.0f);
	}

	void MoveToTheRight(){
		//Put yellow color to the last sphere position
		ChangeColorSphere(actualPosition,1f,0.89f,0.0f);
	
		//Put green color to the actual sphere position
		ChangeColorSphere(++actualPosition,0.078f, 1.0f, 0.65f);

		//move elements
		player.transform.Translate (31.0f,0.0f,0.0f);
		CanvasButton.transform.Translate (31.0f,0.0f,0.0f);
	}
	
	//Change the color of a sphere in some position
	void ChangeColorSphere(int number, float RColor, float GColor, float BColor){
		particle = GameObject.Find("sphere" + number).gameObject;
		child = particle.transform.Find("Circle").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(RColor, GColor, BColor, 1f);
		child = particle.transform.Find("Beam").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(RColor, GColor, BColor, 1f);
		child = particle.transform.Find("Electric").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(RColor, GColor, BColor, 1f);
		child = particle.transform.Find("Smog").gameObject;
		child.GetComponent<ParticleSystem>().startColor = new Color(RColor, GColor, BColor, 1f);
	}

	void ChangeTextElement(string element, string text){
		particle  = GameObject.Find(element).gameObject;
		particle.GetComponent<Text>().text = text;
	}

	// Update is called once per frame
	void Update () {		
		if(!Keys){
			transform.position = player.transform.position + offset;
		}else{
			if (Input.GetKey("up"))
            	transform.Translate (0.0f,0.0f,0.20f);
        
        	if (Input.GetKey("down"))
            	transform.Translate (0.0f,0.0f,-0.20f);

		}
	}
}
