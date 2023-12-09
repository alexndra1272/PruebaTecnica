# Prueba Tecnica

## Descripción

Proyecto realizado con .Net 6 y WPF.

## Instalación

Pasos para instalar el proyecto.

```bash
git clone https://github.com/alexndra1272/PruebaTecnica.git
``````
Abrir la solucion del proyecto en Visual Studio Code

Verificar que las propiedades de la solucion inicie varios proyectos, colocar el backend como el primero.

## Configuración de la cadena de conexión

Este proyecto utiliza una base de datos SQLite para almacenar datos. Para configurar la cadena de conexión, sigue estos pasos:

Da click derecho en el proyecto Backend.
Selecciona la opción "Administrar secretos de usuario".
Agrega la siguiente cadena de conexión en el archivo `secrets.json`:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=data.db; Cache=Shared"
    }
}
