# Introduccion 

Web API para la empresa N5, enfocada en el registro de permisos de usuario.

# Para Empezar

1. En el archivo ChallengeWebApi\Challenge_Backend_N5_WebAPI\appsettings.json , sedebe confiogurar las siguiente variables:
  * ConnectionStrings-->cadena-conexion-n5 , Con la cadena de conexion deseada y la bd que desea crear para el sistema.
  * kafka--> brokerUrl , Se configura con el servidor con su puerto de escucha del servicio kafka
  * kafka--> topic , Se configura con el nombre del topic de kafka.
  
2. Base Datos, Se especifica que despues de generar el paso anterior se debe correr el siguiente comando "Update-Database" en la consola de Package Manager Console , con esto se genera la base de datos del API con sus respectivas tablas.



# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
