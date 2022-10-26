namespace Candidates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        JMGB = c.Long(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MobilePhone = c.String(),
                        Note = c.String(),
                        employed = c.Boolean(nullable: false),
                        changes = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.JMGB, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Candidates", new[] { "JMGB" });
            DropTable("dbo.Candidates");
        }
    }
}
