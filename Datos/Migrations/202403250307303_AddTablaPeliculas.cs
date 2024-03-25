namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaPeliculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Peliculas",
                c => new
                    {
                        PeliculaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                        Genero = c.String(nullable: false, maxLength: 30),
                        Autores = c.String(nullable: false, maxLength: 75),
                        Existencia = c.Int(nullable: false),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PeliculaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Peliculas");
        }
    }
}
