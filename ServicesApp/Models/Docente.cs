public class Docente : Usuario{
    public Usuario? datosPersonales {get; set;}
    public string? materia {get;set;} //qué campo de la docencia enseña
    public int experiencia {get;set;} //años de experiencia
    public string? grado {get;set;} //licenciado? Ingeniero? Doctorado?
}