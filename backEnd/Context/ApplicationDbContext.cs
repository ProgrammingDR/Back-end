using backEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EmpleadoModel> Empleado { get; set; }
        public DbSet<PedidoModel> Pedido { get; set; }
        public DbSet<VentaModel> Venta { get; set; }
    }
}
