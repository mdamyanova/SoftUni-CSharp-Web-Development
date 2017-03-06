namespace Sales.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValueOnAgeInCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            AlterColumn("Customers", "Age", a => a.Int(defaultValue: 20));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Customers", "Age");
            AlterColumn("Customers", "Age", a => a.Int(defaultValue: null));
        }
    }
}