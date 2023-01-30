He implementado los siguientes proyectos:


FootballWorldCupScoreBoard.Business
	Librería que implementa las operaciones requeridas.
	Implementa las clases:

	* Clase Game.- Cuya  responsabilida es almacenar los datos del encuentro, es decir, el equipo local, el de fuera y el marcador
		- Implementa un constructor con los datos de los equipos e iniciliaza el marcador a 0 de ambos equipos
		- Y un método para actualizar el marcador de ambos equipos

	* Clase Scoreboard.- Cuya responsabilidad de almacenar el listado de encuentros, y que implementa los siguientes metodos:
		- StartGame.- Iniciar un juego entre dos equipos, el cual, agrega un nuevo juego al conjunto de encuentros
		- Actualizar el marcador de un encuentro
		- FinishGame.- Finalizar un juego, el cual elimina el juego del listado 
		- GetGamesByTotalScoreDesc.- Obtiene un lisato de los juegos del tablero ordenado por el total del marcador descendentemente

FootballWorldCupScoreBoard.Business.Test
	Proyecto que implementa los test de cada uno de los métodos de la librería FootballWorldCupScoreBoard.Business

FootballWorldCupScoreBoard.Console
	Aplicación de consola para probar la librería
	* Clase Main.- Clase principal de la aplicación. La cual implementa la interacción con el usuario, muestra un ofreciendo las siguientes operaciones:
		- Exit of program
		- Start a game
		- Update a score game
		- Get summary.- Get all started games order by total score
		
	He usado inyeccion de dependencias para crear instanciar las clase Game y Scoreboard en el método Main de la clase Program de la aplicación de consola
	He intentado que el código sea limpio y que siga los principios SOLID
		
	
