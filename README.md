## Escritorio con luces RGB controladas desde Bluetooth ##

Hace apenas unas semanas publiqué un proyecto que te serviría de guía para mostrar como comunicar un Arduino Mega por medio de Bluetooth con una aplicación de Android hecha en Xamarin.

Si ese proyecto te interesa, puedes verlo en este [repositorio.](https://github.com/aminespinoza/Escritorio-luminoso)

Con ese proyecto en mente, se me ocurrió agregar un nuevo reto. Ahora probar como hacer lo mismo pero desde una aplicación universal de Windows 10 instalada en una Raspberry Pi con este SO y por medio de una comunicación I2C.

Lo interesante de este proyecto es la enorme cantidad de matices que esto puede tomar, la bella comunicación entre Raspberry y Arduino como un genial complemento y obviamente la comunicación I2C.

Si deseas conocer más de Windows 10 IoT Core en una Raspberry, [este enlace es para ti.](https://developer.microsoft.com/en-us/windows/iot)

Si deseas conocer más de la comunicación por medio de I2C, [nada como su artículo de Wikipedia.](https://es.wikipedia.org/wiki/I%C2%B2C)

¿Comenzamos?

# El hardware requerido

La lista de Hardware que necesitas es la siguiente:

1. Un [Arduino Mega](https://www.330ohms.com/products/arduino-mega-2560-r3)
2. Una [Raspberry Pi, puede ser 2 o 3](https://www.330ohms.com/products/bluetooth-hc-06-esclavo)
3. Tres tiras de led RGB análogas
4. Nueve transistores [TIP120](https://www.330ohms.com/products/tip120) (tres por cada tira de leds que vayas a utilizar)
5. Una pantalla para desplegar información en la Raspberry, puedes usar cualquier monitor de computadora.
6. Una tarjeta de prototipado y ¡muchos cables!

# Ensamblado

Para armar tu prototipo, lo que debes hacer es seguir el siguiente diagrama (Hecho con [Fritzing](http://fritzing.org/home/)).

<img src="imagenes/img01.JPG" width="900" height="480"/>

Creo que el diagrama es sumamente explícito pero en caso de que tengas alguna duda solo levanta un issue con tu duda y la aclararé tan pronto como pueda.

