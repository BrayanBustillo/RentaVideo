namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaRenta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Renta",
                c => new
                    {
                        RentaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        PeliculaId = c.Int(nullable: false),
                        FechaRenta = c.DateTime(nullable: false),
                        FechaRetorno = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RentaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.Peliculas", t => t.PeliculaId)
                .Index(t => t.ClienteId)
                .Index(t => t.PeliculaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Renta", "PeliculaId", "dbo.Peliculas");
            DropForeignKey("dbo.Renta", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Renta", new[] { "PeliculaId" });
            DropIndex("dbo.Renta", new[] { "ClienteId" });
            DropTable("dbo.Renta");
        }
    }
}
