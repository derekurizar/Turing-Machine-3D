#### Universidad Rafael Landivar
#### Lenguajes Formales y Automatas
#### Derek André Menéndez Urizar
#### Proyecto realizado en el IDE Unity 2017.3.1f1

# Turing Machin Project
Este proyecto tiene la capacidad de poder simular distintas máquinas de turing, con la posibilidad de mostrar si una entrada es valida o no. Además la posibilidad
de agregar más máquinas de turing esta al alcance, puesto que solo se deben de agregar las reglas a tráves de un diccionario y automáticamente estará en funcionamiento la
nueva máquina de Turing.

El proyecto se mira tal y como esta imagen:
![](https://i.imgur.com/J7nbqCd.png)

Para utilizar el proyecto se deben seguir los siguientes pasos:

 1. Ejecutar el .exe o reproducir la máquina desde el IDE Unity 2017.3.1f1(este o posterior)
 2. Elegir la máquina de Turing que se desea simular
 3. Ingresar la entrada para la máquina de Turing seleccionada.
 4. Iniciar la máquina.

## Utilizando el Simulador

Para utilizar el simulador debes elegir la máquina de Turing que deseas utilizar tal y como se muestra en la siguiente imagen:
![](https://i.imgur.com/If9ghr6.png)

Una vez elegida la máquina de Turing, debes ingresar la entrada de la máquina tal y como lo muesta la siguiente imagen:
![](https://i.imgur.com/MJbkVoP.png)

Cuando ya hayas elegido tu Máquina de Turing y hayas ingresado su entrada, solamente debes iniciar la máquina de Turing con estos
pasos:

En el menú selecciona este botón:
![](https://imgur.com/77TvaMu)

Y así podras ejecutar cualquier entrada en cualquier Máquina de Turing.

## Entrada Aprobada

Si la máquina de Turing acepta la entrada entonces sucederá lo siguiente en pantalla:
![](https://i.imgur.com/iNQn1G4.png)

Como se puede observar el cabezal y las esferas de cada uno de los bloques de la máquina se pondrán de color verde, aprobando la entrada.

## Entrada Rechazada

Si la máquina de Turing rechaza la entrada entonces sucederá lo siguiente en pantalla:
![](https://imgur.com/HWhng1B)

Como se puede observar el cabezal y las esferas de cada uno de los bloques de la máquina se pondrán de color rojo, rechazando la entrada.

## Reinicando la Máquina de Turing

Al finalizar de leer una entrada, puedes reiniciar la máquina de Turing presionando este botón.
![](https://i.imgur.com/bSM5kV2.png)

#Entradas Por máquina de Turing

##Suma

La manerá correcta de ingresar sumas en la máquina es de la siguiente forma -> 11+11 o 11+ o +11

Ejemplo de resultados:

11+11 = BBB1111BBB
11+111 = BBB11111BBB

Nota: no debe agregar simbolo igual ni algún otro simbolo que no sea el que muestra el ejemplo.

##Resta

La manerá correcta de ingresar restas en la máquina es de la siguiente forma -> 11-11 o -11 o 11-

Ejemplo de resultados:

11-11 = BBBBBB
11-111 = BBB-1BBB

Nota: no debe agregar simbolo igual ni algún otro simbolo que no sea el que muestra el ejemplo.

##Multiplicación

La manerá correcta de ingresar multiplicaciones en la máquina es de la siguiente forma -> 11*11

Ejemplo de resultados:

11*11 = BBB1111BBB
11*111 = BBB111111BBB

Nota: no debe agregar simbolo igual ni algún otro simbolo que no sea el que muestra el ejemplo.

##Palindromes

La manerá correcta de ingresar palindromes en la máquina es de la siguiente forma y solamente con letras "abc" -> aba o aabbaa o acca

Ejemplo de resultados:

aba = BBBBBB (siendo aprobado)
abba = BBBBBB (siendo aprobado)

Nota: no debe agregar simbolo igual ni algún otro simbolo que no sea el que muestra el ejemplo.

##Copia de Cadena

La manerá correcta de ingresar copia de cadena en la máquina es de la siguiente forma y solamente con letras "abc" -> abc o abbc o aaa o ccc etc..

Ejemplo de resultados:

aa = BBBaaaaBBB (siendo aprobado)
abba = BBBabbaabbaBBB (siendo aprobado)

Nota: no debe agregar simbolo igual ni algún otro simbolo que no sea el que muestra el ejemplo.

# Por qué mi proyecto es robusto ?

Primeramente porque se le han implementado varias pruebas en cada una de las máquinas de Turing y todas han dado el resultado esperado. Además de tener
la facilidad de importarle nuevas máquinas al proyecto hace que el proyecto no solo sea robusto sino que también expandible. Además de que esta implementada
la máquina en 3D y es bastante agradable a la vista, tomando en cuenta que en Unity hasta el momento no hay ningúna máquina de Turing en 3D.







