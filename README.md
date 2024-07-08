# Pueba Tecnica Raycast

## Pasos Previos
Para poder resolver la prueba técnica, lo primero que hice fue establecer un diagrama de flujo de la aplicación. En este diagrama, marqué los eventos y acciones que ocurrirían en el juego. Utilicé Figma para crear este diagrama, lo que me permitió visualizar la lógica del juego y las interacciones entre los diferentes componentes.
![image](https://github.com/juananre/Raycast/assets/78058130/a1424294-fa72-4228-b655-6be12dd571f8)
[Link](https://www.figma.com/board/yO0NkcI7O3A5GBBeS12qzz/Untitled?node-id=0-1&t=gzlzwY5I4KZ81hPw-1)

Después de establecer las acciones a realizar, creé el proyecto en la versión de Unity 2022.3.6f1, al igual que el repositorio en GitHub para tener el debido control de versiones. Descargué Audacity, ya que este programa me ayudó a editar los audios de manera rápida. Aunque no me enfoco en el audio, Audacity me facilitó ciertas tareas.


![image](https://github.com/juananre/Raycast/assets/78058130/ce7ec67f-6df0-4bf2-abe2-7f756c92f2bc)


## Desarrollo
Cree una carpeta main donde almacene todo lo hecho por mi y objetos que necesitava de facil acseso [Esta es la carpeta ](PruebaTecnica/Assets/_Main). Todas las pruebas fueron relizadas en la sampleScene defaul de unity.

### Hacer el movimiento 
Una vez establecido lo que necesitaba, lo primero que hice fue implementar el movimiento del jugador. Dado que decidí que sería un juego en primera persona en el que el jugador derrota enemigos estáticos, solo implementé un código que permitiera mover la cámara. Además, agregué un seguro que evitara que la cámara girara de manera no deseada.

### Hacer el arma
Para la mecánica principal de disparar, inicialmente configuré un Raycast que cambiara el color de un cubo al ser impactado. Implemente un sistema de cuando detecte el raycast para tener mas crontol de a que impacto. Descargué assets de la Asset Store de Unity para hacer pruebas con esto, y una vez que estuvo listo, pasé a trabajar en los enemigos.

### Hacer los enemigos
Para los enemigos, primero establecí que pudieran morir utilizando interfaces para manejar el daño que recibían. Como había tres tipos de enemigos, las interfaces me ayudaron a controlar cómo todos recibían daño. Además, establecí un patrón Observer que, al momento de spawnear, los enemigos se suscribieran a un método para registrar si hacían daño o morían, lo cual se reflejaba en el puntaje.

### Implementación del Generador de Enemigos
Para generar enemigos de manera automática, implementé un generador de enemigos que crea enemigos en puntos de generación específicos a intervalos regulares.
[Aqui el codigo](PruebaTecnica/Assets/_Main/Scripts/Generator_Enemy.cs).

## Problemas
Tube varios problemas al momento de conectar los enemigos entre si ya que los tipos enemigos tomaban las estadisticas del enemigo base lo cual no me permitia tener los distintos tipos a locual lo soluciones removiento en [SerializeField] en el enemy base asi ya podia dar los varoles deseados alos enemigos por independite

Surgieron otros problemas que consumieron mucho tiempo y fueron en parte mi culpa por el orden al iniciar a programar el proyecto. Al momento de spawnear enemigos, varios datos se rompieron, pero logré solucionar estos problemas. Sin embargo, no pude implementar los puntajes distintos por enemigos, varios audios y algunas animaciones que quería utilizar.
