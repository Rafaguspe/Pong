using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour {
//Velocidad de la pelota
public float velocidad = 30.0f;
//Contadores de goles
public int golesIzquierda = 0;
public int golesDerecha = 0;
//Cajas de texto de los contadores
public TextMeshProUGUI contadorIzquierda;
public TextMeshProUGUI contadorDerecha;

public Raqueta raquetaIzq,raquetaDer;


//Audio Source
AudioSource fuenteDeAudio;
public AudioSource fuenteDeAudioR;
//Clips de audio
public AudioClip audioGol, audioRaqueta, audioRebote,audioWindows,Audiofinal;

 private Rigidbody2D rigi;
  private BoxCollider2D boxi;

// Use this for initialization
void Start () {
 
    boxi=GetComponent<BoxCollider2D>();
     rigi=GetComponent<Rigidbody2D>();
//Velocidad inicial hacia la derecha
GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
//Recupero el componente audio source;
fuenteDeAudio = GetComponent<AudioSource>();
//Pongo los contadores a 0
contadorIzquierda.text = golesIzquierda.ToString();
contadorDerecha.text = golesDerecha.ToString();

fuenteDeAudioR.clip = audioWindows;
fuenteDeAudioR.Play();



}
//Se ejecuta si choco con la raqueta
void OnCollisionEnter2D(Collision2D micolision){
//Si me choco con la raqueta izquierda
if (micolision.gameObject.name == "RaquetaIzquierda"){
//Valor de x
int x = 1;
//Valor de y
int y = direccionY(transform.position,
micolision.transform.position);
//Vector de dirección
Vector2 direccion = new Vector2(x, y);
//Aplico la velocidad a la bola
GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
//Reproduzco el sonido de la raqueta
fuenteDeAudio.clip = audioRaqueta;
fuenteDeAudio.Play();
}
//Si me choco con la raqueta derecha
else if (micolision.gameObject.name == "RaquetaDerecha"){
//Valor de x
int x = -1;
//Valor de y
int y = direccionY(transform.position,
micolision.transform.position);
//Vector de dirección
Vector2 direccion = new Vector2(x, y);
//Aplico la velocidad a la bola
GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
//Reproduzco el sonido de la raqueta
fuenteDeAudio.clip = audioRaqueta;
fuenteDeAudio.Play();
}
//Para el sonido del rebote
if (micolision.gameObject.name == "Arriba" ||
micolision.gameObject.name == "Abajo"){
//Reproduzco el sonido del rebote
fuenteDeAudio.clip = audioRebote;
fuenteDeAudio.Play();
}
}
//Calculo la dirección de Y
int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
if (posicionBola.y > posicionRaqueta.y){
return 1;
}
else if (posicionBola.y < posicionRaqueta.y){
return -1;
}
else{
return 0;
}
}
//Reinicio la posición de la bola
public void reiniciarBola(string direccion){
if (direccion == "Derecha"){
//Incremento goles al de la derecha
golesDerecha++;
//Lo escribo en el marcador
contadorDerecha.text = golesDerecha.ToString();
//Reinicio la bola
GetComponent<Rigidbody2D>().velocity = Vector2.right *
velocidad;
//Vector2.right es lo mismo que new Vector2(1,0)
}
else if (direccion == "Izquierda"){
//Incremento goles al de la izquierda
golesIzquierda++;
//Lo escribo en el marcador
contadorIzquierda.text = golesIzquierda.ToString();
//Reinicio la bola
GetComponent<Rigidbody2D>().velocity = Vector2.left *
velocidad;
//Vector2.right es lo mismo que new Vector2(-1,0)
}
//Reproduzco el sonido del gol
fuenteDeAudio.clip = audioGol;
fuenteDeAudio.Play();

velocidad=velocidad+15f;

float pp= velocidad;


raquetaIzq.velocidad=raquetaIzq.velocidad+8f;
raquetaDer.velocidad=raquetaDer.velocidad+8f;

if (golesDerecha>=5 || golesIzquierda>=5)
{
   StartCoroutine(fin());
}

if (golesDerecha<5 || golesIzquierda<=5)
{
    //Posición 0 de la bola
transform.position = Vector2.zero;
//Vector2.zero es lo mismo que new Vector2(0,0);
//Velocidad inicial de la bola
velocidad = 30;
//Velocidad y dirección
}



}

IEnumerator fin()
{

    boxi.enabled=false;
    rigi.bodyType=RigidbodyType2D.Static;
  fuenteDeAudio.clip = Audiofinal;
fuenteDeAudio.Play();

Vector3 posbol= GetComponent<Transform>().position;
 
 posbol= new Vector3(0,0,0);

yield return new WaitForSeconds(4f);
SceneManager.LoadScene("Inicio");
 boxi.enabled=true;
 rigi.bodyType=RigidbodyType2D.Dynamic;
}




}