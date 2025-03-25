namespace MiPrimeraApi.Models // 🔹 Equivale a: package MiPrimeraApi.models;
{
    // 🔸 Equivale a: public class Empleado { ... }
    public class Empleado
    {
        // 🔹 Propiedades públicas con getter/setter automáticos (como usar Lombok en Java)

        // 🔸 int Id (clave primaria, se autoincrementa en la BD)
        public int Id { get; set; }

        // 🔸 string = String en Java, pero con minúscula. 
        // C# diferencia entre tipos por mayúscula/minúscula.
        // Le asignamos string.Empty para evitar el warning CS8618
        public string Nombre { get; set; } = string.Empty;
        // tbn se podria poner asi public string? Nombre { get; set; }

        // 🔸 Cargo del empleado (string no nulo)
        public string Cargo { get; set; } = string.Empty;

        // 🔸 decimal se usa en C# para representar dinero (como BigDecimal en Java)
        public decimal Salario { get; set; }

        // 🔸 En Java usarías: private String nombre; con @Getter @Setter (Lombok)
        // Aquí ya viene todo listo con las auto-properties de C#
    }
}
