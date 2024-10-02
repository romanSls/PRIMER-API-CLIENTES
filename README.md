Controlador ClienteController:
El controlador ClienteController hereda de ControllerBase, que es una clase base en ASP.NET Core que proporciona varias funcionalidades importantes para crear APIs.

Atributo [ApiController]: Este atributo se utiliza para designar que esta clase es un controlador de API. Mejora la validación de datos automáticamente y ayuda a manejar respuestas HTTP correctamente.

Atributo [Route("cliente")]: Define la ruta base para los métodos dentro de este controlador. Todas las acciones dentro de este controlador responderán a rutas que comiencen con /cliente.

Método ListarCliente():
Este método es una acción que responde a solicitudes HTTP GET.

[HttpGet] indica que este método responde a solicitudes HTTP de tipo GET.
[Route("listar")] define que este método estará disponible en la ruta /cliente/listar.
El método crea una lista de objetos Cliente, con datos simulados de dos clientes, y luego retorna la lista con el método Ok(). Este método envía la respuesta con el código HTTP 200 (éxito), y el contenido en formato JSON.

Método ListarClientexId():
Similar al método anterior, este también responde a una solicitud GET.

int codigo: Este parámetro se recibe directamente en la URL, y lo utilizamos para buscar un cliente específico por ID.
Luego, creamos un objeto Cliente con el codigo recibido y lo devolvemos como parte de la lista.
Método GuardarCliente():
Este método responde a solicitudes POST y guarda los datos de un cliente.

[FromBody] Cliente cliente: Aquí se recibe un objeto Cliente desde el cuerpo de la solicitud. Si no se proporciona un cliente válido (o si su Nombre es nulo o vacío), retornamos un código BadRequest indicando que los datos son inválidos.
Si todo está bien, asignamos un ID al cliente y devolvemos una respuesta de éxito con el método Ok(), informando que el cliente fue registrado correctamente.
Método EliminarCliente():
Este método también responde a solicitudes POST, pero aquí se espera eliminar un cliente.

Primero, se extrae el valor del encabezado "Authorization" desde el objeto Request.
Si el token no coincide con "marcopolo", devolvemos una respuesta Unauthorized con un mensaje de error. Si el token es correcto, eliminamos al cliente (esto es simulado) y devolvemos un mensaje de éxito.
Clase Cliente:
Esta clase es un modelo que representa a un cliente con las siguientes propiedades:

Id: el identificador único del cliente.
Nombre: el nombre del cliente.
Edad: la edad del cliente en formato de cadena de texto.
Correo: la dirección de correo electrónico del cliente.
