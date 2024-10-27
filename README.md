### BackEnd Bekind

PRUEBATÉCNICAPARALA
POSICIÓN DELÍDERTÉCNICOEN
BEKIND

#### Autor: JOHN DIAZ GONZALEZ

###### # Proyecto: Gestión básica de productos con reglas de acceso por rol
 ● Objetivo: Desarrollar una pequeña aplicación donde los usuarios pueden ver o
 gestionar productos según su rol (Admin o Viewer). La aplicación debe tener reglas
 de negocio sencillas para controlar qué operaciones puede realizar cada tipo de
 usuario, y las consultas a la base de datos deben estar optimizadas.
 ● Stack: Frontend en React, backend en .NET Core, base de datos en
 MongoDB(Atlas).

- Se  implemento  arquitectura hexagonal.


Requerimientos :

- El backEnd  esta  desarrollado   en el framework .Net Core 8
- La api  esta iniciando en el  puerto :7136 > https://localhost:7136/swagger/index.html
   se puedes visualizar  los endpoint  con la herramienta  Swagger.
- En el archivo de configuracion `appsettings.json` :
		 "ConnectionStrings": {
		  "MongoDb":     "mongodb+srv://bekindMongoDB:mzfankzIgFcMOb1i@basemongodb.2lbxo.mongodb.n et/?retryWrites=true&w=majority"
		 },
- El usuario  y contraseña  de la base de datos :
		- bekindMongoDB:mzfankzIgFcMOb1i
