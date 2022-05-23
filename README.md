# Financiera
App desarrollada con C#

La app esta desarrollada con **NET 5**, el repositorio cuenta con una **Solucion**, en la que por carpetas se definio un proyecto para **BackEnd (ASP NET WEB API)**, otro para el **FrontEnd (Blazor WASM)** y proyecto Compartido **SharedModel**, en el cual se definieron las clases que utilizaran ambos proyectos.

**Configuracion de Conexion a la BD**
En el proyecto *AppFinanciera.API* que se encuentra en la **carpeta de BackEnd**, en el archivo *appsettings.json*, se puede configurar la cadena de conexion a la **Base de Datos**, que esta montada en **SQL SERVER** (En el repositorio, en la carpeta **BD** se encuentra el script para ser ejecutado), el tipo de autenticacion usado es **Autenticacion por SQL SERVER**
![image](https://user-images.githubusercontent.com/39971650/169738350-ee7fd253-d0ef-46b3-9e27-98350023428b.png)


**Agregar URL de WebApi a el Proyecto del FRONT-END**
Para poder conectarse a los *End-points*, en el proyecto de **Blazor WASM**, en la **carpeta de FrontEnd** en **wwwroot/appsettings.json**, se encuentra la propiedad en la cual se le asigna la url de los *WebApis*, para que exista la comunicacion entre el cliente y los end-points.
Para hacer esto, primero se debe ejecutar el proyecto *AppFinanciera.API*, copiarnos la URL y asignarla en el archivo antes mencionado.

![image](https://user-images.githubusercontent.com/39971650/169738865-6af4fffc-afe4-464b-9a92-f35b5b6b4ef8.png)
*URL de WepApi*

![image](https://user-images.githubusercontent.com/39971650/169738951-ecf0afdb-87a1-4bf1-b816-5824a455ea9d.png)
*En esta parte se asigna la url del back, seguida por la palabra **api** *
