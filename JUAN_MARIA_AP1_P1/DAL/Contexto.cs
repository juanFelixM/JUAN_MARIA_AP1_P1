using JUAN_MARIA_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;


namespace JUAN_MARIA_AP1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Aportes> Aportes { get; set; } 

}