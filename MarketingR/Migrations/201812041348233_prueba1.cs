namespace MarketingR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Productoes", "Observaciones");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "Observaciones", c => c.String());
        }
    }
}
