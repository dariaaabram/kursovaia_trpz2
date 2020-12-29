namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        Time = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Single(nullable: false),
                        TableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DishIngredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IngredientId, t.DishId })
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.DishId);
            
            CreateTable(
                "dbo.DishOrder",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.DishId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DishId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DishOrder", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.DishOrder", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.DishIngredient", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.DishIngredient", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.DishOrder", new[] { "DishId" });
            DropIndex("dbo.DishOrder", new[] { "OrderId" });
            DropIndex("dbo.DishIngredient", new[] { "DishId" });
            DropIndex("dbo.DishIngredient", new[] { "IngredientId" });
            DropTable("dbo.DishOrder");
            DropTable("dbo.DishIngredient");
            DropTable("dbo.Tables");
            DropTable("dbo.Orders");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Dishes");
        }
    }
}
