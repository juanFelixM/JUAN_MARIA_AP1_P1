using System.Linq.Expressions;
using JUAN_MARIA_AP1_P1.DAL;
using JUAN_MARIA_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;


namespace JUAN_MARIA_AP1_P1.Services
{
    public class AporteServices(IDbContextFactory<Contexto> DbFactory)
    {
        // Metodo Guardar
        public async Task<bool> Guardar(Aportes aporte)
        {
            aporte.AporteId = aporte.AporteId;
            if (!await Existe(aporte.AporteId))
            {
                return await Insertar(aporte);
            }
            else
            {
                return await Modificar(aporte);
            }
        }

        // Metodo Existe
        public async Task<bool> Existe(int AporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .AnyAsync(t => t.AporteId == AporteId);

        }

        //Metodo Insertar

        public async Task<bool> Insertar(Aportes aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Aportes.Add(aporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        //Metodo Modificar
        public async Task<bool> Modificar(Aportes aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(aporte);
            return await contexto
                .SaveChangesAsync() > 0;

        }

        //Metodo Buscar
        public async Task<Aportes?> Buscar(int AporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .FirstOrDefaultAsync(t => t.AporteId == AporteId);
        }

        //Metodo Eliminar
        public async Task<bool> Eliminar(int aporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .AsNoTracking()
                .Where(t => t.AporteId == aporteId)
                .ExecuteDeleteAsync() > 0;
        }

        //Metodo Listar
        public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }

}
