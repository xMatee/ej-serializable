﻿namespace Library;
public class Persona {

    public static string cedulaReferencia = "2987634";
    public string cedula { get; set; }
    public string nombre{ get; set; }
    public DateTime nacimiento{ get; set; }

    public Persona(string cedula, string nombre, DateTime nacimiento) {
        this.SetCedula(cedula); //TODO ¿ Porque pusimos .SetCedula en vez de .Cedula ?
        this.nombre = nombre;
        this.nacimiento = nacimiento;
    }

    public string GetCedula() {
        return this.cedula;
    }

    public void SetCedula(string cedula) { 
        if (Persona.IsCedulaValida(cedula)) {
            this.cedula = cedula.Replace(".", "").Replace("-","").Replace("/","").Replace(" ","");  //Esto queda "repetido", se podría optimizar.
        }
    }
    // public string GetNombre() {
    //     return this.nombre;
    // }
    // public void SetNombre(string nombre) {
    //     this.nombre = nombre;
    // }

    // public DateTime GetFechaNacimiento(){
    //     return this.nacimiento;
    // }

    // public void SetFechaNacimiento(DateTime fecha) {
    //     this.nacimiento = fecha;
    // }

    public int GetEdad() {  //TODO hacerlo en menos líneas ¿sin cargar variable edad ? ¿sin variable hoy? Acortar if.
        DateTime hoy = DateTime.Today;
        int edad =  hoy.Year - this.nacimiento.Year;
        if (hoy.Month < this.nacimiento.Month || (hoy.Month == this.nacimiento.Month && hoy.Day < this.nacimiento.Day)){
            edad = edad - 1;
        }   //cuando la condición del if queda muy larga, personalmente no me gusta hacerlo en una única línea.
        return edad;
    }

    public static bool IsCedulaValida(string cedula){ //TODO Mostrar como acortar los if's
        // Quitar caracteres no numéricos
        cedula = cedula.Replace(".", "").Replace("-","").Replace("/","").Replace(" ","");   //Esto queda "repetido", se podría optimizar.
        
        long cedulaLong;
        if (cedula.Length != 8 || (!long.TryParse(cedula,out cedulaLong))) {
            return false;
        }
        // Calcular número verificador
        int checkSum = 0;
        for (int i = 0; i < Persona.cedulaReferencia.Length; i++){
            int digitoActual = Convert.ToInt32(cedula[i].ToString());
            int digitoReferenciaActual = Convert.ToInt32(Persona.cedulaReferencia[i].ToString());
            checkSum = checkSum + digitoActual * digitoReferenciaActual;
        }
        int digitoVerificador = 10 - (checkSum % 10);
        if (digitoVerificador == 10) {
            digitoVerificador = 0;
        }
        if (digitoVerificador == Convert.ToInt32(cedula[7].ToString())){
            return true;
        }
        return false;
    }
}
