namespace Different20P_4_EntityFramework_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "CategoryId");
            AddForeignKey("dbo.Movies", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Movies", "MovieCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieCategory", c => c.String());
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            DropColumn("dbo.Movies", "CategoryId");
        }
    }
}
