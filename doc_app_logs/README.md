
# Logs de Aplicación

  

Log, historial de log o registro, se refiere a la grabación secuencial en un archivo o en una base de datos de todos los acontecimientos (eventos o acciones) que afectan a un proceso de nuestra aplicación. De esta forma constituye una evidencia del comportamiento del sistema.

Para instalar cualquier librería que facilita el log de nuestra aplicación necesitamos utilizar la herramienta Nuget de Visual Studio.

 ## Niveles de Logs
    
-   DEBUG: trazas de la aplicación en depuración
-   INFO: información
-   WARN: advertencia (posible fallo)
-   ERROR: error del sistema
-   FATAL: error bloqueante que puede tener efectos secundarios en el sistema (por ejemplo, no poder conectarnos a una base de datos generará probablemente un bloqueo de muchas funcionalidades del sistema)

  

## ¿Qué es Nuget?

  

NuGet es un complemento para Visual Studio para instalar y gestionar librerías de terceros de una manera automatizada. La propia extensión se encarga de realizar la descarga del paquete, comprobar que en el proyecto se cumplen todos los requisitos (dependencias de otros paquetes, incompatibilidades de versiones, etc), su instalación y la inserción/actualización de las referencias en los ficheros necesarios (por ejemplo en web.config, app.config, archivos .cs necesarios, etc).

## Cómo instalar log4net a través de Nuget

1.  ### Agregar paquete log4net:
    

  

Hacemos click derecho en el proyecto y seleccionamos la opción “Administrar paquetes Nuget...”:

![](https://lh5.googleusercontent.com/eudFBZQzQI1UDpV3Shz392jzaxGAipWZ-23xVhvKf19kCWeNKwBbDyt0YA01w00bBysEq_hTMJ4jQsQHS35DSCzEt-RD3vkDEKVCsiK3be33TTs-NscQOIq2jPylRa8zt-77wk2v)

  

2.  ### Vamos a agregar el paquete log4net.
    

Para esto ingresamos en la barra de búsqueda la palabra “log4net”, seleccionamos el paquete encontrado y hacemos click en la opción Instalar:

  

![](https://lh5.googleusercontent.com/2ON4AlyElODG427ClPAk-079MJPFXV2cl5sdNsXtKS-PvKeUfIXhQqw97evjpT31m986z3acJLzkJkm5ccXY59y3ZjGBn4p7Iex_y1ibANUaLOQoJFKNerSFBBn79ZPhbrnx3pLN)

  

3.  ### Agregar archivo log4net.config
    

![](https://lh5.googleusercontent.com/0XQDWt8HRSOFj6nfnHDcHXcZrCHmqvd1sN4pg1Y5e-KBrFfwJq8uav_talBCBWcKQuYnKyiFOzO5PWB7bxXbwoPAEfZh2Md-DtxI0SJ6BWjLN3-f-T3jV9ZmRzJNRIyZ27nn3now)

![](https://lh3.googleusercontent.com/kurI5pjci0VeBe-MeXo1iBGFIebd-h8gdiWaXfkViPggaC6Btta35_E7jd_2a8MrmI1hpoyPmZ_TnLRH6rCXH3yeKQRcgcIp5jzSQi4BcmjfTnDD-V8xdFoGOHqyIGv0YcfrxuOy)

4.  ### Establezca "Copiar al directorio de resultado" en "Copiar siempre".
    

  

Esto es importante porque necesitamos que el archivo log4net.config se copie a la carpeta bin cuando compila y ejecuta su aplicación.

![](https://lh4.googleusercontent.com/sFws9DD7bz4xs7eOEJxwBUkNtXJorabxHh_tWLVCoNmJdX_IqQ9eIjIkJhwGbpB__RgRtO-9N1CIH2v5ruHdrTZEgAZ35mmii_qBzNlBKQkktC6htboMCWdfLq4ykSpo5KzwmgGA)

  

![](https://lh4.googleusercontent.com/lBxWzJYgOJ3KDT0xLg-Bn2h0TdeJyxNZSfmMARztE8CHCioxirjc6I6lwT7AGAKEUWDereVYTs2wfd7_IxPEYA64qhRyIXrr7hojRW3ry49wN0o94y7Gxq0Gom8A1dhnYfMjSRYS)

5.  ### Reemplazar el contenido del archivo log4net.config.
    
``` xml
 <log4net>
  <root>
    <level value="ALL" />
    <appender-ref ref="file" />
  </root>
  <appender name="file" type="log4net.Appender.RollingFileAppender">
    <file value="SistemaVentas.log" />
    <appendToFile value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="5" />
    <maximumFileSize value="10MB" />
    <staticLogFileName value="true" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%date [%thread] %level %logger - %message%newline" />
    </layout>
  </appender>
</log4net>

```
6.  ### Le indicamos a log4net que cargue tu configuración.
    

  

![](https://lh3.googleusercontent.com/RHZoX7AQZeuE45jzBrIBEozQh1z2IDh_V-PRLoIrmzFrQpBLEGwlU5M6sbEswGbGwGzvKy3p6b1DosnpFU5Z_OySw1mPPPMrBIr3Ebsqaukr6Ut65cy_HrP9SvCPqiWBnAxson17)

  

7.  ### Finalmente generamos logs de la siguiente forma:
    

![](https://lh5.googleusercontent.com/u-YYy9aotkV7kZ1MoRdgURKwPawpMO0AqxMIWRmO86emrREfAQhgj3FL5pYW2U-IOZ9dfsRS9pYaUITwVSj8Y5OQXSIAlLbFNPcP4IFWp4rcM9_UE5qefRGgYNqj-6S05k23yRIg)

  


