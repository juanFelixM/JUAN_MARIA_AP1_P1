using System.ComponentModel.DataAnnotations;

namespace JUAN_MARIA_AP1_P1.Models;

public class Aportes
{
    [Key]
    public int AporteId { get; set; }

    [Required(ErrorMessage = "La fecha es requerida")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "El monto es requerido")]
    public double Monto { get; set; }
}
